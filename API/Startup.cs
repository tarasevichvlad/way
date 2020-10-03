using System;
using System.Collections.Generic;
using System.Linq;
using API.AuthHandlers;
using Application.Cars.Queries.GetAllCarsQuery;
using Application.Interfaces.Persistence;
using Application.Reviews.Commands.CreateReviewCommand;
using Application.Reviews.Query.GetAllReviewsQuery;
using Application.Reviews.Query.GetReviewByIdQuery;
using Application.Trips.Commands.AddPassengerCommand;
using Application.Trips.Commands.CreateTripCommand;
using Application.Trips.Commands.DeleteTripCommand;
using Application.Trips.Commands.RemovePassengerCommand;
using Application.Trips.Commands.UpdateTripCommand;
using Application.Trips.Queries.GetActiveTripsQuery;
using Application.Trips.Queries.GetAllTripsQuery;
using Application.Trips.Queries.GetFinishedTripsQuery;
using Application.Trips.Queries.GetTripDetailQuery;
using Application.Trips.Queries.SearchTripsQuery;
using Application.Users.Commands.AddOrUpdateCarCommand;
using Application.Users.Commands.UpdateUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence.Cars;
using Persistence.Reviews;
using Persistence.Shared;
using Persistence.Trips;
using Persistence.Users;
using Serilog;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Way API",
                    Version = "v1"
                });
                
                var sts = Configuration["SwaggerAuthorization:StsUrl"];
                var scopes = Configuration.GetSection("SwaggerAuthorization:Scopes")
                    .Get<string[]>()
                    .ToDictionary(k => k, v => v);
                var servers = Configuration.GetSection("SwaggerAuthorization:Servers").Get<List<string>>();

                x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{sts}/authorize"),
                            TokenUrl = new Uri($"{sts}/token"),
                            Scopes = scopes
                        }
                    }
                });

                x.SwaggerGeneratorOptions.Servers.AddRange(servers.Select(x => new OpenApiServer { Url = x }));

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                        },
                        scopes.Keys.ToList()
                    }
                });
            });

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.AddSerilog(dispose: true);
            });

            services.AddControllers();

            InitDb(services);
            InitRepositories(services);
            InitCommandsAndQueries(services);
            InitAuth(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext databaseContext)
        {
            // Init DB data
            databaseContext.Database.Migrate();

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.OAuthClientId(Configuration["SwaggerAuthorization:ClientId"]);
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void InitCommandsAndQueries(IServiceCollection sc)
        {
            // Init queries
            sc.AddScoped<IGetAllCarsQuery, GetAllCarsQuery>();
            sc.AddScoped<IGetAllTripsQuery, GetAllTripsQuery>();
            sc.AddScoped<IGetAllReviewsQuery, GetAllReviewsQuery>();
            sc.AddScoped<IGetTripDetailQuery, GetTripDetailQuery>();
            sc.AddScoped<IGetReviewByIdQuery, GetReviewByIdQuery>();
            sc.AddScoped<IGetReviewByIdQuery, GetReviewByIdQuery>();
            sc.AddScoped<IGetAllUsersQuery, GetAllUsersQuery>();
            sc.AddScoped<ISearchTripsQuery, SearchTripsQuery>();
            sc.AddScoped<IGetActiveTripsQuery, GetActiveTripsQuery>();
            sc.AddScoped<IGetFinishedTripsQuery, GetFinishedTripsQuery>();

            // Init commands
            sc.AddScoped<ICreateTripCommand, CreateTripCommand>();
            sc.AddScoped<IAddPassengerCommand, AddPassengerCommand>();
            sc.AddScoped<IRemovePassengerCommand, RemovePassengerCommand>();
            sc.AddScoped<IDeleteTripCommand, DeleteTripCommand>();
            sc.AddScoped<ICreateReviewCommand, CreateReviewCommand>();
            sc.AddScoped<IUpdateTripCommand, UpdateTripCommand>();
            sc.AddScoped<IUpdateUserPhoneCommand, UpdateUserPhoneCommand>();
            sc.AddScoped<IAddOrUpdateCarCommand, AddOrUpdateCarCommand>();
        }

        private static void InitRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICarRepository, CarRepository>();
            serviceCollection.AddScoped<IReviewRepository, ReviewRepository>();
            serviceCollection.AddScoped<ITripRepository, TripRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        private void InitAuth(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(AzureADB2CDefaults.JwtBearerAuthenticationScheme)
                .AddAzureADB2CBearer(options => Configuration.Bind("AzureAd", options));

            serviceCollection.AddAuthorization(x =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddRequirements(new UserExist())
                    .Build();

                x.FallbackPolicy = policy;
            });

            serviceCollection.AddScoped<IAuthorizationHandler, AuthHandler>();
        }

        private void InitDb(IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<DatabaseOptions>(Configuration.GetSection(DatabaseOptions.Database));

            var dbConnection = Configuration.GetSection($"{DatabaseOptions.Database}:ConnectionString");
            serviceCollection.AddDbContext<DatabaseContext>(x =>
                x.UseNpgsql(dbConnection.Value));
        }
    }
}
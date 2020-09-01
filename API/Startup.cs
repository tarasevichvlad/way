using API.AuthHandlers;
using Application.Cars.Queries.GetAllCarsQuery;
using Application.Interfaces.Persistence;
using Application.Reviews.Commands;
using Application.Reviews.Commands.CreateReviewCommand;
using Application.Reviews.Query;
using Application.Reviews.Query.GetAllReviewsQuery;
using Application.Trips.Commands.AddPassengerCommand;
using Application.Trips.Commands.CreateTripCommand;
using Application.Trips.Commands.DeleteTripCommand;
using Application.Trips.Commands.RemovePassengerCommand;
using Application.Trips.Queries.GetAllTripsQuery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Cars;
using Persistence.Reviews;
using Persistence.Shared;
using Persistence.Trips;
using Persistence.Users;

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
            services.AddControllers();

            InitDb(services);
            InitRepositories(services);
            InitCommandsAndQueries(services);
            InitAuth(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private static void InitCommandsAndQueries(IServiceCollection serviceCollection)
        {
            // Init queries
            serviceCollection.AddScoped<IGetAllCarsQuery, GetAllCarsQuery>();
            serviceCollection.AddScoped<IGetAllTripsQuery, GetAllTripsQuery>();
            serviceCollection.AddScoped<IGetAllReviewsQuery, GetAllReviewsQuery>();

            // Init commands
            serviceCollection.AddScoped<ICreateTripCommand, CreateTripCommand>();
            serviceCollection.AddScoped<IAddPassengerCommand, AddPassengerCommand>();
            serviceCollection.AddScoped<IRemovePassengerCommand, RemovePassengerCommand>();
            serviceCollection.AddScoped<IDeleteTripCommand, DeleteTripCommand>();
            serviceCollection.AddScoped<ICreateReviewCommand, CreateReviewCommand>();
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using SeatReservation.Api;
using SeatReservation.Api.DataAccess;
using SeatReservation.Api.Events.Command;
using SeatReservation.Api.Events.Query;
using SeatReservation.Api.Middleware;
using SeatReservation.Core.Command;
using SeatReservation.Core.Query;
using SeatReservation.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeatReservation.WebApi
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public static void ConfigureServices(Startup instance, IServiceCollection services)
        {
            // Add framework services.
            services.AddSingleton(instance.Configuration);

            services.AddDbContext<SeatReservationDbContext>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
            services.AddTransient<IQueryDispatcher, QueryDispatcher>();
            services.AddSingleton<ISeatReservationQueryContext, SeatReservationQueryContext>();
            services.AddTransient<IQueryHandler<UpcommingEventsQuery, UpcommingEventsQueryResult>, UpcommingEventsQueryHandler>();
            services.AddTransient<ICommandHandler<CreateEventCommand>, CreateEventCommandHandler>();

            services.AddApplicationInsightsTelemetry(instance.Configuration);

            services.AddMvc()
            .AddJsonOptions(config =>
            {
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug(LogLevel.Information);
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
            }

            app.UseStaticFiles();
            app.UseMvc();

            app.Map("/ws", SocketHandler.Map);
        }
    }
}
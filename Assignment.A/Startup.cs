namespace Assignment.A
{
    using Assignment.A.Filter;
    using Assignment.DI.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IO;
    using System.Reflection;

    public class Startup
    {
        #region Fields

        private readonly string swaggerBasePath = "services/news/api";

        #endregion Fields

        #region Constructors

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        #endregion Constructors

        #region Properties

        public IConfiguration Configuration { get; set; }

        public IWebHostEnvironment Environment { get; set; }

        #endregion Properties

        #region Public Methods

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            #region CORS

            services.AddCors(options => options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            #endregion CORS

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Version = "v1.0",
                    Title = "Assignment A API",
                    Description = "Assignment A API documentation."
                });
                c.OperationFilter<RemoveVersionParameterFilter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPathFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion Swagger

            services.AddControllers()
                    .AddControllersAsServices();
            services.AddApiVersioning()
                    .AddCommonDependencies(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = swaggerBasePath + "/swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{swaggerBasePath}/swagger/v1.0/swagger.json", $"Assignment A API v1.0");
                c.RoutePrefix = $"{swaggerBasePath}/swagger";
            });

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion Public Methods
    }
}
using FluentValidation;
using FluentValidation.AspNetCore;
using Merchant.Ads.API.Configs;
using Merchant.Ads.API.Extensions;
using Merchant.Ads.API.Extensions.CustomExceptionMiddleWare;
using Merchant.Ads.API.Helpers;
using Merchant.Ads.API.Repositories;
using Merchant.Ads.API.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace Merchant.Ads.API
{
    public class Startup
    {
        private readonly string _environment;
        private readonly Settings _settings;
        private readonly MongoDBSettings _mongoDbSettings;

        public Startup(IWebHostEnvironment env)
        {
            Console.WriteLine($"Environment: {env.EnvironmentName}");
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("Configs/appsettings.json")
            .AddJsonFile("Configs/appsettings.Development.json")
            .AddEnvironmentVariables();
            Configuration = builder.Build();

            var envVariables = Environment.GetEnvironmentVariables();
            if (string.IsNullOrWhiteSpace(envVariables["ASPNETCORE_ENVIRONMENT"]?.ToString()))
                throw new ArgumentNullException("ASPNETCORE_ENVIRONMENT");
            _environment = envVariables["ASPNETCORE_ENVIRONMENT"].ToString();
            _settings = Configuration.GetSection("Settings").Get<Settings>();
            // _mongoDbSettings = Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options => // Cross Origin Source
            {
                options.AddPolicy("AllowAll", builder => {
                    builder
                // .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
                });
            });


            /*services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<MerchantValidator>(); */
            services.AddControllers();
            services.AddHttpClient();
            services.AddMvc();


            /*    .AddFluentValidation(options =>
         {
             options.ImplicitlyValidateChildProperties = true;
             options.ImplicitlyValidateRootCollectionElements = true;
             options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         });*/

            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton(_settings);
            services.AddResponseCompression();
            services.AddSingleton<IService, Service>();
            services.AddSingleton<IMerchantRepository, MerchantRepository>();
            services.AddSingleton<MongoDBSettings>();
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDBSettings"));

            //services.AddSingleton( _mongoDbSettings);


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//ILoggerManager,Logger
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureExceptionHandler(logger);
            // app.UseMiddleware<ExceptionMiddleWare>();

            // app.UseHttpsRedirection();


            //app.UseAuthentication();    
            app.UseCors("AllowAll");
            app.UseResponseCompression();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            

        }
    }
} 





using AutoMapper;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Exceptions;
using HumanManagermentBackend.Extensions;
using HumanManagermentBackend.Filters;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using HumanManagermentBackend.Updaters;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IO;
using System.Text;

namespace HumanManagermentBackend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration _iConfig { get; }
        public Startup(IConfiguration config)
        {
            _iConfig = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {         
            var controller = services.AddControllers(opts =>
            {
               // add authorize for all controller
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                opts.Filters.Add(new AuthorizeFilter(policy));
                // controller filter
                opts.Filters.Add(new ControllerFilter());
            });

            // fix loop json
            controller.AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // db
            services.AddDbContext<HumanManagerContext>();

            // to dto
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<EmployeeServiceImpl>();
            services.AddScoped<ShiftServiceImpl>();
            services.AddScoped<WorkingTimeServiceImpl>();
            services.AddScoped<TimeSlotServiceImpl>();
            services.AddScoped<ProvinceServiceImpl>();
            services.AddScoped<DistrictServiceImpl>();
            services.AddScoped<WardServiceImpl>();
            services.AddScoped<AddressServiceImpl>();
            services.AddScoped<JobServiceImpl>();
            services.AddScoped<DegreeServiceImpl>();
            services.AddScoped<DepartmentServiceImpl>();
            services.AddScoped<IndentificationServiceImpl>();
            services.AddScoped<TimeKeepingServiceImpl>();

            services.AddScoped<TimeKeepingDetailServiceImpl>();

            services.AddScoped<NoteServiceImpl>();
            services.AddScoped<CandidateServiceImpl>();
            services.AddScoped<MailServiceImpl>();
            services.AddScoped<ScheduleServiceImpl>();
            services.AddScoped<SalaryServiceImpl>();

            services.AddScoped<UserServiceImpl>();

            services.AddScoped<JobUpdater>();

            services.AddScoped<WorkingTimeUpdater>();

            services.AddScoped<UploadUtil>();
            services.AddScoped<UserUtil>();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            //JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                         {
                             options.TokenValidationParameters = new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,
                                 ValidIssuer = _iConfig.GetValue<string>("Jwt:Issuer"),
                                 ValidAudience = _iConfig.GetValue<string>("Jwt:Issuer"),
                                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfig.GetValue<string>("Jwt:key"))),
                             };
                         });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, SystemContant.Uploading_Folder)),
                RequestPath = "/uploads"
            });

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }

    }
}

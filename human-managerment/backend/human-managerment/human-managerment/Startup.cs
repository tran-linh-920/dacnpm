using AutoMapper;
using HumanManagermentBackend.Contants;
using HumanManagermentBackend.Database;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using HumanManagermentBackend.Updaters;
using HumanManagermentBackend.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace HumanManagermentBackend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<HumanManagerContext>();

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
            services.AddScoped<NoteServiceImpl>();
            services.AddScoped<CandidateServiceImpl>();
            services.AddScoped<MailServiceImpl>();
            services.AddScoped<ScheduleServiceImpl>();

            services.AddScoped<JobUpdater>();

            services.AddScoped<WorkingTimeUpdater>();

            services.AddScoped<UploadUtil>();
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

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, SystemContant.Uploading_Folder)),
                RequestPath = "/uploads"
            });


            app.UseRouting();

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

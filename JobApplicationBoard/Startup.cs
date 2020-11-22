using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using JobApplicationBoard.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using JobApplicationBoard.Repositories;
using JobApplicationBoard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using JobApplicationBoard.Models;

namespace JobApplicationBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AccountDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AuthenticationDB")));

            // AddDbContextPool adds pooling which makes it more efficent
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            // .AddEntityFrameworkStores<AccountDbContext>();

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
             .AddEntityFrameworkStores<AccountDbContext>();

            services.AddControllersWithViews();

            //Scoped contexts
            services.AddScoped<IApplicantRepo, ApplicantRepo>();
            services.AddScoped<IJobRepo, JobRepo>(); // Use JobRepo for db and MockJobsRepo for dummy data


            services.AddTransient<IEmailService, EmailService>();
            //services.Configure<AuthMessageSenderOptions>(Configuration);

            // Adds support for razor pages and allows compilation while app is running
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}



/*
 * Admin log in and post jobs / edit jobs
 * Applicants visit to apply for jobs. You can not apply for a job and can edit their application
 * Send an email to admin saying someone has applied for the job
 *
 * Project requirements:
 * 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
 *
 */
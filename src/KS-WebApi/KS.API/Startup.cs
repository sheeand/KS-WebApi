using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KS.Business.DataContract.Authorization;
using KS.Business.Managers.Authorization;
using KS.Database.Authorization.Login.Commands;
using KS.Database.Authorization.Login.Invokers;
using KS.Database.Authorization.Login.Receivers;
using KS.Database.Authorization.Register.Commands;
using KS.Database.Authorization.Register.Invokers;
using KS.Database.Authorization.Register.Receivers;
using KS.Database.Contexts;
using KS.Database.DataContract.Authorization.Login;
using KS.Database.DataContract.Authorization.Register;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KS.API
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<KSContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //-- The Mapper class provides implicit reference conversion from one reference type to another
            services.AddScoped<IRegisterUserManager, RegisterUserManager>();
            services.AddScoped<IAuthorizationRegisterCommand, RegisterUserCreateCommand>();
            services.AddScoped<IUserRegisterInvoker, RegisterUserCreateInvoker>();
            services.AddScoped<IAuthorizationRegisterReceiver, RegisterUserCreateReceiver>();

            services.AddScoped<ILoginUserManager, LoginUserManager>();
            services.AddScoped<IAuthorizationLoginCommand, LoginUserCommand>();
            services.AddScoped<IUserLoginInvoker, LoginUserInvoker>();
            services.AddScoped<IAuthorizationLoginReceiver, LoginUserReceiver>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

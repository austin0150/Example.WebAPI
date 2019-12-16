﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Example.Business;
using Example.DataAccess;

namespace Example.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<ICapitalize, Capitalize>();
            services.AddSingleton<DBInteraction>();
            services.AddSingleton<ILowercase, Lowercase>();
            services.AddSingleton<IBinary, Binary>();
            services.AddSingleton<IThesaurus, Thesaurus>();
            services.AddSingleton<IFilter, Filter>();
            services.AddSingleton<IHex, Hex>();
            services.AddSingleton<IAscii, Ascii>();
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

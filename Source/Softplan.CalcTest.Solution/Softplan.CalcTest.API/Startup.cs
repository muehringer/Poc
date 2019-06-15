using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Softplan.CalcTest.Application.App;
using Softplan.CalcTest.Application.Interfaces;
using Softplan.CalcTest.Infrastructure.Configurations;
using Swashbuckle.AspNetCore.Swagger;

namespace Softplan.CalcTest.API
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc(Configuration["SwaggerVersion"].ToString(),
                new Info
                {
                    Title = Configuration["SwaggerTitle"].ToString(),
                    Version = Configuration["SwaggerVersion"].ToString(),
                    Description = Configuration["SwaggerDescription"].ToString(),
                    TermsOfService = "None",
                    Contact = new Contact { Name = Configuration["SwaggerContactName"].ToString(), Email = Configuration["SwaggerContactEmail"].ToString(), Url = Configuration["SwaggerContactUrl"].ToString() }
                });
            });

            //Autenticacao JWT - Json Web Token
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options => {
                var sec = Encoding.UTF8.GetBytes(Configuration["SecretKey"].ToString());

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidAudience = "The name of audience",
                    ValidateIssuer = false,
                    ValidIssuer = "The name of issuer",

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(sec),
                    ValidateLifetime = true,
                };
            });

            //Cors
            services.AddCors();

            //Lendo chaves no arquivo de configuracoes
            services.AddOptions();
            services.Configure<KeysConfig>(Configuration);

            #region Injecao de dependencia nativa

            //Injecao de dependencia nativa
            services.AddScoped(typeof(ITaxesApp), typeof(TaxesApp));
            services.AddScoped(typeof(ICalculationsApp), typeof(CalculationsApp));

            #endregion

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Adicionar compressao ao servico
            services.AddResponseCompression();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            //Permissao Cors
            app.UseCors(
                options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()
            );
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", Configuration["SwaggerTitle"].ToString());
            });

            //Informando ao app que deve usar compressao
            app.UseResponseCompression();
        }
    }
}

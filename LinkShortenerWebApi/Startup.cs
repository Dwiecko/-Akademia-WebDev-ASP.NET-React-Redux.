using LinkShortenerWebApi.DAO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LinkShortenerWebApi
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
            services.AddMvc();
            services.AddSwaggerGen(setupAction: c => c.SwaggerDoc("v1", new Info{
                                                            Title = "Link Shortener API", 
                                                            Version = "v1" }));
            services.AddDbContext<LinksDbContext>(optionsAction: options => options.UseSqlite(
                                                                            Configuration.GetConnectionString(
                                                                            name: "LinksDbConnection")));   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", 
                                                    name: "Link Shortener API"));
        }
    }
}

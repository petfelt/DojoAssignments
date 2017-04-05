using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace MyApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Mvc as a service making it available across our entire app
            services.AddSession();
            services.AddMvc();
        }
         
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            // Use the Mvc to handle Http requests and responses
            app.UseSession();
            app.UseMvc();
            app.UseStaticFiles();
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
        }
        
        
    }
    
}
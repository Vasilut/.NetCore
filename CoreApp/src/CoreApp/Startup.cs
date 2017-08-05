using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using CoreApp.Services;

namespace CoreApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json")
                        .AddEnvironmentVariables();

            Configuration = builder.Build();

        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //DI

            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    ExceptionHandler = context => context.Response.WriteAsync("Hopaa")
                });
            }

            //app.UseDefaultFiles();
            //app.UseStaticFiles(); //html files, js
            app.UseFileServer(); //default files + static files.
            app.UseMvc(ConfigureRoutes);//start using mvc
            app.Run(ctx => ctx.Response.WriteAsync("Not found my boy!!!")); // in case that the route is not good

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/welcome"
            //});

            //app.Run(async (context) =>
            //{
                
            //    var message = greeter.GetGreeting();
            //    await context.Response.WriteAsync(message);
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/32

            routeBuilder.MapRoute("Default", 
                "{controller=Home}/{action=Index}/{id?}"); //so, if we're not fiinding a good controller/action the default will be home and the action Index.
         }
    }
}

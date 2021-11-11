using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryDesignPattern.Middleware;
using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Repository;

namespace RepositoryDesignPattern
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
            services.AddSingleton(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
            //services.AddTransient(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
            //services.AddTransient(typeof(IRepo<Book>), typeof(DataBaseRepo));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Пример 3(по умолчанию)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseRequestCorrelationId();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseStaticFiles();
            //app.UseCookiePolicy();
            //app.UseRequestLocalization();
            //app.UseCors();
            //app.UseAuthentication();
            //app.UseSession();
            //app.UseResponseCompression();
            //app.UseResponseCaching();

            //Пример 1

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello, World!");
            //});

            //Пример 2

            //app.Use(async (context, next) =>
            //{
            //    // Бизнесс логика до передачи управления в другой связующий программный компонент.
            //    await next.Invoke();
            //    // Бизнесс логика после передачи управление в другой связующий программный компонент,
            //    // например логирование
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from 2nd delegate.");
            //});

            //Пример 4
            //app.Map("/map1", HandleMapRequest1);
            //app.Map("/map2", HandleMapRequest2);

            // Пример 5
            //app.MapWhen(context => context.Request.Query.ContainsKey("book"), HandleBook);

            // Пример 6
            //app.UseWhen(context => context.Request.Query.ContainsKey("book"), HandleBookWithUse);


        }

        private static void HandleMapRequest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("В строке адреса было введено map1");
            });
        }

        private static void HandleMapRequest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("В строке адреса было введено map2");
            });
        }

        private static void HandleBook(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var bookName = context.Request.Query["book"];
                await context.Response.WriteAsync($"Название книги в строке запроса = {bookName}");
            });
        }

        private void HandleBookWithUse(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var bookName = context.Request.Query["book"];
                await next();
            });
        }
    }
}

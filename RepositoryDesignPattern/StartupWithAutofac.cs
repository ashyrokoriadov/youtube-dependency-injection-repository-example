using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Repository;

namespace RepositoryDesignPattern
{
    public class StartupWithAutofac
    {
        public StartupWithAutofac(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // ConfigureServices - это место рагистрации зависимостей. Этот метод вызвается
        // до вызова метода ConfigureContainer, который задекларирован ниже.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddControllers();           
        }

        // ConfigureContainer - это метод в котором регистрируются зависимости
        // непосредственно в Autofac. Этот метод вызывается после метода ConfigureServices,
        // так что услуги указанные здесь надпишут регистрации сделанные в методе
        // ConfigureServices. Не вызывайте метод Build контейнера зависимостей - это
        // будет сделано за вас автоматически.
        public void ConfigureContainer(ContainerBuilder builder)
        {

           // Это аналог строчки services.AddSingleton(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
           // в файле Startup.cs.
           builder.RegisterType<CollectionBasedRepo>().As<IRepo<Book>>().SingleInstance();

            // Это аналог строчки services.AddTransient(typeof(IRepo<Book>), typeof(CollectionBasedRepo));
            // в файле Startup.cs.
            //builder.RegisterType<DataBaseRepo>().As<IRepo<Book>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

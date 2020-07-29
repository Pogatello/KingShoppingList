using KingShoppingList.Contract;
using KingShoppingList.Model.Repositories;
using KingShoppingList.Repository;
using KingShoppingList.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace KingShoppingList.IoC
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApplicationServices(services);
            ConfigureRepositories(services, configuration);
        }


        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IListItemService, ListItemService>();
            services.AddTransient<IShoppingListService, ShoppingListService>();

            /* var mappingConfig = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new CourseMappingProfile());
                 mc.AddProfile(new StudentMappingProfile());
             });

             services.AddSingleton(mappingConfig.CreateMapper());*/
        }

        private static void ConfigureRepositories(IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();
            services.AddDbContext<ShoppingListDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.ConnectionString);
            });

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IListItemRepository, ListItemRepository>();
            services.AddTransient<IShoppingListRepository, ShoppingListRepository>();
        }





    }
}

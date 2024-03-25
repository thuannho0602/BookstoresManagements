using BookstoresManagements.Services.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceConfigure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenreSevices, GenreServices>();
            services.AddScoped<IAuthorServices, AuthorServices>();
            services.AddScoped<IPublisherServices, PublisherServices>();
            services.AddScoped<IBookServices, BookServices>();
            services.AddScoped<IImportVoucherServices, ImportVoucherServices>();
            return services;
        }
    }
}

using BookstoresManagements.Reponsitory.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoresManagements.Reponsitory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGenreReponsitory, GenreReponsitory>();
            services.AddScoped<IAuthorReponsitory, AuthorReponsitory>();
            services.AddScoped<IPublisherReponsitory, PublisherReponsitory>();
            services.AddScoped<IBookReponsitory, BookReponsitory>();
            services.AddScoped<IImportVoucherReponsitory, ImportVoucherReponsitory>();
            return services;
        }
    }
}

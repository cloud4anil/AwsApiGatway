using Aws.Core.Implementation;
using Aws.Core.Interface;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Implementations;
using PersonalBlog.Interfaces;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.IoC
{
    public static class BlogServiceDependencyResolver
    {
        public static void AddBlogService(this IServiceCollection services)
        {
            services.AddHttpClient("Blog", client =>
            {
                client.BaseAddress = new Uri("https://mxuw8dv9rj.execute-api.us-east-1.amazonaws.com");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
              

            })
           .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
           {
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
           }));
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IAwsRequestSigner, AWS4RequestSigner>();
        }

      
    }


}

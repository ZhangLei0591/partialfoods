using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PartialFoods.Services;

namespace PartialFoods.Services.APIServer
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
            Channel channel = new Channel("127.0.0.1:3000", ChannelCredentials.Insecure);
            var client = new OrderCommand.OrderCommandClient(channel);

            Channel invChannel = new Channel("127.0.0.1:3002", ChannelCredentials.Insecure);
            var invClient = new InventoryManagement.InventoryManagementClient(invChannel);

            services.AddSingleton(typeof(OrderCommand.OrderCommandClient), client);
            services.AddSingleton(typeof(InventoryManagement.InventoryManagementClient), invClient);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;
using CustomerService.Api.Service.v1.Queries;
using CustomerService.Domain;
using CustomerService.Data;
using Microsoft.EntityFrameworkCore;
using CustomerService.Data.v1;
using CustomerService.Api.Service.v1.Commands;

namespace CustomerService.Api
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

            services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerService.Api", Version = "v1" });
            });

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<GetCustomersQuery, List<Customer>>, GetCustomersQueryHandler>();
            services.AddTransient<IRequestHandler<GetCustomerByIdQuery, Customer>, GetCustomerByIdQueryHandler>();
            services.AddTransient<IRequestHandler<CustomerCreateCommand, Customer>, CustomerCreateCommandHandler>();
            services.AddTransient<IRequestHandler<CustomerUpdateCommand, Customer>, CustomerUpdateCommandHandler>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerService.Api v1"); c.RoutePrefix = string.Empty; });

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

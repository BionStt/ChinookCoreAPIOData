using ChinookCoreAPIOData.Data.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;

namespace ChinookCoreAPIOData.API
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
            services.AddControllers(mvcOptions => 
                mvcOptions.EnableEndpointRouting = false);
 
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
 
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
 
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter();
                routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }
        
        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Album>("Albums");
            odataBuilder.EntitySet<Artist>("Artists");
            odataBuilder.EntitySet<Customer>("Customers");
            odataBuilder.EntitySet<Employee>("Employees");
            odataBuilder.EntitySet<Genre>("Genres");
            odataBuilder.EntitySet<Invoice>("Invoices");
            odataBuilder.EntitySet<InvoiceLine>("InvoiceLines");
            odataBuilder.EntitySet<MediaType>("MediaTypes");
            odataBuilder.EntitySet<Playlist>("Playlists");
            odataBuilder.EntitySet<Track>("Tracks");
            return odataBuilder.GetEdmModel();
        }
    }
}
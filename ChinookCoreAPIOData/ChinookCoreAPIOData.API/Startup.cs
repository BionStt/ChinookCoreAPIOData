using ChinookCoreAPIOData.API.Configuration;
using ChinookCoreAPIOData.Domain.Entities;
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
            services.AddConnectionProvider(Configuration);
            services.ConfigureRepositories();
            services.ConfigureSupervisor();
            services.AddMiddleware();
            services.AddConnectionProvider(Configuration);
            services.AddAppSettings(Configuration);
            services.AddCaching();
            services.AddCORS();
            
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
 
            app.UseHttpsRedirection();
            app.UseAuthorization();
 
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Expand().Select().OrderBy().Filter();
                routeBuilder.MapODataServiceRoute("ODataRoute", "api", GetEdmModel(builder));
            });
        }
        
        IEdmModel GetEdmModel(ODataConventionModelBuilder builder)
        {
            builder.EntitySet<Album>("Albums");
            builder.EntitySet<Artist>("Artists");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<Genre>("Genres");
            builder.EntitySet<Invoice>("Invoices");
            builder.EntitySet<InvoiceLine>("InvoiceLines");
            builder.EntitySet<MediaType>("MediaTypes");
            builder.EntitySet<Playlist>("Playlists");
            builder.EntitySet<Track>("Tracks");
            
            builder.EntityType<Track>()
                .Action("Rate")
                .Parameter<int>("Rating");
            
            builder.EntityType<Track>()
                .Collection
                .Function("MostExpensive")
                .Returns<double>();
            
            builder.Function("GetSalesTaxRate")
                .Returns<double>()
                .Parameter<int>("PostalCode");
            
            return builder.GetEdmModel();
        }
    }
}
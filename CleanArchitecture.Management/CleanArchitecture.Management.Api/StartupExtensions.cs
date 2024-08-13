#region Using

using CleanArchitecture.Management.Persistence.Registrations;
using CleanArchitecture.Management.Application;

#endregion

namespace CleanArchitecture.Management.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
        {
            //AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                /*app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
                });*/
            }

            app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthentication();

            app.UseCors("Open");

            //app.UseAuthorization();

            app.MapControllers();

            return app;

        }
    }
}

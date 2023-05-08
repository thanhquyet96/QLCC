using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using QLCC.Data;
using QLCC.Data.Entities;
using QLCC.Services;
using Repository;
using Service;
using NLog;
using NLog.Web;
using UnitOfWork;
using Microsoft.Extensions.DependencyInjection.Extensions;
using QLCC.Services.Helpers.JWT;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    builder.Services.AddDbContext<QLCCContext>
        (options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
    builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
    //builder.Services.AddSingleton<IRepository<USER>, Repository<USER>>();
    builder.Services.AddAutoMapper(typeof(QLCCBaseServices<>));

    //builder.Services.AddAutoMapper(typeof(UserServices));

    //builder.Services.AddScoped(typeof(BaseServices<,>));
    ////builder.Services.AddSingleton<BaseServices<USER>>();
    builder.Services.AddScoped<UserServices>();
    builder.Services.AddScoped<DateTimeKeepServices>();
    builder.Services.AddScoped<HistoryTimeKeepServices>();
    builder.Services.AddScoped<LeaveServices>();
    builder.Services.AddScoped<RoleServices>();
    builder.Services.AddScoped<TimeKeepServices>();
    builder.Services.AddScoped<UserRoleServices>();

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
        });
        c.AddSecurityRequirement(
            new OpenApiSecurityRequirement
                    {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
            });
    });

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    builder.Services.AddCors();

    var app = builder.Build();

    app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    app.UseAuthorization();

    app.MapControllers();
    // custom jwt auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
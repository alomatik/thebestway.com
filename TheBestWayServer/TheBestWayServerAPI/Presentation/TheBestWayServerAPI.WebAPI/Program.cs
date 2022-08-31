using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Text;
using TheBestWayServerAPI.Application.Extensions;
using TheBestWayServerAPI.Infrastructure.Extensions;
using TheBestWayServerAPI.Persistence.Extensions;
using TheBestWayServerAPI.WebAPI.Extensions;
using TheBestWayServerAPI.WebAPI.Filters;
using TheBestWayServerAPI.WebAPI.Middlewares;
using TheBestWayShared.SharedForWorkerService.RabbitMQ;

//TODO IMAGE FİLE IMPLEMENTATION 
//TODO CACHE(REDIS) IMPLEMENTATION
//TODO STORE PROCEDURE REFACTOR
//TODO RABBITMQ REFACTOR(MAIL-TOPIC EXCHANGE, USER DELETE-DIRECT EXCHANGE,VOTE-DIRECT EXCHANGE)
//TODO IDENTITY PASSWORD,USER.. REFACTOR
//TODO MONGO DB IMPLEMENTATION(MAYBE LATER)
//TODO DOCKERIZE..,VOLUMES..(COMPOSE)

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiBehaviorOptions>(apiBehaviorOptions =>
{
    apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
});

//SERILOG
//var x = new Serilog.Sinks.MSSqlServer.ColumnOptions()
//{
//    AdditionalColumns = new Collection<SqlColumn>()
//            {
//                new SqlColumn("UserName",System.Data.SqlDbType.NVarChar)
//            }
//};

builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.Enrich.FromLogContext();
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.WriteTo.File("Logs/log.txt");
    loggerConfiguration.WriteTo.MSSqlServer(
        connectionString: builder.Configuration.GetConnectionString("SqlServer"),
        tableName: "Logs"
        );
    loggerConfiguration.WriteTo.Seq(builder.Configuration.GetConnectionString("Seq"));
});
//

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

//RABBITMQ
builder.Services.AddSingleton<IRabbitMQClientService, RabbitMQClientService>();
builder.Services.AddSingleton<IConnectionFactory>(serviceProvider => new ConnectionFactory { Uri = new Uri(builder.Configuration.GetConnectionString("RabbitMQ")) });
//

//MY LIBRARIRES
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
//

//AUTH
builder.Services.AddAuthentication(authenticationOptions =>
{
    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
{
    jwtBearerOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
}).AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["web:client_id"];
    googleOptions.ClientSecret = builder.Configuration["web:client_secret"];
});

//builder.Services.AddAuthorization(authOptions =>
//{
//    authOptions.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
//});


//CONTROLLERS
builder.Services.AddControllers(options => options.Filters.Add<CustomValidateFilter>());
//

//SWAGGERAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCustomGlobalExceptionHandler();

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

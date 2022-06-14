using Advertisment.BLL.IServices;
using Advertisment.BLL.Services;
using Advertisment.BLL.Validation;
using Advertisment.DAL.EF;
using Advertisment.DAL.Enteties;
using Advertisment.DAL.IRepositories;
using Advertisment.DAL.Repositories;
using Advertisment.DAL.UnitOfWork;
using AdvertismentAPI.Consumers;
using AdvertismentAPI.Exceptions;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region RABBITMQ
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserConsumer>();
    x.UsingRabbitMq((context, config) =>
    {
        config.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        config.ReceiveEndpoint("user-queue", e =>
        {
            e.Consumer<UserConsumer>(context);
        });
        config.ConfigureEndpoints(context);
    });
});

builder.Services.AddMassTransitHostedService();
#endregion

#region REPOSITORIES
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAdRepository, AdRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddTransient<IAdTagRepository, AdTagRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
#endregion

#region SERVICES
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAdService, AdService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IAdTagService, AdTagService>();
#endregion

#region AUTOMAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region FLUENT VALIDATION
builder.Services.AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<AdCreateDTOValidator>();
    opt.RegisterValidatorsFromAssemblyContaining<AdValidator>();
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionString:Default"]));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

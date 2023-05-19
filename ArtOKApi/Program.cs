using ArtOKApi.Data;
using ArtOKApi.Interfaces;
using ArtOKApi.Repository;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserInterface, UserRepository>();
builder.Services.AddScoped<ITagInterface, TagRepository>();
builder.Services.AddScoped<IPostInterface, PostRepository>();
builder.Services.AddScoped<IFollowerInterface, FollowerRepository>();
builder.Services.AddScoped<ILikeInterface, LikeRepository>();
builder.Services.AddScoped<IImageInterface, ImageRepository>();
builder.Services.AddScoped<IPostComment,PostCommentRepository>();
builder.Services.AddScoped<IPopApInterface,PopAppRepository>();
builder.Services.AddScoped<IDialogUserInterface, DialogUserRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{   
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

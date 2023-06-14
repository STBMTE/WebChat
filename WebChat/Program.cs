using Microsoft.EntityFrameworkCore;
using WebChat.Data.Entities.Models;
using WebChat.Data.Repositories;
using WebChat.Server.Controllers;
using WebChat.Server.Mappers;
using WebChat.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR(opts =>
    {
        opts.EnableDetailedErrors = true;
    })
    .AddJsonProtocol(options =>
    {
        options.PayloadSerializerOptions.PropertyNameCaseInsensitive = true;
    });
builder.Services.AddDbContext<ChatContext>(x => x.UseSqlite("Data Source=app-data.db"));

builder.Services.AddMvc();
builder.Services.AddAutoMapper(typeof(MappingUser), typeof(MappingChatroom), typeof(MappingMessage));

builder.Services.AddMediatR(mediatr =>
{
    mediatr.RegisterServicesFromAssemblyContaining<Program>();
});

builder.Services.AddScoped(typeof(ChatroomService));
builder.Services.AddScoped(typeof(UserService));
builder.Services.AddScoped(typeof(MessageService));

builder.Services.AddScoped(typeof(ChatroomRepository));
builder.Services.AddScoped(typeof(UserRepository));
builder.Services.AddScoped(typeof(MessageRepository));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDeveloperExceptionPage();
 
app.UseDefaultFiles();
app.UseStaticFiles();
 
app.UseRouting();
 
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<UsersController>("/api/users");
    endpoints.MapHub<MessageController>("/api/messages/add");
    endpoints.MapHub<ChatroomController>("/api/chatroom");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
using Microsoft.EntityFrameworkCore;

namespace WebChat.Data.Entities.Models;

public class ChatContext : DbContext
{
    public DbSet<Chatroom> Chatroom { get; set; }  = null!;
    public DbSet<Message> Messages { get; set; }  = null!;
    public DbSet<User> Users { get; set; } = null!;
    
    public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
}
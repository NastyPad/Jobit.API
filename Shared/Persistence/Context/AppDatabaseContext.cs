using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Shared.Persistence.Context;

public class AppDatabaseContext : DbContext
{
    public AppDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<PostType>? PostTypes { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<JobRequest> JobRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //These are from models
        //Note: When you are trying to add foreign keys. You'll need to add them in the entity which has bigger cardinal.
        base.OnModelCreating(modelBuilder);
        //Companies
        modelBuilder.Entity<Company>().ToTable("Companies");
        modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
        modelBuilder.Entity<Company>().Property(p => p.CompanyId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Company>().Property(p => p.CompanyName).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Company>().Property(p => p.Password).IsRequired().HasMaxLength(80);
        modelBuilder.Entity<Company>().Property(p => p.ProfilePhotoUrl).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Company>().Property(p => p.CompanyEmail).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        //Company->Job Relationship 
        modelBuilder.Entity<Company>()
            .HasMany(p => p.Jobs)
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId);

        //Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.UserId);
        modelBuilder.Entity<User>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<User>().Property(p => p.Firstname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<User>().Property(p => p.Lastname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<User>().Property(p => p.ProfilePhotoUrl).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<User>()
            .HasMany(p => p.Projects)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        modelBuilder.Entity<User>()
            .HasMany(p => p.Notifications)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        modelBuilder.Entity<User>()
            .HasMany(p => p.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        modelBuilder.Entity<User>()
            .HasMany(p => p.JobRequests)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
            // builder.Entity<User>().Property(p => p.Birthday).IsRequired();
        
        //PostTypes
        modelBuilder.Entity<PostType>().ToTable("PostTypes");
        modelBuilder.Entity<PostType>().HasKey(p => p.PostTypeId);
        modelBuilder.Entity<PostType>().Property(p => p.PostTypeId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<PostType>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<PostType>()
            .HasMany(p => p.Posts)
            .WithOne(p => p.PostType)
            .HasForeignKey(p => p.PostTypeId);
        
        //Jobs 
        modelBuilder.Entity<Job>().ToTable("Jobs");
        modelBuilder.Entity<Job>().HasKey(p => p.JobId);
        modelBuilder.Entity<Job>().Property(p => p.JobId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Job>().Property(p => p.JobName).IsRequired();
        modelBuilder.Entity<Job>().Property(p => p.Description);
        modelBuilder.Entity<Job>().Property(p => p.Salary);
        modelBuilder.Entity<Job>().Property(p => p.Available).IsRequired();
        modelBuilder.Entity<Job>().Property(p => p.CompanyId).IsRequired();
        modelBuilder.Entity<Job>()
            .HasMany(p => p.JobRequests)
            .WithOne(p => p.Job)
            .HasForeignKey(p => p.JobId);
        
        //Projects 
        modelBuilder.Entity<Project>().ToTable("Projects");
        modelBuilder.Entity<Project>().HasKey(p => p.ProjectId);
        modelBuilder.Entity<Project>().Property(p => p.ProjectId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Project>().Property(p => p.ProjectName).IsRequired();
        modelBuilder.Entity<Project>().Property(p => p.ProjectUrl).IsRequired();
        modelBuilder.Entity<Project>().Property(p => p.Description).IsRequired();
        modelBuilder.Entity<Project>().Property(p => p.CodeSource).IsRequired();
        
        //Notifications
        modelBuilder.Entity<Notification>().ToTable("Notifications");
        modelBuilder.Entity<Notification>().HasKey(p => p.NotificationId);
        modelBuilder.Entity<Notification>().Property(p => p.NotificationId);
        modelBuilder.Entity<Notification>().Property(p => p.NotificationDate);
        modelBuilder.Entity<Notification>().Property(p => p.Content);
        modelBuilder.Entity<Notification>().Property(p => p.UserId);
            
        //Posts
        modelBuilder.Entity<Post>().ToTable("Posts");
        modelBuilder.Entity<Post>().HasKey(p => p.PostId);
        modelBuilder.Entity<Post>().Property(p => p.PostId);
        modelBuilder.Entity<Post>().Property(p => p.Description);
        modelBuilder.Entity<Post>().Property(p => p.UserId);
        modelBuilder.Entity<Post>().Property(p => p.PostTypeId);
        
        //JobRequest
        modelBuilder.Entity<JobRequest>().ToTable("JobRequest");
        modelBuilder.Entity<JobRequest>().HasKey(p => p.RequestId);
        modelBuilder.Entity<JobRequest>().Property(p => p.RequestId);
        modelBuilder.Entity<JobRequest>().Property(p => p.JobId);
        modelBuilder.Entity<JobRequest>().Property(p => p.UserId);


        modelBuilder.UseSnakeCase();
    }
}
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Models.Chat;
using Jobit.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Shared.Persistence.Context;

public class AppDatabaseContext : DbContext
{
    public AppDatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<PostJob> Jobs { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<JobRequest> JobRequests { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<TechSkill> TechSkills { get; set; }
    public DbSet<ApplicantProfile> ApplicantProfiles { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<ApplicantProfileTechSkill> ApplicantProfileTechSkills { get; set; }
    public DbSet<ApplicantProfileEducation> ApplicantProfileEducations { get; set; }
    public DbSet<Career> Careers { get; set; }
    public DbSet<RecruiterProfile> RecruiterProfiles { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Chat> Chats { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //These are from models
        //Note: When you are trying to add foreign keys. You'll need to add them in the entity which has bigger cardinal.
        base.OnModelCreating(modelBuilder);

        //Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(p => p.UserId);
        modelBuilder.Entity<User>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(p => p.Username);
        modelBuilder.Entity<User>().Property(p => p.Firstname);
        modelBuilder.Entity<User>().Property(p => p.Lastname);
        modelBuilder.Entity<User>().Property(p => p.Password);
        modelBuilder.Entity<User>().Property(p => p.Email);
        modelBuilder.Entity<User>().Property(p => p.Type);


        //Companies
        modelBuilder.Entity<Company>().ToTable("Companies");
        modelBuilder.Entity<Company>().HasKey(p => p.CompanyId);
        modelBuilder.Entity<Company>().Property(p => p.CompanyId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Company>().Property(p => p.CompanyName).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Company>().Property(p => p.Password).IsRequired().HasMaxLength(80);
        modelBuilder.Entity<Company>().Property(p => p.ProfilePhotoUrl).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Company>().Property(p => p.CompanyEmail).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Company>().Property(p => p.Description).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Company>()
            .HasMany(p => p.Recruiters)
            .WithOne(p => p.Company)
            .HasForeignKey(p => p.CompanyId);

        //Applicant 
        modelBuilder.Entity<Applicant>().ToTable("Applicants");
        modelBuilder.Entity<Applicant>().HasKey(p => p.ApplicantId);
        modelBuilder.Entity<Applicant>().Property(p => p.ApplicantId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Applicant>().Property(p => p.UserId).IsRequired();
        modelBuilder.Entity<Applicant>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Applicant>().Property(p => p.Firstname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Applicant>().Property(p => p.Lastname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Applicant>().Property(p => p.Password).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Applicant>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Applicant>()
            .HasMany(p => p.Projects)
            .WithOne(p => p.Applicant)
            .HasForeignKey(p => p.ApplicantId);
        modelBuilder.Entity<Applicant>()
            .HasMany(p => p.JobRequests)
            .WithOne(p => p.Applicant)
            .HasForeignKey(p => p.ApplicantId);
        modelBuilder.Entity<Applicant>()
            .HasOne(p => p.ApplicantProfile)
            .WithOne(p => p.Applicant)
            .HasForeignKey<ApplicantProfile>(p => p.ApplicantId);
        modelBuilder.Entity<Applicant>()
            .HasOne(p => p.User)
            .WithOne(p => p.Applicant)
            .HasForeignKey<Applicant>(p => p.UserId); //One to zero... I guess....


        //Recruiters
        modelBuilder.Entity<Recruiter>().ToTable("Recruiter");
        modelBuilder.Entity<Recruiter>().HasKey(p => p.RecruiterId);
        modelBuilder.Entity<Recruiter>().Property(p => p.RecruiterId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Recruiter>().Property(p => p.UserId);
        modelBuilder.Entity<Recruiter>().Property(p => p.CompanyId);
        modelBuilder.Entity<Recruiter>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        modelBuilder.Entity<Recruiter>().Property(p => p.Firstname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Recruiter>().Property(p => p.Lastname).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Recruiter>().Property(p => p.Password).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Recruiter>().Property(p => p.Email).IsRequired().HasMaxLength(200);
        modelBuilder.Entity<Recruiter>()
            .HasOne(p => p.User)
            .WithOne(p => p.Recruiter)
            .HasForeignKey<Recruiter>(p => p.UserId);

        //PostJobs 
        modelBuilder.Entity<PostJob>().ToTable("PostJobs");
        modelBuilder.Entity<PostJob>().HasKey(p => p.PostJobId);
        modelBuilder.Entity<PostJob>().Property(p => p.PostJobId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<PostJob>().Property(p => p.JobName).IsRequired();
        modelBuilder.Entity<PostJob>().Property(p => p.Description);
        modelBuilder.Entity<PostJob>().Property(p => p.Salary);
        modelBuilder.Entity<PostJob>().Property(p => p.Available).IsRequired();
        modelBuilder.Entity<PostJob>().Property(p => p.RecruiterId).IsRequired();
        modelBuilder.Entity<PostJob>()
            .HasMany(p => p.JobRequests)
            .WithOne(p => p.PostJob)
            .HasForeignKey(p => p.PostJobId);

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
        modelBuilder.Entity<Notification>().Property(p => p.NotificationId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Notification>().Property(p => p.NotificationDate);
        modelBuilder.Entity<Notification>().Property(p => p.Content);

        //JobRequest
        modelBuilder.Entity<JobRequest>().ToTable("JobRequests");
        modelBuilder.Entity<JobRequest>().HasKey(p => p.RequestId);
        modelBuilder.Entity<JobRequest>().Property(p => p.RequestId);
        modelBuilder.Entity<JobRequest>().Property(p => p.PostJobId);
        modelBuilder.Entity<JobRequest>().Property(p => p.ApplicantId);
        modelBuilder.Entity<JobRequest>()
            .HasMany(p => p.Notifications)
            .WithOne(p => p.JobRequest)
            .HasForeignKey(p => p.JobRequestId);

        //Notification
        modelBuilder.Entity<Notification>().ToTable("Notifications");
        modelBuilder.Entity<Notification>().HasKey(p => p.NotificationId);
        modelBuilder.Entity<Notification>().Property(p => p.NotificationDate);
        modelBuilder.Entity<Notification>().Property(p => p.Content);

        //ApplicantProfile
        modelBuilder.Entity<ApplicantProfile>().ToTable("ApplicantProfiles");
        modelBuilder.Entity<ApplicantProfile>().HasKey(p => p.ApplicantId);
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.ApplicantId).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Username).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Firstname).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Lastname).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Gender).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.IsPrivate).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.ProfilePhotoUrl).IsRequired();
        modelBuilder.Entity<ApplicantProfile>()
            .HasMany(p => p.ApplicantProfileTechSkills)
            .WithOne(p => p.ApplicantProfile);

        //TechSkills
        modelBuilder.Entity<TechSkill>().ToTable("TechSkills");
        modelBuilder.Entity<TechSkill>().HasKey(p => p.TechSkillId);
        modelBuilder.Entity<TechSkill>().Property(p => p.TechSkillId);
        modelBuilder.Entity<TechSkill>().Property(p => p.TechName); //Many to many! Code first


        //Educations
        modelBuilder.Entity<Education>().ToTable("Education");
        modelBuilder.Entity<Education>().HasKey(p => p.EducationId);
        modelBuilder.Entity<Education>().Property(p => p.EducationId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Education>().Property(p => p.EducationName);
        modelBuilder.Entity<Education>().Property(p => p.PhotoUrl);


        //Careers 
        modelBuilder.Entity<Career>().ToTable("Careers");
        modelBuilder.Entity<Career>().HasKey(p => p.CareerId);
        modelBuilder.Entity<Career>().Property(p => p.CareerId).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Career>().Property(p => p.CareerName);
        modelBuilder.Entity<Career>().Property(p => p.Description);

        //RecruiterProfile
        modelBuilder.Entity<RecruiterProfile>().ToTable("RecruiterProfiles");
        modelBuilder.Entity<RecruiterProfile>().HasKey(p => p.RecruiterId);
        modelBuilder.Entity<RecruiterProfile>().Property(p => p.RecruiterId);
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Username).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Firstname).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Lastname).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Gender).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.Description).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.IsPrivate).IsRequired();
        modelBuilder.Entity<ApplicantProfile>().Property(p => p.ProfilePhotoUrl).IsRequired();
        modelBuilder.Entity<RecruiterProfile>()
            .HasOne(p => p.Recruiter)
            .WithOne(p => p.RecruiterProfile)
            .HasForeignKey<RecruiterProfile>(p => p.RecruiterId);

        //Chats
        modelBuilder.Entity<Chat>().ToTable("Chats");
        modelBuilder.Entity<Chat>().HasKey(p => new { p.RecruiterId, p.ApplicantId });
        modelBuilder.Entity<Chat>().Property(p => p.ApplicantId);
        modelBuilder.Entity<Chat>().Property(p => p.RecruiterId);
        modelBuilder.Entity<Chat>()
            .HasMany(p => p.Messages)
            .WithOne(p => p.Chat)
            .HasForeignKey(p => new { p.ApplicantId, p.RecruiterId });


        //Messages
        modelBuilder.Entity<Message>().ToTable("Messages");
        modelBuilder.Entity<Message>().HasKey(p => p.MessageId);
        modelBuilder.Entity<Message>().Property(p => p.MessageId);
        modelBuilder.Entity<Message>().Property(p => p.ApplicantId);
        modelBuilder.Entity<Message>().Property(p => p.RecruiterId);
        modelBuilder.Entity<Message>().Property(p => p.MessageContent);
        modelBuilder.Entity<Message>().Property(p => p.WhoSentIt);


        //Intermediate Tables
        //ApplicantProfileTechSkills
        modelBuilder.Entity<ApplicantProfileTechSkill>().ToTable("ApplicantProfileTechSkills");
        modelBuilder.Entity<ApplicantProfileTechSkill>().HasKey(p => new { p.ApplicantId, p.TechSkillId });
        modelBuilder.Entity<ApplicantProfileTechSkill>().Property(p => p.ApplicantId);
        modelBuilder.Entity<ApplicantProfileTechSkill>().Property(p => p.TechSkillId);
        modelBuilder.Entity<ApplicantProfileTechSkill>().Property(p => p.ExperienceYears);
        modelBuilder.Entity<ApplicantProfileTechSkill>().Property(p => p.MoreThanAYear);
        //Here is many to many for Applicant - TechSkills with additional columns.
        modelBuilder.Entity<ApplicantProfileTechSkill>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(p => p.ApplicantProfileTechSkills)
            .HasForeignKey(p => p.ApplicantId);
        modelBuilder.Entity<ApplicantProfileTechSkill>()
            .HasOne(p => p.TechSkill)
            .WithMany(p => p.ApplicantProfileTechSkills)
            .HasForeignKey(p => p.TechSkillId);

        //ApplicantProfileEducation
        modelBuilder.Entity<ApplicantProfileEducation>().ToTable("ApplicantProfileEducations");
        modelBuilder.Entity<ApplicantProfileEducation>().HasKey(p => p.ApplicantProfileEducationId);
        modelBuilder.Entity<ApplicantProfileEducation>().Property(p => p.ApplicantProfileEducationId).IsRequired()
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<ApplicantProfileEducation>().Property(p => p.EducationId);
        modelBuilder.Entity<ApplicantProfileEducation>().Property(p => p.ApplicantId);
        modelBuilder.Entity<ApplicantProfileEducation>().Property(p => p.FinishDateTime);
        modelBuilder.Entity<ApplicantProfileEducation>().Property(p => p.StartDateTime);
        modelBuilder.Entity<ApplicantProfileEducation>()
            .HasOne(p => p.ApplicantProfile)
            .WithMany(p => p.ApplicantProfileEducations)
            .HasForeignKey(p => p.ApplicantId);
        modelBuilder.Entity<ApplicantProfileEducation>()
            .HasOne(p => p.Education)
            .WithMany(p => p.ApplicantProfileEducations)
            .HasForeignKey(p => p.EducationId);


        modelBuilder.UseSnakeCase();
    }
}
using System.Text.Json.Serialization;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Persistence;
using Jobit.API.Jobit.Services;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Persistence;
using Jobit.API.Security.Persistence.Repositories;
using Jobit.API.Security.Services;
using Jobit.API.Shared.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(); //--
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Jobit API",
        Description = "Jobit Web Services",
        Contact = new OpenApiContact
        {
            Name = "Jobit.Studio",
            Url = new Uri("https://jobit.studio")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection (Here!)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDatabaseContext>(
    options => options.UseSqlite(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

//Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);

// CORS Service Addition
builder.Services.AddCors();

builder.Services.AddMvcCore().AddApiExplorer();

//Dependecy Injection Configuration

//Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Jobit Injection Configuration
//PostJob
builder.Services.AddScoped<IPostJobRepository, PostJobRepository>();
builder.Services.AddScoped<IPostJobService, PostJobService>();
//Project
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();
//JobRequest
builder.Services.AddScoped<IJobRequestRepository, JobRequestRepository>();
builder.Services.AddScoped<IJobRequestService, JobRequestService>();
//Notifications
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
//TechSkills
builder.Services.AddScoped<ITechSkillRepository, TechSkillRepository>();
builder.Services.AddScoped<ITechSkillService, TechSkillService>();
//ApplicantProfile
builder.Services.AddScoped<IApplicantProfileRepository, ApplicationProfileRepository>();
builder.Services.AddScoped<IApplicantProfileService, ApplicantProfileService>();
//RecruiterProfile
builder.Services.AddScoped<IRecruiterProfileRepository, RecruiterProfileRepository>();
builder.Services.AddScoped<IRecruiterProfileService, RecruiterProfileService>();
//Educations
builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<IEducationService, EducationService>();
//Career
builder.Services.AddScoped<ICareerRepository, CareerRepository>();
builder.Services.AddScoped<ICareerService, CareerService>();

//Intermediate Tables Repositories and Services
//ApplicantProfileTechSkills
builder.Services.AddScoped<IApplicantProfileTechSkillRepository, ApplicantProfileTechSkillRepository>();
builder.Services.AddScoped<IApplicantProfileTechSkillService, ApplicantProfileTechSkillService>();
//ApplicantProfileEducation
builder.Services.AddScoped<IApplicantProfileEducationRepository, ApplicantProfileEducationRepository>();
builder.Services.AddScoped<IApplicantProfileEducationService, ApplicantProfileEducationService>();



//Security Injection Configuration
//User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//Company
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
//Applicant
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
//Recruiter
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();
//Message
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
//Chat
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();




//Automapper Configuration
builder.Services.AddAutoMapper(
    typeof(Jobit.API.Jobit.Mapping.ModelToResourceProfile),
    typeof(Jobit.API.Jobit.Mapping.ResourceToModelProfile),
    typeof(Jobit.API.Security.Mapping.ModelToResourceProfile),
    typeof(Jobit.API.Security.Mapping.ResourceToModelProfile));

builder.Services.AddAuthentication();
var app = builder.Build();

//Validation for ensuring database objects are created.

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDatabaseContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

//Configure Error Handler Middleware


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApi.Data;
using SchoolManagementApi.Interfaces;
using SchoolManagementApi.Middlewares;
using SchoolManagementApi.Repository;
using SchoolManagementApi.Services;

namespace SchoolManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add FastEndpoints
            builder.Services.AddFastEndpoints();

            // Add Swagger for FastEndpoints
            builder.Services.AddSwaggerGen();

            // Add DbContext with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Authorization
            builder.Services.AddAuthorization();

            // Add Repositories and Services
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IClassRepository, ClassRepository>();
            builder.Services.AddScoped<IClassService, ClassService>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddScoped<IMarkRepository, MarkRepository>();
            builder.Services.AddScoped<IMarkService, MarkService>();


            // Register Midlware 
            builder.Services.AddScoped<GlobalExceptionHandlerMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseFastEndpoints();

            app.Run();
        }
    }
}


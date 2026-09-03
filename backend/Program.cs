using Microsoft.EntityFrameworkCore;
using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Repositories;
using SampleProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Database connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresCon")
    )
);

// Dependency Injection
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<IRole, RoleService>();
builder.Services.AddScoped<IUserRole, UserRoleService>();
builder.Services.AddScoped<ICountry, CountryService>();
builder.Services.AddScoped<IState, StateService>();
builder.Services.AddScoped<ICity, CityService>();
builder.Services.AddScoped<IAddress, AddressService>();
builder.Services.AddScoped<IUserProfile, UserProfileService>();
builder.Services.AddScoped<IPatient, PatientService>();
builder.Services.AddScoped<ISpecialization, SpecializationService>();
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<ITreatmentType, TreatmentTypeService>();
builder.Services.AddScoped<IExercise, ExerciseService>();
builder.Services.AddScoped<IPatientMedicalHistory, PatientMedicalHistoryService>();
builder.Services.AddScoped<IPatientDocument, PatientDocumentService>();
builder.Services.AddScoped<IAppointmentType, AppointmentTypeService>();
builder.Services.AddScoped<IAppointment, AppointmentService>();
builder.Services.AddScoped<ITreatmentSession, TreatmentSessionService>();
builder.Services.AddScoped<IPatientAssessment, PatientAssessmentService>();
builder.Services.AddScoped<ITreatmentPlan, TreatmentPlanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
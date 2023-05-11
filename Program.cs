using CovidSystem.BL;
using CovidSystem.BL.Interfaces;
using CovidSystem.Controllers;
using CovidSystem.DB;
using CovidSystem.DL;
using CovidSystem.DL.Interfaces;
using CovidSystem.Validators.Patient;
using CovidSystem.Validators.Patient.Interfaces;
using CovidSystem.Validators.User;
using CovidSystem.Validators.User.Interfaces;
using CovidSystem.Validators.Vaccination;
using CovidSystem.Validators.Vaccination.Interfaces;
using CovidSystem.Validators.Validation;
using CovidSystem.Validators.Validation.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CovidDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
builder.Services.AddTransient<IUserDL,UserDL>();
builder.Services.AddTransient<IPatientDL, PatientDL>();
builder.Services.AddTransient<IVaccinationDL, VaccinationDL>();
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<IPatientBL, PatientBL>();
builder.Services.AddTransient<IVaccinationBL, VaccinationBL>();
builder.Services.AddTransient<IBirthdateValidation, BirthdateValidation>();
builder.Services.AddTransient<IPhoneNumberValidation, PhoneNumberValidation>();
builder.Services.AddTransient<IIdNumberValidation, IdNumberValidation>();
builder.Services.AddTransient<IGetUserValidator, GetUserValidator>();
builder.Services.AddTransient<IGetPatientValidator, GetPatientValidator>();
builder.Services.AddTransient<IGetVaccinationValidator, GetVaccinationValidator>();
builder.Services.AddTransient<IAddUserValidator, AddUserValidator>();
builder.Services.AddTransient<IAddPatientValidator, AddPatientValidator>();
builder.Services.AddTransient<IAddVaccinationValidator, AddVaccinationValidator>();
builder.Services.AddTransient<IStartEndCovidValidation, StartEndCovidValidation>();
builder.Services.AddTransient<IIsUserExistValidation, IsUserExistValidation>();
builder.Services.AddTransient<IIsPatientExistValidation, IsPatientExistValidation>();
builder.Services.AddTransient<IDateValidation, DateValidation>();


builder.Services.AddCors(options => options.AddPolicy(
    name: "AllowOrigin",
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
    ));

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

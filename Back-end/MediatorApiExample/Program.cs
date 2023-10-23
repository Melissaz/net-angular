using MediatorApiExample.MediatorExtensions;
using MediatorApiExample.Services;
using MediatorApiExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") //testing purpose
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// builder.Services.AddTransient<IHolidayService, GoogleCalendarHolidayService>();
builder.Services.AddTransient<IHolidayService, MockGoogleCalendarHolidayService>();
// builder.Services.AddTransient<IJiraService, JiraService>();
builder.Services.AddTransient<IJiraService, MockJiraService>();
builder.Services.AddTransient<ITeamMemberService, MockTeamMemberService>();
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddMediatorCQRS();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGenNewtonsoftSupport(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run("https://localhost:7205"); //testing purpose

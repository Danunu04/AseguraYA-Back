var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------
// 1) Controllers
// ------------------------------------------
builder.Services.AddControllers();

// ------------------------------------------
// 2) Swagger
// ------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ------------------------------------------
// 3) Authorization
// ------------------------------------------
builder.Services.AddAuthorization();

// ------------------------------------------
// 4) CORS para Angular
// ------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// ------------------------------------------
// 5) Middlewares
// ------------------------------------------
app.UseCors("AllowAngular");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// ------------------------------------------
// 6) Controllers
// ------------------------------------------
app.MapControllers();

app.Run();

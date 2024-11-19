//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});

//app.UseCors("AllowAngular");


//app.UseAuthorization();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//app.Run();



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Add CORS policy before building the application.
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowAngular", builder =>
////    {
////        builder.WithOrigins("http://localhost:4200")
////               .AllowAnyHeader()
////               .AllowAnyMethod();
////    });
////});

//builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
//{
//    builder
//        .AllowAnyHeader()
//        .AllowAnyMethod()
//        .SetIsOriginAllowed((host) => true)
//        .AllowCredentials();
//}));

//var app = builder.Build();

//// Configure static file serving
//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Use CORS policy
//app.UseCors("AllowAngular");

//app.UseAuthorization();

//app.MapControllers();

//// Map fallback to support Angular routing
//app.MapFallbackToFile("/index.html");

//app.Run();



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy BEFORE building the app.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Replace with your Angular URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable static files for serving Angular builds if necessary.
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply the CORS policy globally.
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();

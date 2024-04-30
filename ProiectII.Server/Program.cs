using MongoDB.Driver;

string mongoConnectionString = "mongodb+srv://Pasca18:18082002@cluster0.rb5prvj.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
var client = new MongoClient(mongoConnectionString);
var database = client.GetDatabase("ProiectII");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

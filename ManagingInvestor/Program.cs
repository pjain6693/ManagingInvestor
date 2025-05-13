using ManagingInvestor.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<InvestorDbContext>(provider =>
{
    var db = new InvestorDbContext();
    db.Initialize();
    return db;
});
builder.Services.AddControllers();
//builder.Services.AddDbContext<InvestorDbContext>(options =>
//    options.UseInMemoryDatabase("InvestorsDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<InvestorDbContext>();
//    DbInitializer.Seed(context);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

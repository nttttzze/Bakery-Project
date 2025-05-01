using Microsoft.EntityFrameworkCore;
using mormorsBageri;
using mormorsBageri.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite("Data Source=supplier.db");
} );

// Hittade detta som en lösning för att kunna göra en post för ny Order.
// Annars blev det en loop som inte tog slut och då kunde jag inte göra en post.
// + få bort extra rader med $id och $values från postman. Vet faktiskt inte varför det blev så,
// .
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

});


// // Hanterar CORS felet
// WithOrigins("http://127.0.0.1:5501") in production for security.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.LoadProducts(context);
    await Seed.LoadSuppliers(context);
    await Seed.LoadSP(context);
}
catch (Exception e)
{
    Console.WriteLine("{0}", e.Message);
    throw;
}

app.UseCors("AllowAll");

app.MapControllers();

app.Run();

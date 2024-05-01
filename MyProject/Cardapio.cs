using NSwag.AspNetCore;
using Comidas.Models;
using Comidas.Data;

class HelloWeb
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "TodoAPI";
            config.Title = "TodoAPI v1";
            config.Version = "v1";
        });

        builder.Services.AddDbContext<AppDbContext>();

        WebApplication app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseOpenApi();
            app.UseSwaggerUi(config =>
            {
                config.DocumentTitle = "Cardápio API";
                config.Path = "/swagger";
                config.DocumentPath = "/swagger/{documentName}/swagger.json";
                config.DocExpansion = "list";
            });
        }

        app.MapGet("/api/Comidas", (AppDbContext context) =>
        {
            return Results.Ok(context.Comidas.ToList());
        });

        app.MapPut("/api/Comidas", (AppDbContext context, Comida inputComida) =>
        {
             var comida = context.Comidas.Find(inputComida.Id);

                if (comida == null) return Results.NotFound();

                var entry = context.Entry(comida).CurrentValues;

                entry.SetValues(inputComida);
                context.SaveChanges();

                return Results.Ok(comida);

        }).Produces<Comida>();

        app.MapPost("/api/Comidas", (AppDbContext context, string name, string creator, bool frutosMar) =>
        {
            var newComida = new Comida(Guid.NewGuid(), name, creator, frutosMar);
            context.Comidas.Add(newComida);
            context.SaveChanges(); // Salva as alterações no banco de dados
            return Results.Ok(newComida);
        }).Produces<Comida>();

        app.MapDelete("/api/Comidas", (AppDbContext context, Guid id) =>
        {
            var comidaToRemove = context.Comidas.FirstOrDefault(c => c.Id == id);
            if (comidaToRemove != null)
            {
                context.Comidas.Remove(comidaToRemove);
                context.SaveChanges(); // Salva as alterações no banco de dados
                return Results.Ok(comidaToRemove);
            }

            return Results.NotFound();
        }).Produces<Comida>();

        app.MapPatch("/api/Comidas/{id}", (AppDbContext context, Guid id, bool frutosMar) =>
        {
            var existingComida = context.Comidas.FirstOrDefault(c => c.Id == id);
            if (existingComida == null)
            {
                return Results.NotFound();
            }

            // Atualiza apenas as propriedades fornecidas na comida atualizada

            existingComida.FrutosMar = frutosMar;


            context.SaveChanges(); // Salva as alterações no banco de dados

            return Results.Ok(existingComida);
        }).Produces<Comida>();

        app.Run();
    }
}


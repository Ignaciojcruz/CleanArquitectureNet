using CleanArquitectureNet.Data;
using CleanArquitectureNet.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
//QueryStreaming();
//await AddNewRecords();
await QueryFilter();

Console.WriteLine("Presione cualquier tecla para terminar");
Console.ReadKey();

async Task QueryFilter()
{
    Console.WriteLine("Ingrese una compañia de streaming");
    var streamingNombre = Console.ReadLine();

    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre == streamingNombre).ToListAsync();

    foreach (var item in streamers)
    {
        Console.WriteLine($"{item.Id} - {item.Nombre}" );
    }

    //var streamerPartialResults = await dbContext!.Streamers!.Where(x => x.Nombre!.Contains(streamingNombre)).ToListAsync();
    var streamerPartialResults = await dbContext!.Streamers!.Where(x => EF.Functions.Like(x.Nombre, $"%{ streamingNombre}%")).ToListAsync();
    foreach (var item in streamerPartialResults)
    {
        Console.WriteLine($"{item.Id} - {item.Nombre}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($" {streamer.Id} - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video
        {
            Nombre = "La Cenicienta",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre = "1001 Dalmatas",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre = "El Jorobado de Notredame",
            StreamerId = streamer.Id,
        },
        new Video
        {
            Nombre = "Starwars",
            StreamerId = streamer.Id,
        },
    };

    await dbContext.AddRangeAsync(movies);
    await dbContext.SaveChangesAsync();
}
using CleanArquitectureNet.Data;
using CleanArquitectureNet.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
//QueryStreaming();
//await AddNewRecords();
//await QueryFilter();
//await QueryLinq();
await TrackingAndNotTracking();

Console.WriteLine("Presione cualquier tecla para terminar");
Console.ReadKey();


async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext!.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await dbContext!.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon plus";

    await dbContext!.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine($"Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre, $"%{streamerNombre}%")
                           select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    var firstAsync = await streamer.Where(x => x.Nombre.Contains("a")).FirstAsync();

    var firstOrDefaultAsync = await streamer.Where(x => x.Nombre.Contains("a")).FirstOrDefaultAsync();

    var firstOrDefaultAsync_v2 = await streamer.FirstOrDefaultAsync(x => x.Nombre.Contains("a"));

    var singleAsync = await streamer.Where(x => x.Id == 1).SingleAsync();

    var singleOrDefaulAsync = await streamer.Where(x => x.Id == 1).SingleOrDefaultAsync();


    var resultado = await streamer.FindAsync(1);
}

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
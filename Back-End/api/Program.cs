using infrastructure;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
    // dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
// builder.Services.AddSingleton<Repository>();
// builder.Services.AddSingleton<Service>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/*
var frontEndRelativePath = "../../../Fromt-end/my-app/www";

builder.Services.AddSpaStaticFiles(
    configuration => { configuration.RootPath = frontEndRelativePath; });
    */
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
//app.UseMiddleware<GlobalExceptionHandler>();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
/*
app.UseSpaStaticFiles(new StaticFileOptions()
 {
     OnPrepareResponse = ctx =>
     {
        const int durationInSeconds = 60 * 60 * 24;
        ctx.Context.Response.Headers[HeaderNames.CacheControl] =
            "public,max-age=" + durationInSeconds;
    }
});

app.Map($"/{frontEndRelativePath}", (IApplicationBuilder frontendApp) => 
{
    frontendApp.UseSpa(spa => { spa.Options.SourcePath = "../../../Fromt-end/my-app/www"; });
});


app.UseSpa(conf =>
{
    conf.Options.SourcePath = frontEndRelativePath;
});
*/


app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});
//app.UseSpaStaticFiles();

//app.UseSpa(conf => { conf.Options.SourcePath = frontEndRelativePath; });
app.MapControllers();

app.Run();
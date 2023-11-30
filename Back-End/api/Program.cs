using api.Extensions;
using api.Middleware;
using infrastructure;
using infrastructure.Data.Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

/*
var frontEndRelativePath = "../../../Fromt-end/my-app/www";

builder.Services.AddSpaStaticFiles(
    configuration => { configuration.RootPath = frontEndRelativePath; });
    */
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandler>();

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
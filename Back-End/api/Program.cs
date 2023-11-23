using infrastructure;
using infrastructure.Data.Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());

builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<UserService>();

builder.Services.AddSingleton<CourseRepository>();
builder.Services.AddSingleton<CourseService>();

builder.Services.AddSingleton<AvatarImageRepository>();
builder.Services.AddSingleton<AvatarImageService>();

builder.Services.AddSingleton<CourseEnrollRepository>();
builder.Services.AddSingleton<CourseEnrollService>();


builder.Services.AddSingleton<CourseLevelService>();
builder.Services.AddSingleton<CourseLevelRepository>();

builder.Services.AddSingleton<ResourcesService>();
builder.Services.AddSingleton<ResourcesRepository>();


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
using api.Extensions;
using api.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5001",
            //ValidAudience = "http://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Secret"))
        };
    });

/*
var frontEndRelativePath = "../../../Fromt-end/my-app/www";

builder.Services.AddSpaStaticFiles(
    configuration => { configuration.RootPath = frontEndRelativePath; });
    */
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

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

using Application.Commands.Authors;
using Application.Commands.Books;
using Application.Commands.Genres;
using Application.Commands.Users;
using Application.Email;
using Application;
using Implementation.Commands.Authors;
using Implementation.Commands.Books;
using Implementation.Commands.Genres;
using Implementation.Commands.Users;
using Implementation.Email;
using Implementation.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Api.Core;
using EFDataAccess;
using Implementation.Validators;
using Application.Commands.UseCases;
using Implementation.Commands.UseCases;
using Microsoft.OpenApi.Models;
using Application.Queries.UseCases;
using Implementation.Queries.UseCases;
using Implementation.Commands.ShippingMethods;
using Application.Commands.ShippingMethods;
using Application.Queries.ShippingMethods;
using Implementation.Queries.ShippingMethods;
using Implementation.Commands.Roles;
using Application.Commands.Roles;
using Application.Queries.Roles;
using Implementation.Queries.Roles;
using Application.Queries.Genres;
using Implementation.Queries.Genres;
using Application.Queries.Authors;
using Implementation.Queries.Authors;
using Application.Queries.Books;
using Implementation.Queries.Books;
using Application.Queries.Users;
using Implementation.Queries.Users;
using Implementation.Commands.Orders;
using Application.Commands.Orders;
using Application.Queries.Orders;
using Implementation.Queries.Orders;
using Implementation.Profiles;
using Implementation.Queries.Logs;
using Application.Queries.Logs;
using Implementation.Commands.Logs;
using Implementation.Commands.Languages;
using Application.Commands.Languages;
using Application.Queries.Languages;
using Implementation.Queries.Languages;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null)
    {
        var unauthorisedUser = new JwtActor
        {
            RoleId = 3,
            Email = "Unauthorised actor",
            UserId = 3,
            AllowedUseCases = new List<int> { 19 }
        };

        return unauthorisedUser;
    }

    var actorString = user.FindFirst("ActorData").Value;

    var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

    return actor;
});
builder.Services.AddTransient<UseCaseExecutor>();
builder.Services.AddTransient<DBKnjizaraContext>();
builder.Services.AddTransient<IUseCaseLogger, SQLLogger>();
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

builder.Services.AddTransient<DBKnjizaraContext>();

#region AutoMapper
builder.Services.AddAutoMapper(typeof(EfCreateBook).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateAuthor).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateGenre).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateUser).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateUseCase).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateShippingMethod).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateRole).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateOrder).Assembly); 
builder.Services.AddAutoMapper(typeof(EfCreateLog).Assembly); 
builder.Services.AddAutoMapper(typeof(EfCreateLanguage).Assembly); 
#endregion

#region UseCase
builder.Services.AddTransient<IAddUseCaseCommand, EfCreateUseCase>();
builder.Services.AddTransient<IEditUseCaseCommand, EfUpdateUseCase>();
builder.Services.AddTransient<IDeleteUseCaseCommand, EfDeleteUseCase>();
builder.Services.AddTransient<IGetUseCaseQuery, EfGetUseCase>();
builder.Services.AddTransient<IGetUseCasesQuery, EfGetUseCases>();
#endregion

#region ShippingMethod
builder.Services.AddTransient<IAddShippingMethodCommand, EfCreateShippingMethod>();
builder.Services.AddTransient<IEditShippingMethodCommand, EfUpdateShippingMethod>();
builder.Services.AddTransient<IDeleteShippingMethodCommand, EfDeleteShippingMethod>();
builder.Services.AddTransient<IGetShippingMethodQuery, EfGetShippingMethod>();
builder.Services.AddTransient<IGetShippingMethodsQuery, EfGetShippingMethods>();
#endregion

#region Role
builder.Services.AddTransient<IAddRoleCommand, EfCreateRole>();
builder.Services.AddTransient<IEditRoleCommand, EfUpdateRole>();
builder.Services.AddTransient<IDeleteRoleCommand, EfDeleteRole>();
builder.Services.AddTransient<IGetRoleQuery, EfGetRole>();
builder.Services.AddTransient<IGetRolesQuery, EfGetRoles>();
#endregion

#region Authors
builder.Services.AddTransient<IAddAuthorCommand, EfCreateAuthor>();
builder.Services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthor>();
builder.Services.AddTransient<IEditAuthorCommand, EfUpdateAuthor>();
builder.Services.AddTransient<IGetAuthorsQuery, EfGetAuthors>();
builder.Services.AddTransient<IGetAuthorQuery, EfGetAuthor>();
#endregion

#region Genres
builder.Services.AddTransient<IDeleteGenreCommand, EfDeleteGenre>();
builder.Services.AddTransient<IAddGenreCommand, EfCreateGenre>();
builder.Services.AddTransient<IEditGenreCommand, EfUpdateGenre>();
builder.Services.AddTransient<IGetGenresQuery, EfGetGenres>();
builder.Services.AddTransient<IGetGenreQuery, EfGetGenre>();
#endregion

#region Books
builder.Services.AddTransient<IAddBookCommand, EfCreateBook>();
builder.Services.AddTransient<IDeleteBookCommand, EfDeleteBook>();
builder.Services.AddTransient<IEditBookCommand, EfUpdateBook>();
builder.Services.AddTransient<IGetBookQuery, EfGetBook>();
builder.Services.AddTransient<IGetBooksQuery, EfGetBooks>();
#endregion

#region Users
builder.Services.AddTransient<IAddUserCommand, EfCreateUser>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUser>();
builder.Services.AddTransient<IEditUserCommand, EfUpdateUser>();
builder.Services.AddTransient<IGetUsersQuery, EfGetUsers>();
builder.Services.AddTransient<IGetUserQuery, EfGetUser>();
#endregion

#region Orders
builder.Services.AddTransient<IAddOrderCommand, EfCreateOrder>();
builder.Services.AddTransient<IDeleteOrderCommand, EfDeleteOrder>();
builder.Services.AddTransient<IEditOrderCommand, EfUpdateOrder>();
builder.Services.AddTransient<IGetOrdersQuery, EfGetOrders>();
builder.Services.AddTransient<IGetOrderQuery, EfGetOrder>();
#endregion

#region Logs
builder.Services.AddTransient<IGetLogsQuery, EfGetLogs>();
#endregion

#region Languages
builder.Services.AddTransient<IAddLanguageCommand, EfCreateLanguage>();
builder.Services.AddTransient<IDeleteLanguageCommand, EfDeleteLanguage>();
builder.Services.AddTransient<IEditLanguageCommand, EfUpdateLanguage>();
builder.Services.AddTransient<IGetLanguagesQuery, EfGetLanguages>();
builder.Services.AddTransient<IGetLanguageQuery, EfGetLanguage>();
#endregion

#region Validators
builder.Services.AddTransient<BookDTOValidator>();
builder.Services.AddTransient<BookInsertDTOValidator>();
builder.Services.AddTransient<BookUpdateDTOValidator>();
builder.Services.AddTransient<AuthorDTOValidator>();
builder.Services.AddTransient<GenreDTOValidator>();
builder.Services.AddTransient<UserDTOValidator>();
builder.Services.AddTransient<UserInsertDTOValidator>();
builder.Services.AddTransient<UserUpdateDTOValidator>();
builder.Services.AddTransient<LogDTOValidator>();
builder.Services.AddTransient<RoleDTOValidator>();
builder.Services.AddTransient<ShippingMethodDTOValidator>();
builder.Services.AddTransient<UseCaseDTOValidator>();
builder.Services.AddTransient<OrderDTOValidator>();
builder.Services.AddTransient<OrderInsertDTOValidator>();
builder.Services.AddTransient<LanguageDTOValidator>();
#endregion


builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "asp_api",
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

app.MapControllers();


app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();

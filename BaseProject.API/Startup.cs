using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using BaseProject.API.ApiUtilities;
using BaseProject.Application.Security;
using BaseProject.Infrastructure;
using BaseProject.Application;
using BaseProject.Infrastructure.Migrations.Migrators;
using Microsoft.AspNetCore.Authorization;

namespace BaseProject.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = new AppSettings();
            Configuration.GetSection("AppSettings").Bind(appSettings);
            services.AddSingleton<AppSettings>(appSettings);
            services.AddScoped<ApiExceptionFilterAttribute>();

            services.AddApplication();
            services.AddInfraestructure(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy(name: "all", policy =>
                {
                    policy.WithOrigins("*")
                    .WithHeaders("*")
                    .WithMethods("*");
                });
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiExceptionFilterAttribute>();
            })
            .AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                o.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                o.AllowInputFormatterExceptionMessages = true;
            });

            services.AddApiVersioning();

            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Base API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the beares scheme \r\n\r\n Enter 'Bearer'and your token."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference    = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.AddHttpContextAccessor();

            services.AddSingleton(Configuration);

            services.AddHttpClient();

            // Configurar la autenticación JWT
            var key = Encoding.ASCII.GetBytes(appSettings.Authentication.Jwtkey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    // ValidIssuer = appSettings.Authentication.JwtIssuer,
                    ValidateAudience = false,
                    //ValidAudience = "https://localhost:44324",
                    //ValidIssuer = "https://localhost:44324",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    //  ClockSkew = TimeSpan.Zero
                };
            });
            AddAuthorization(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            //masanzaz - remove UseSwagger for prod
            app.UseSwagger();
            app.UseSwaggerUI();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.SeedTranslationsData();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors("all");

            app.UseAuthentication(); // Usar middleware de autenticación JWT
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}"
                );
            });
        }

        public static void AddAuthorization(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });
        }
    }
}
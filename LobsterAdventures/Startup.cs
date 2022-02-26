using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.BLL.Implementations;
using LobsterAdventures.DAL;
using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.DAL.Implementations;
using LobsterAdventures.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LobsterAdventures
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LobsterAdventures", Version = "v1" });
            });
            services.AddTransient<IAdventureService, AdventureService>();
            services.AddTransient<IAdventureRepository<Adventure>, AdventureRepository>();
            services.AddTransient<IDecisionService<DecisionQuery>, DecisionService>();
            services.AddTransient<IDecisionRepository<DecisionQuery>, DecisionRepository>();
            services.AddTransient<IPlayerService<Player>, PlayerService>();
            services.AddTransient<IPlayerRepository<Player>, PlayerRepository>();
            services.AddDbContext<MyContext>(opt => opt.UseInMemoryDatabase("MyAdventures"));
            services.AddControllers().AddJsonOptions(x =>
             x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LobsterAdventures v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MyContext>();
            AddTestData(context);
        }

        private static void AddTestData(MyContext context)
        {
            var adventure1 = new Adventure
            {
                AdventureId = 1,
                Name = "Adventure - 1"

            };
            context.Adventures.Add(adventure1);
            var player1 = new Player
            {
                PlayerId = 1
            };
            context.Players.Add(player1);

            var dq7 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 7,
                NegativeId = null,
                PositiveId = null,
                ParentId = 4,
                Title = "We are Sorry , we hope to serve you better next time :("
            };

            var dq6 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 6,
                NegativeId = null,
                PositiveId = null,
                ParentId = 4,
                Title = "Thats Great , Do visit us again !!  :)"
            };

            var dq5 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 5,
                NegativeId = 5,
                PositiveId = 4,
                ParentId = 2,
                Title = "Sorry we dont have anything else.. See you later . Bye !!"
            };

            var dq4 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 4,
                NegativeId = 7,
                PositiveId = 6,
                ParentId = 2,
                Title = "Is the coffee Good ?"
            };

            var dq3 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 3,
                Negative = null,
                Positive = null,
                ParentId = 1,
                Title = "Bye Bye ?"
            };
            var dq2 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 2,
                NegativeId = 5,
                PositiveId = 4,
                ParentId = 1,
                Title = "Do you want a coffee ?"
            };
            var dq1 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 1,
                NegativeId = 3,
                PositiveId = 2,
                ParentId = null,
                Title = "Are you ready to start your adventure ?"
            };
            context.DecisionQueries.Add(dq1);
            context.DecisionQueries.Add(dq2);
            context.DecisionQueries.Add(dq3);
            context.DecisionQueries.Add(dq4);
            context.DecisionQueries.Add(dq5);
            context.DecisionQueries.Add(dq6);
            context.DecisionQueries.Add(dq7);
            context.SaveChanges();
        }
    }
}

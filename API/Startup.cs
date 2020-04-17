using API.Context;
using API.Models;
using API.Repositories;
using API.Repositories.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddDbContext<ArtClubContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));

			services.AddTransient<IRepository<Admin>, Repository<Admin>>();
			services.AddTransient<IRepository<Course>, Repository<Course>>();
			services.AddTransient<IRepository<Event>, Repository<Event>>();
			services.AddTransient<IRepository<HistoryPart>, Repository<HistoryPart>>();
			services.AddTransient<IRepository<Member>, Repository<Member>>();
			services.AddTransient<IRepository<Resource>, Repository<Resource>>();
			services.AddTransient<IRepository<Room>, Repository<Room>>();
			services.AddTransient<IRepository<Trainer>, Repository<Trainer>>();
			services.AddTransient<IRepository<TrainerCourse>, Repository<TrainerCourse>>();
			services.AddTransient<IRepository<User>, Repository<User>>();

			services.AddTransient<IMemberCourseRepository, MemberCourseRepository>();

			services.AddTransient<UnitOfWork>();
			services.AddTransient<UserService>();
			services.AddTransient<MemberService>();
            services.AddTransient<TrainerService>();
            services.AddTransient<RoomService>();
            services.AddTransient<CourseService>();
            services.AddTransient<EventService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}

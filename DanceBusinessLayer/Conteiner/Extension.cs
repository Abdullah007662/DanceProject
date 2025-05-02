using DanceBusinessLayer.Abstract;
using DanceBusinessLayer.Concrete;
using DanceDataAccessLayer.Abstract;
using DanceDataAccessLayer.EntityFrameWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceBusinessLayer.Conteiner
{
	public static class Extension
	{
		public static void ConteinerDependencies(this IServiceCollection Services)
		{
			Services.AddScoped<IAboutDal, EfAboutDal>();
			Services.AddScoped<IAboutService, AboutManager>();
		}
	}
}

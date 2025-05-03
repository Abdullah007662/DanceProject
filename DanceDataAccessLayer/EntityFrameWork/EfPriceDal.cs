using DanceDataAccessLayer.Abstract;
using DanceDataAccessLayer.Concrete;
using DanceDataAccessLayer.Repositories;
using DanceEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceDataAccessLayer.EntityFrameWork
{
	public class EfPriceDal : GenericRepository<Price>, IPriceDal
	{
		public EfPriceDal(DanceContext context) : base(context)
		{
		}
	}
}

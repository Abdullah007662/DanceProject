using DanceBusinessLayer.Abstract;
using DanceDataAccessLayer.Abstract;
using DanceEntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceBusinessLayer.Concrete
{
	public class LocationManager : ILocationService
	{
		private readonly ILocationDal _locationDal;

		public LocationManager(ILocationDal locationDal)
		{
			_locationDal = locationDal;
		}

		public void BAdd(Location entity)
		{
			_locationDal.Add(entity);
		}

		public void BDelete(Location entity)
		{
			_locationDal.Delete(entity);
		}

		public Location BGetById(int id)
		{
			return _locationDal.GetById(id);
		}

		public List<Location> BGetListAll()
		{
			return _locationDal.GetListAll();
		}

		public void BUpdate(Location entity)
		{
			_locationDal.Update(entity);
		}
	}
}

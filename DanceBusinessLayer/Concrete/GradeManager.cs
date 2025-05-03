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
	public class GradeManager : IGradeService
	{
		private readonly IGradeDal _gradeDal;

		public GradeManager(IGradeDal gradeDal)
		{
			_gradeDal = gradeDal;
		}

		public void BAdd(Grade entity)
		{
			_gradeDal.Add(entity);
		}

		public void BDelete(Grade entity)
		{
			_gradeDal.Delete(entity);
		}

		public Grade BGetById(int id)
		{
			return _gradeDal.GetById(id);
		}

		public List<Grade> BGetListAll()
		{
			return _gradeDal.GetListAll();
		}

		public void BUpdate(Grade entity)
		{
			_gradeDal.Update(entity);
		}
	}
}

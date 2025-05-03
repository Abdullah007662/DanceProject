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
	public class PriceManager : IPriceService
	{
		private readonly IPriceDal _priceDal;

		public PriceManager(IPriceDal priceDal)
		{
			_priceDal = priceDal;
		}

		public void BAdd(Price entity)
		{
			_priceDal.Add(entity);
		}

		public void BDelete(Price entity)
		{
			_priceDal.Delete(entity);
		}

		public Price BGetById(int id)
		{
			return _priceDal.GetById(id);
		}

		public List<Price> BGetListAll()
		{
			return _priceDal.GetListAll();
		}

		public void BUpdate(Price entity)
		{
			_priceDal.Update(entity);
		}
	}
}

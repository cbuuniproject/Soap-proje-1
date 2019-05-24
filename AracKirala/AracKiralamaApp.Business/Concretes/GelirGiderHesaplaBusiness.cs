using AracKiralamaApp.DAL;
using AracKiralamaApp.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{

	public class GelirGiderHesaplaBusiness
	{
		public List<Gelir> gelirHesapla(int sirketId)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					return unitOfWork.GelirGiderHesapla.gelirleriListele(sirketId);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:AracBusiness::InsertArac::Error occured.", ex);
			}
		}

		public List<Gider> giderHesapla()
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					return unitOfWork.GelirGiderHesapla.giderList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:AracBusiness::InsertArac::Error occured.", ex);
			}
		}
	}
}

using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class HarcamaTuruBusiness:IDisposable
	{
		public bool InsertHarcamaTuru(HarcamaTuru entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.HarcamaTuruRepository.Add(entity);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:HarcamaTuruBusiness::InsertHarcamaTuru::Error occured.", ex);
			}
		}

		public bool DeleteHarcamaTuruById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.HarcamaTuruRepository.Remove(ID);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:HarcamaTuruBusiness::DeleteHarcamaTuruById::Error occured.", ex);
			}
		}

		public HarcamaTuru SelectHarcamaTuruById(int HarcamaTuruId)
		{
			try
			{
				HarcamaTuru responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.HarcamaTuruRepository.GetById(HarcamaTuruId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:HarcamaTuruBusiness::SelectHarcamaTuruById::Error occured.", ex);
			}
		}

		public List<HarcamaTuru> SelectAllHarcamaTurus()
		{
			var responseEntities = new List<HarcamaTuru>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.HarcamaTuruRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:HarcamaTuruBusiness::SelectAllHarcamaTurus::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

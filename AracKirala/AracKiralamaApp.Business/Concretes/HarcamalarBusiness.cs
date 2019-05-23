using AracKiralamaApp.Domains;
using AracKiralamaApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class HarcamalarBusiness : IDisposable
	{
		public bool insertHarcama(Harcamalar entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.HarcamalarRepository.Add(entity);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:AracBusiness::InsertArac::Error occured.", ex);
			}
		}

		public bool DeleteHarcamaById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.HarcamalarRepository.Remove(ID);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:AracBusiness::DeleteAracById::Error occured.", ex);
			}
		}

		public Harcamalar SelectHarcamaById(int HarcamaId)
		{
			try
			{
				Harcamalar responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.HarcamalarRepository.GetById(HarcamaId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:AracBusiness::SelectAracById::Error occured.", ex);
			}
		}

		public List<Harcamalar> SelectAllHarcamalar()
		{
			var responseEntities = new List<Harcamalar>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.HarcamalarRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:AracBusiness::SelectAllAracs::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

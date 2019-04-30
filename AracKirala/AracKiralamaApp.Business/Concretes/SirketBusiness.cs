using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class SirketBusiness :IDisposable
	{
		public void InsertSirket(Sirket entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.SirketRepository.Add(entity);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:SirketBusiness::InsertSirket::Error occured.", ex);
			}
		}

		public void DeleteSirketById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.SirketRepository.Remove(ID);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:SirketBusiness::DeleteSirket::Error occured.", ex);
			}
		}

		public Sirket SelectSirketById(int sirketId)
		{
			try
			{
				Sirket responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity= unitOfWork.SirketRepository.GetById(sirketId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:SirketBusiness::SelectSirketById::Error occured.", ex);
			}
		}

		public List<Sirket> SelectAllSirkets()
		{
			var responseEntities = new List<Sirket>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.SirketRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:SirketBusiness::SelectAllSirkets::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

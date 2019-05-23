using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class AracBusiness : IDisposable
	{
		public bool InsertArac(Arac entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.AracRepository.Add(entity);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:AracBusiness::InsertArac::Error occured.",ex);
			}
		}

		public bool DeleteAracById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.AracRepository.Remove(ID);
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

		public Arac SelectAracById(int AracId)
		{
			try
			{
				Arac responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.AracRepository.GetById(AracId);
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

		public List<Arac> SelectAllAracs()
		{
			var responseEntities = new List<Arac>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.AracRepository.GetAll())
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

using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class CalisanBusiness : IDisposable
	{
		public void InsertCalisan(Calisan entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.CalisanRepository.Add(entity);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:CalisanBusiness::InsertCalisan::Error occured.", ex);
			}
		}

		public void DeleteCalisanById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.CalisanRepository.Remove(ID);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:CalisanBusiness::DeleteCalisanById::Error occured.", ex);
			}
		}

		public Calisan SelectCalisanById(int calisanId)
		{
			try
			{
				Calisan responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.CalisanRepository.GetById(calisanId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:CalisanBusiness::SelectCalisanById::Error occured.", ex);
			}
		}

		public List<Calisan> SelectAllCalisans()
		{
			var responseEntities = new List<Calisan>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.CalisanRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:CalisanBusiness::SelectAllCalisans::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

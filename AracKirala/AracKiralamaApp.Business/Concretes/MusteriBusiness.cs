using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class MusteriBusiness : IDisposable
	{
		public bool InsertMusteri(Musteri entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.MusteriRepository.Add(entity);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:MusteriBusiness::InsertMusteri::Error occured.", ex);
			}
		}

		public bool DeleteMusteriById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.MusteriRepository.Remove(ID);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:MusteriBusiness::DeleteMusteriById::Error occured.", ex);
			}
		}

		public Musteri SelectMusteriById(int MusteriId)
		{
			try
			{
				Musteri responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.MusteriRepository.GetById(MusteriId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:MusteriBusiness::SelectMusteriById::Error occured.", ex);
			}
		}

		public List<Musteri> SelectAllMusteris()
		{
			var responseEntities = new List<Musteri>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.MusteriRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:MusteriBusiness::SelectAllMusteris::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

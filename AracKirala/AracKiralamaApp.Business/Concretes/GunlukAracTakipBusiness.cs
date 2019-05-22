using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class GunlukAracTakipBusiness:IDisposable
	{
		public void InsertGunlukAracTakip(GunlukAracTakip entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.GunlukAracTakipRepository.Add(entity);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:GunlukAracTakipBusiness::InsertGunlukAracTakip::Error occured.", ex);
			}
		}

		public void DeleteGunlukAracTakipById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.GunlukAracTakipRepository.Remove(ID);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:GunlukAracTakipBusiness::DeleteGunlukAracTakipById::Error occured.", ex);
			}
		}

		public GunlukAracTakip SelectGunlukAracTakipById(int GunlukAracTakipId)
		{
			try
			{
				GunlukAracTakip responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.GunlukAracTakipRepository.GetById(GunlukAracTakipId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:GunlukAracTakipBusiness::SelectGunlukAracTakipById::Error occured.", ex);
			}
		}

		public List<GunlukAracTakip> SelectAllGunlukAracTakips()
		{
			var responseEntities = new List<GunlukAracTakip>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.GunlukAracTakipRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:GunlukAracTakipBusiness::SelectAllGunlukAracTakips::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

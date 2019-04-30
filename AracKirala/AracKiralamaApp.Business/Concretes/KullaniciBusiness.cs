using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{

	public class KullaniciBusiness : IDisposable
	{
		public void InsertKullanici(Kullanici entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.KullaniciRepository.Add(entity);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KullaniciBusiness::InsertKullanici::Error occured.", ex);
			}
		}

		public void DeleteKullaniciById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.KullaniciRepository.Remove(ID);
					unitOfWork.Complete();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KullaniciBusiness::DeleteKullaniciById::Error occured.", ex);
			}
		}

		public bool KullaniciDogrulama(string username, string pass)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					bool isUserValid= unitOfWork.KullaniciRepository.sifreDogrulama(username, pass);
					unitOfWork.Complete();
					if (isUserValid)
					{
						return true;
					}
					else
						return false;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KullaniciBusiness::InsertKullanici::Error occured.", ex);
			}
		}

		public Kullanici SelectKullaniciById(int KullaniciId)
		{
			try
			{
				Kullanici responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.KullaniciRepository.GetById(KullaniciId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KullaniciBusiness::SelectKullaniciById::Error occured.", ex);
			}
		}

		public List<Kullanici> SelectAllKullanicis()
		{
			var responseEntities = new List<Kullanici>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.KullaniciRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KullaniciBusiness::SelectAllKullanicis::Error occured.", ex);
			}
		}
		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

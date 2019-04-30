using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class KiralamaBusiness:IDisposable
	{
		public bool InsertKiralama(Kiralama entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.KiralamaRepository.Add(entity);
					unitOfWork.Complete();
                    return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KiralamaBusiness::InsertKiralama::Error occured.", ex);
                return false;
			}
		}

		public bool DeleteKiralamaById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.KiralamaRepository.Remove(ID);
					unitOfWork.Complete();
                    return true;
				}
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KiralamaBusiness::DeleteKiralamaById::Error occured.", ex);
                return false;
			}
		}

		public Kiralama SelectKiralamaById(int KiralamaId)
		{
			try
			{
				Kiralama responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.KiralamaRepository.GetById(KiralamaId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KiralamaBusiness::SelectKiralamaById::Error occured.", ex);
			}
		}

		public List<Kiralama> SelectAllKiralamas()
		{
			var responseEntities = new List<Kiralama>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.KiralamaRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:KiralamaBusiness::SelectAllKiralamas::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Business.Concretes
{
	public class RolBusiness:IDisposable
	{
		public bool InsertRol(Rol entity)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.RolRepository.Add(entity);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:RolBusiness::InsertRol::Error occured.", ex);
			}
		}

		public bool DeleteRolById(int ID)
		{
			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					unitOfWork.RolRepository.Remove(ID);
					unitOfWork.Complete();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw new Exception("BusinessLogic:RolBusiness::DeleteRolById::Error occured.", ex);
			}
		}

		public Rol SelectRolById(int RolId)
		{
			try
			{
				Rol responseEntity;
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					responseEntity = unitOfWork.RolRepository.GetById(RolId);
					if (responseEntity == null)
						throw new NullReferenceException("Customer doesnt exists!");
					unitOfWork.Complete();
				}
				return responseEntity;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:RolBusiness::SelectRolById::Error occured.", ex);
			}
		}

		public List<Rol> SelectAllRols()
		{
			var responseEntities = new List<Rol>();

			try
			{
				using (var unitOfWork = new UnitOfWork(new AracKiralamaContext()))
				{
					foreach (var entity in unitOfWork.RolRepository.GetAll())
					{
						responseEntities.Add(entity);
					}
				}
				return responseEntities;
			}
			catch (Exception ex)
			{
				throw new Exception("BusinessLogic:RolBusiness::SelectAllRols::Error occured.", ex);
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}

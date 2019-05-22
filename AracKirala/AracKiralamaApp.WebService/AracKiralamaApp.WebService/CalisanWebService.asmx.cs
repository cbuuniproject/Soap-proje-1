using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AracKiralamaApp.WebService
{
	/// <summary>
	/// Summary description for CalisanWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class CalisanWebService : System.Web.Services.WebService
	{


		[WebMethod]
		public bool InsertCalisan(Calisan entity)
		{
			try
			{
				using (CalisanBusiness calisanBusiness = new CalisanBusiness())
				{
					calisanBusiness.InsertCalisan(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteCalisan(int calisanId)
		{
			try
			{
				using (CalisanBusiness calisanBusiness = new CalisanBusiness())
				{
					calisanBusiness.DeleteCalisanById(calisanId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Calisan> SelectAllCalisans()
		{
			try
			{
				using (CalisanBusiness calisanBusiness = new CalisanBusiness())
				{
					return calisanBusiness.SelectAllCalisans();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Calisan SelectCalisanById(int calisanId)
		{
			try
			{
				using (CalisanBusiness calisanBusiness = new CalisanBusiness())
				{
					return calisanBusiness.SelectCalisanById(calisanId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

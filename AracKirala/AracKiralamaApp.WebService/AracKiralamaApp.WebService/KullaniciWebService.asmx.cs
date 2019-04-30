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
	/// Summary description for KullaniciWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class KullaniciWebService : System.Web.Services.WebService
	{

		[WebMethod]
		public bool InsertKullanici(Kullanici entity)
		{
			try
			{
				using (KullaniciBusiness kullaniciBusiness = new KullaniciBusiness())
				{
					kullaniciBusiness.InsertKullanici(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteKullanici(int kullaniciId)
		{
			try
			{
				using (KullaniciBusiness kullaniciBusiness = new KullaniciBusiness())
				{
					kullaniciBusiness.DeleteKullaniciById(kullaniciId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Kullanici> SelectAllKullanicis()
		{
			try
			{
				using (KullaniciBusiness kullaniciBusiness = new KullaniciBusiness())
				{
					return kullaniciBusiness.SelectAllKullanicis();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Kullanici SelectKullaniciById(int kullaniciId)
		{
			try
			{
				using (KullaniciBusiness kullaniciBusiness = new KullaniciBusiness())
				{
					return kullaniciBusiness.SelectKullaniciById(kullaniciId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

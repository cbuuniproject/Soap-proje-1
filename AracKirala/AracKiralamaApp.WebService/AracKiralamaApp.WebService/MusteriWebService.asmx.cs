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
	/// Summary description for MusteriWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class MusteriWebService : System.Web.Services.WebService
	{

		[WebMethod]
		public bool InsertMusteri(Musteri entity)
		{
			try
			{
				using (MusteriBusiness musteriBusiness = new MusteriBusiness())
				{
					musteriBusiness.InsertMusteri(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteMusteri(int musteriId)
		{
			try
			{
				using (MusteriBusiness musteriBusiness = new MusteriBusiness())
				{
					musteriBusiness.DeleteMusteriById(musteriId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Musteri> SelectAllMusteris()
		{
			try
			{
				using (MusteriBusiness musteriBusiness = new MusteriBusiness())
				{
					return musteriBusiness.SelectAllMusteris();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Musteri SelectMusteriById(int musteriId)
		{
			try
			{
				using (MusteriBusiness musteriBusiness = new MusteriBusiness())
				{
					return musteriBusiness.SelectMusteriById(musteriId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

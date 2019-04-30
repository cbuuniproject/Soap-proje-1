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
	/// Summary description for KiralamaWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class KiralamaWebService : System.Web.Services.WebService
	{
		[WebMethod]
		public bool InsertKiralama(Kiralama entity)
		{
			try
			{
				using (KiralamaBusiness kiralamaBusiness = new KiralamaBusiness())
				{
					kiralamaBusiness.InsertKiralama(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteKiralama(int kiralamaId)
		{
			try
			{
				using (KiralamaBusiness kiralamaBusiness = new KiralamaBusiness())
				{
					kiralamaBusiness.DeleteKiralamaById(kiralamaId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Kiralama> SelectAllKiralamas()
		{
			try
			{
				using (KiralamaBusiness kiralamaBusiness = new KiralamaBusiness())
				{
					return kiralamaBusiness.SelectAllKiralamas();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Kiralama SelectKiralamaById(int kiralamaId)
		{
			try
			{
				using (KiralamaBusiness kiralamaBusiness = new KiralamaBusiness())
				{
					return kiralamaBusiness.SelectKiralamaById(kiralamaId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

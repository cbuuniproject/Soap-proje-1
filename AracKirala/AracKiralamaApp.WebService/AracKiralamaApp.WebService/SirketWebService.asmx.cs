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
	/// Summary description for SirketWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class SirketWebService : System.Web.Services.WebService
	{

		[WebMethod]
		public bool InsertSirket(Sirket entity)
		{
			try
			{
				using (SirketBusiness sirketBusiness = new SirketBusiness())
				{
					sirketBusiness.InsertSirket(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteSirket(int sirketId)
		{
			try
			{
				using (SirketBusiness sirketBusiness = new SirketBusiness())
				{
					sirketBusiness.DeleteSirketById(sirketId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Sirket> SelectAllSirkets()
		{
			try
			{
				using (SirketBusiness sirketBusiness = new SirketBusiness())
				{
					return sirketBusiness.SelectAllSirkets();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Sirket SelectSirketById(int sirketId)
		{
			try
			{
				using (SirketBusiness sirketBusiness = new SirketBusiness())
				{
					return sirketBusiness.SelectSirketById(sirketId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

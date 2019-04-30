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
	/// Summary description for AracWebService
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class AracWebService : System.Web.Services.WebService
	{
		[WebMethod]
		public bool InsertArac(Arac entity)
		{
			try
			{
				using (AracBusiness aracBusiness = new AracBusiness())
				{
					aracBusiness.InsertArac(entity);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public bool DeleteArac(int aracId)
		{
			try
			{
				using (AracBusiness aracBusiness = new AracBusiness())
				{
					aracBusiness.DeleteAracById(aracId);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		[WebMethod]
		public List<Arac> SelectAllAracs()
		{
			try
			{
				using (AracBusiness aracBusiness = new AracBusiness())
				{
					return aracBusiness.SelectAllAracs();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		[WebMethod]
		public Arac SelectAracById(int aracId)
		{
			try
			{
				using (AracBusiness aracBusiness = new AracBusiness())
				{
					return aracBusiness.SelectAracById(aracId);
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}

using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.Domains;
using AracKiralamaApp.WebApi_.Models;
using AracKiralamaApp.WebApi_.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiralamaApp.WebApi_.Controllers
{
    public class CalisanController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var calisanBusiness = new CalisanBusiness())
			{
				// Get customers from business layer (Core App)
				List<Calisan> calisanlar = calisanBusiness.SelectAllCalisans();

				// Prepare a content
				var content = new ResponseContent<Calisan>(calisanlar);

				// Return content as a json and proper http response
				return new StandartResult<Calisan>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Calisan> content;

			using (var calisanBusiness = new CalisanBusiness())
			{
				// Get customer from business layer (Core App)
				List<Calisan> calisans = null;
				try
				{
					var c = calisanBusiness.SelectCalisanById(id);
					if (c != null)
					{
						calisans = new List<Calisan>();
						calisans.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Calisan>(calisans);

					// Return content as a json and proper http response
					return new XmlResult<Calisan>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Calisan>(null);
					return new XmlResult<Calisan>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Calisan calisan)
		{
			var content = new ResponseContent<Calisan>(null);
			if (calisan != null)
			{
				using (var calisanBusiness = new CalisanBusiness())
				{
					content.Result = calisanBusiness.InsertCalisan(calisan) ? "1" : "0";

					return new StandartResult<Calisan>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Calisan>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Calisan>(null);

			using (var calisanBusiness = new CalisanBusiness())
			{
				content.Result = calisanBusiness.DeleteCalisanById(id) ? "1" : "0";

				return new StandartResult<Calisan>(content, Request);
			}
		}
	}
}

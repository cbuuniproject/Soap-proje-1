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
    public class HarcamaTuruController : ApiController
    {

		public IHttpActionResult Get()
		{
			using (var harcamaTuruBusiness = new HarcamaTuruBusiness())
			{
				// Get customers from business layer (Core App)
				List<HarcamaTuru> harcamaTurular = harcamaTuruBusiness.SelectAllHarcamaTurus();

				// Prepare a content
				var content = new ResponseContent<HarcamaTuru>(harcamaTurular);

				// Return content as a json and proper http response
				return new StandartResult<HarcamaTuru>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<HarcamaTuru> content;

			using (var harcamaTuruBusiness = new HarcamaTuruBusiness())
			{
				// Get customer from business layer (Core App)
				List<HarcamaTuru> harcamaTurus = null;
				try
				{
					var c = harcamaTuruBusiness.SelectHarcamaTuruById(id);
					if (c != null)
					{
						harcamaTurus = new List<HarcamaTuru>();
						harcamaTurus.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<HarcamaTuru>(harcamaTurus);

					// Return content as a json and proper http response
					return new XmlResult<HarcamaTuru>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<HarcamaTuru>(null);
					return new XmlResult<HarcamaTuru>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]HarcamaTuru harcamaTuru)
		{
			var content = new ResponseContent<HarcamaTuru>(null);
			if (harcamaTuru != null)
			{
				using (var harcamaTuruBusiness = new HarcamaTuruBusiness())
				{
					content.Result = harcamaTuruBusiness.InsertHarcamaTuru(harcamaTuru) ? "1" : "0";

					return new StandartResult<HarcamaTuru>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<HarcamaTuru>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<HarcamaTuru>(null);

			using (var harcamaTuruBusiness = new HarcamaTuruBusiness())
			{
				content.Result = harcamaTuruBusiness.DeleteHarcamaTuruById(id) ? "1" : "0";

				return new StandartResult<HarcamaTuru>(content, Request);
			}
		}
	}
}

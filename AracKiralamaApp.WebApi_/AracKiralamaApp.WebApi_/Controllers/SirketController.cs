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
    public class SirketController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var sirketBusiness = new SirketBusiness())
			{
				// Get customers from business layer (Core App)
				List<Sirket> sirketlar = sirketBusiness.SelectAllSirkets();

				// Prepare a content
				var content = new ResponseContent<Sirket>(sirketlar);

				// Return content as a json and proper http response
				return new StandartResult<Sirket>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Sirket> content;

			using (var sirketBusiness = new SirketBusiness())
			{
				// Get customer from business layer (Core App)
				List<Sirket> sirkets = null;
				try
				{
					var c = sirketBusiness.SelectSirketById(id);
					if (c != null)
					{
						sirkets = new List<Sirket>();
						sirkets.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Sirket>(sirkets);

					// Return content as a json and proper http response
					return new XmlResult<Sirket>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Sirket>(null);
					return new XmlResult<Sirket>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Sirket sirket)
		{
			var content = new ResponseContent<Sirket>(null);
			if (sirket != null)
			{
				using (var sirketBusiness = new SirketBusiness())
				{
					content.Result = sirketBusiness.InsertSirket(sirket) ? "1" : "0";

					return new StandartResult<Sirket>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Sirket>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Sirket>(null);

			using (var sirketBusiness = new SirketBusiness())
			{
				content.Result = sirketBusiness.DeleteSirketById(id) ? "1" : "0";

				return new StandartResult<Sirket>(content, Request);
			}
		}
	}
}

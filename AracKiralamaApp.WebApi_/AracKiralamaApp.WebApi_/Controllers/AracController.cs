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
    public class AracController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var aracBusiness = new AracBusiness())
			{
				// Get customers from business layer (Core App)
				List<Arac> araclar = aracBusiness.SelectAllAracs();

				// Prepare a content
				var content = new ResponseContent<Arac>(araclar);

				// Return content as a json and proper http response
				return new StandartResult<Arac>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Arac> content;

			using (var aracBusiness = new AracBusiness())
			{
				// Get customer from business layer (Core App)
				List<Arac> aracs = null;
				try
				{
					var c = aracBusiness.SelectAracById(id);
					if (c != null)
					{
						aracs = new List<Arac>();
						aracs.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Arac>(aracs);

					// Return content as a json and proper http response
					return new XmlResult<Arac>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Arac>(null);
					return new XmlResult<Arac>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Arac arac)
		{
			var content = new ResponseContent<Arac>(null);
			if (arac != null)
			{
				using (var aracBusiness = new AracBusiness())
				{
					content.Result = aracBusiness.InsertArac(arac) ? "1" : "0";

					return new StandartResult<Arac>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Arac>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Arac>(null);

			using (var aracBusiness = new AracBusiness())
			{
				content.Result = aracBusiness.DeleteAracById(id) ? "1" : "0";

				return new StandartResult<Arac>(content, Request);
			}
		}
	}
}

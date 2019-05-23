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
    public class KiralamaBusinessController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var kiralamaBusiness = new KiralamaBusiness())
			{
				// Get customers from business layer (Core App)
				List<Kiralama> kiralamalar = kiralamaBusiness.SelectAllKiralamas();

				// Prepare a content
				var content = new ResponseContent<Kiralama>(kiralamalar);

				// Return content as a json and proper http response
				return new StandartResult<Kiralama>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Kiralama> content;

			using (var kiralamaBusiness = new KiralamaBusiness())
			{
				// Get customer from business layer (Core App)
				List<Kiralama> kiralamas= null;
				try
				{
					var c = kiralamaBusiness.SelectKiralamaById(id);
					if (c != null)
					{
						kiralamas = new List<Kiralama>();
						kiralamas.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Kiralama>(kiralamas);

					// Return content as a json and proper http response
					return new XmlResult<Kiralama>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Kiralama>(null);
					return new XmlResult<Kiralama>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Kiralama kiralama)
		{
			var content = new ResponseContent<Kiralama>(null);
			if (kiralama != null)
			{
				using (var kiralamaBusiness = new KiralamaBusiness())
				{
					content.Result = kiralamaBusiness.InsertKiralama(kiralama) ? "1" : "0";

					return new StandartResult<Kiralama>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Kiralama>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Kiralama>(null);

			using (var kiralamaBusiness = new KiralamaBusiness())
			{
				content.Result = kiralamaBusiness.DeleteKiralamaById(id) ? "1" : "0";

				return new StandartResult<Kiralama>(content, Request);
			}
		}
    }
}

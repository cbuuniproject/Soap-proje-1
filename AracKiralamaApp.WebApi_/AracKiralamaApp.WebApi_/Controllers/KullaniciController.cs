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
    public class KullaniciController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				// Get customers from business layer (Core App)
				List<Kullanici> kullanicilar = kullaniciBusiness.SelectAllKullanicis();

				// Prepare a content
				var content = new ResponseContent<Kullanici>(kullanicilar);

				// Return content as a json and proper http response
				return new StandartResult<Kullanici>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Kullanici> content;

			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				// Get customer from business layer (Core App)
				List<Kullanici> kullanicis= null;
				try
				{
					var c = kullaniciBusiness.SelectKullaniciById(id);
					if (c != null)
					{
						kullanicis = new List<Kullanici>();
						kullanicis.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Kullanici>(kullanicis);

					// Return content as a json and proper http response
					return new XmlResult<Kullanici>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Kullanici>(null);
					return new XmlResult<Kullanici>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Kullanici kullanici)
		{
			var content = new ResponseContent<Kullanici>(null);
			if (kullanici != null)
			{
				using (var kullaniciBusiness = new KullaniciBusiness())
				{
					content.Result = kullaniciBusiness.InsertKullanici(kullanici) ? "1" : "0";

					return new StandartResult<Kullanici>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Kullanici>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Kullanici>(null);

			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				content.Result = kullaniciBusiness.DeleteKullaniciById(id) ? "1" : "0";

				return new StandartResult<Kullanici>(content, Request);
			}
		}

	}
}

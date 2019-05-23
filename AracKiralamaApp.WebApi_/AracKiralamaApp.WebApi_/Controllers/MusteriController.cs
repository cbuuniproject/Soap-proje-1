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
    public class MusteriController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var musteriBusiness = new MusteriBusiness())
			{
				// Get customers from business layer (Core App)
				List<Musteri> musterilar = musteriBusiness.SelectAllMusteris();

				// Prepare a content
				var content = new ResponseContent<Musteri>(musterilar);

				// Return content as a json and proper http response
				return new StandartResult<Musteri>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Musteri> content;

			using (var musteriBusiness = new MusteriBusiness())
			{
				// Get customer from business layer (Core App)
				List<Musteri> musteris = null;
				try
				{
					var c = musteriBusiness.SelectMusteriById(id);
					if (c != null)
					{
						musteris = new List<Musteri>();
						musteris.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Musteri>(musteris);

					// Return content as a json and proper http response
					return new XmlResult<Musteri>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Musteri>(null);
					return new XmlResult<Musteri>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Musteri musteri)
		{
			var content = new ResponseContent<Musteri>(null);
			if (musteri != null)
			{
				using (var musteriBusiness = new MusteriBusiness())
				{
					content.Result = musteriBusiness.InsertMusteri(musteri) ? "1" : "0";

					return new StandartResult<Musteri>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Musteri>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Musteri>(null);

			using (var musteriBusiness = new MusteriBusiness())
			{
				content.Result = musteriBusiness.DeleteMusteriById(id) ? "1" : "0";

				return new StandartResult<Musteri>(content, Request);
			}
		}
	}
}

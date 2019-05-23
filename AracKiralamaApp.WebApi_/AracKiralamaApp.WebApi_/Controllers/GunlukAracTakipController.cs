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
    public class GunlukAracTakipController : ApiController
    {
			public IHttpActionResult Get()
		{
			using (var gunlukAracTakipBusiness = new GunlukAracTakipBusiness())
			{
				// Get customers from business layer (Core App)
				List<GunlukAracTakip> gunlukAracTakiplar = gunlukAracTakipBusiness.SelectAllGunlukAracTakips();

				// Prepare a content
				var content = new ResponseContent<GunlukAracTakip>(gunlukAracTakiplar);

				// Return content as a json and proper http response
				return new StandartResult<GunlukAracTakip>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<GunlukAracTakip> content;

			using (var gunlukAracTakipBusiness = new GunlukAracTakipBusiness())
			{
				// Get customer from business layer (Core App)
				List<GunlukAracTakip> gunlukAracTakips= null;
				try
				{
					var c = gunlukAracTakipBusiness.SelectGunlukAracTakipById(id);
					if (c != null)
					{
						gunlukAracTakips = new List<GunlukAracTakip>();
						gunlukAracTakips.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<GunlukAracTakip>(gunlukAracTakips);

					// Return content as a json and proper http response
					return new XmlResult<GunlukAracTakip>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<GunlukAracTakip>(null);
					return new XmlResult<GunlukAracTakip>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]GunlukAracTakip gunlukAracTakip)
		{
			var content = new ResponseContent<GunlukAracTakip>(null);
			if (gunlukAracTakip != null)
			{
				using (var gunlukAracTakipBusiness = new GunlukAracTakipBusiness())
				{
					content.Result = gunlukAracTakipBusiness.InsertGunlukAracTakip(gunlukAracTakip) ? "1" : "0";

					return new StandartResult<GunlukAracTakip>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<GunlukAracTakip>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<GunlukAracTakip>(null);

			using (var gunlukAracTakipBusiness = new GunlukAracTakipBusiness())
			{
				content.Result = gunlukAracTakipBusiness.DeleteGunlukAracTakipById(id) ? "1" : "0";

				return new StandartResult<GunlukAracTakip>(content, Request);
			}
		}
    }
}

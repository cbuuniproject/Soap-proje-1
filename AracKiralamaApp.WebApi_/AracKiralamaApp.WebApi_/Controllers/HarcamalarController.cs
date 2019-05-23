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
    public class HarcamalarController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var harcamalarBusiness = new HarcamalarBusiness())
			{
				// Get customers from business layer (Core App)
				List<Harcamalar> harcamalarlar = harcamalarBusiness.SelectAllHarcamalar();

				// Prepare a content
				var content = new ResponseContent<Harcamalar>(harcamalarlar);

				// Return content as a json and proper http response
				return new StandartResult<Harcamalar>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Harcamalar> content;

			using (var harcamalarBusiness = new HarcamalarBusiness())
			{
				// Get customer from business layer (Core App)
				List<Harcamalar> harcamalars = null;
				try
				{
					var c = harcamalarBusiness.SelectHarcamaById(id);
					if (c != null)
					{
						harcamalars = new List<Harcamalar>();
						harcamalars.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Harcamalar>(harcamalars);

					// Return content as a json and proper http response
					return new XmlResult<Harcamalar>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Harcamalar>(null);
					return new XmlResult<Harcamalar>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Harcamalar harcamalar)
		{
			var content = new ResponseContent<Harcamalar>(null);
			if (harcamalar != null)
			{
				using (var harcamalarBusiness = new HarcamalarBusiness())
				{
					content.Result = harcamalarBusiness.insertHarcama(harcamalar) ? "1" : "0";

					return new StandartResult<Harcamalar>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Harcamalar>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Harcamalar>(null);

			using (var harcamalarBusiness = new HarcamalarBusiness())
			{
				content.Result = harcamalarBusiness.DeleteHarcamaById(id) ? "1" : "0";

				return new StandartResult<Harcamalar>(content, Request);
			}
		}
	}
}

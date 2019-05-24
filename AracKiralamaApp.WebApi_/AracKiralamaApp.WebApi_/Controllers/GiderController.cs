using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.DAL.Repositories.Concrete;
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
    public class GiderController : ApiController
    {
		public IHttpActionResult Get()
		{
			List<Gider> giderler = new List<Gider>();
			var giderBusiness = new GelirGiderHesaplaBusiness();

			// Get customers from business layer (Core App)
			giderler = giderBusiness.giderHesapla();

			// Prepare a content
			var content = new ResponseContent<Gider>(giderler);

			// Return content as a json and proper http response
			return new StandartResult<Gider>(content, Request);

		}
	}
}

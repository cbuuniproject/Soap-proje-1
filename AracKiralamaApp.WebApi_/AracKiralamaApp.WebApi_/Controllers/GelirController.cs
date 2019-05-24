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
	public class GelirController : ApiController
	{
		public IHttpActionResult Get(int sirketId)
		{
			List<Gelir> gelirler = new List<Gelir>();
			var gelirBusiness = new GelirGiderHesaplaBusiness();

			// Get customers from business layer (Core App)
			gelirler = gelirBusiness.gelirHesapla(sirketId);

			// Prepare a content
			var content = new ResponseContent<Gelir>(gelirler);

			// Return content as a json and proper http response
			return new StandartResult<Gelir>(content, Request);

		}
	}
}

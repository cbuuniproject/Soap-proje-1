using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.Domains;
using AracKiralamaApp.WebApi.Models;
using AracKiralamaApp.WebApi.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiralamaApp.WebApi.Controllers
{
    public class KullaniciController : ApiController
    {
		// GET api/<controller>
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

		public bool sifreDogrula(string kullaniciAdi,string pass)
		{
			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				return kullaniciBusiness.KullaniciDogrulama(kullaniciAdi, pass);
			}
		}
	}
}

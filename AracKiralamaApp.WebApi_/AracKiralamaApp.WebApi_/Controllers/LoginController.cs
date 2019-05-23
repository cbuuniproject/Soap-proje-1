using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.WebApi_.Models;
using AracKiralamaApp.WebApi_.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiralamaApp.WebApi.Controllers
{
    public class LoginController : ApiController
    {
		public IHttpActionResult Get(string kullaniciAdi, string pass)
		{
			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				bool dogruMu = kullaniciBusiness.KullaniciDogrulama(kullaniciAdi, pass);
				SifreDogrulama dogrulama = new SifreDogrulama { isValid = dogruMu };
				List<SifreDogrulama> sifreDogrulama = new List<SifreDogrulama>();
				sifreDogrulama.Add(dogrulama);

				var content = new ResponseContent<SifreDogrulama>(sifreDogrulama);

				// Return content as a json and proper http response
				return new StandartResult<SifreDogrulama>(content, Request);

			}
		}

		
	}
}

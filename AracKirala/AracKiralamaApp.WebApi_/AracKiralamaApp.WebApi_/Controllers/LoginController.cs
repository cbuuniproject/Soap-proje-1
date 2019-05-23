using AracKiralamaApp.Business.Concretes;
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
		public bool sifreDogrula(string kullaniciAdi, string pass)
		{
			using (var kullaniciBusiness = new KullaniciBusiness())
			{
				return kullaniciBusiness.KullaniciDogrulama(kullaniciAdi, pass);
			}
		}
	}
}

using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Abstract
{
	public interface IKullaniciRepository : IRepository<Kullanici>
	{
		bool sifreDogrulama(string username, string pass);
		int maxKullaniciId();
		Kullanici idAl(string username);
		void AddWithHash(Kullanici kullanici);
	}
}

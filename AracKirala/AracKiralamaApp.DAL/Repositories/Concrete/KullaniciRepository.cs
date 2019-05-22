using AracKiralamaApp.DAL.Repositories.Abstract;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
	{
		public KullaniciRepository(AracKiralamaContext context) : base(context)
		{

		}
		protected AracKiralamaContext AracKiralamaContext { get { return _context as AracKiralamaContext; } }

		public Kullanici idAl(string username)
		{
			Kullanici kullanici = (Kullanici)_dbSet.Select(x => x.kullaniciAd == username);
			return kullanici;
		}

		

		public int maxKullaniciId()
		{
			return _dbSet.Max(x => x.kullaniciId);
		}

		public bool sifreDogrulama(string username,string pass)
		{
			var isUserValid = _dbSet.FirstOrDefault(x => x.kullaniciAd == username && x.parola == pass);
			if (isUserValid!=null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

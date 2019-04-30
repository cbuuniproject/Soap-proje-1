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

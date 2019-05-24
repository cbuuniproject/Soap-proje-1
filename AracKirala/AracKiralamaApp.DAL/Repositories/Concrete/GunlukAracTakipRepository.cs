using AracKiralamaApp.Domains;
using AracKiralamaApp.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class GunlukAracTakipRepository:Repository<GunlukAracTakip>, IGunlukAracTakipRepository
	{
		public GunlukAracTakipRepository(AracKiralamaContext context):base(context)
		{

		}
		protected AracKiralamaContext AracKiralamaContext { get { return _context as AracKiralamaContext; } }

		
	}
}

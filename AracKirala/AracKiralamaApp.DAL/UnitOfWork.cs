using AracKiralamaApp.DAL.Repositories.Abstract;
using AracKiralamaApp.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private AracKiralamaContext _aracKiralamaContext;

		public UnitOfWork(AracKiralamaContext context)
		{
			_aracKiralamaContext = context;
			SirketRepository = new SirketRepository(_aracKiralamaContext);
			CalisanRepository = new CalisanRepository(_aracKiralamaContext);
			AracRepository = new AracRepository(_aracKiralamaContext);
			KiralamaRepository = new KiralamaRepository(_aracKiralamaContext);
			MusteriRepository = new MusteriRepository(_aracKiralamaContext);
			KullaniciRepository = new KullaniciRepository(_aracKiralamaContext);
			HarcamaTuruRepository = new HarcamaTuruRepository(_aracKiralamaContext);
			RolRepository = new RolRepository(_aracKiralamaContext);
			GunlukAracTakipRepository = new GunlukAracTakipRepository(_aracKiralamaContext);
			HarcamalarRepository = new HarcamalarRepository(_aracKiralamaContext);
		}
		public ISirketRepository SirketRepository { get; private set; }

		public ICalisanRepository CalisanRepository { get; private set; }

		public IAracRepository AracRepository { get; private set; }

		public IKiralamaRepository KiralamaRepository { get; private set; }

		public IMusteriRepository MusteriRepository { get; private set; }

		public IKullaniciRepository KullaniciRepository { get; private set; }

		public IGunlukAracTakipRepository GunlukAracTakipRepository { get; private set; }

		public IRolRepository RolRepository { get; set; }

		public IHarcamalarRepository HarcamalarRepository { get; set; }

		public IHarcamaTuruRepository HarcamaTuruRepository { get; set; }

		public int Complete()
		{
			return _aracKiralamaContext.SaveChanges();
		}

		public void Dispose()
		{
			_aracKiralamaContext.Dispose();
		}
	}
}

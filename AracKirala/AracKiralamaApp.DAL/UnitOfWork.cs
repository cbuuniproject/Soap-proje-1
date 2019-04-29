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
		}
		public ISirketRepository SirketRepository { get; private set; }
		

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

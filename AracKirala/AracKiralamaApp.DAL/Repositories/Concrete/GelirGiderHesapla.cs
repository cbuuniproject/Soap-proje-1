using AracKiralamaApp.DAL.Repositories.Abstract;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class GelirGiderHesapla:IGelirGiderHesapla
	{
		protected DbContext _context;
		protected DbSet<Kiralama> _dbSetKiralama;
		protected DbSet<Harcamalar> _dbSetHarcamalar;
		protected DbSet<HarcamaTuru> _dbSetHarcamaTuru;


		public GelirGiderHesapla(DbContext context)
		{
			_context = context;
			_dbSetKiralama = _context.Set<Kiralama>();
			_dbSetHarcamalar = _context.Set<Harcamalar>();
			_dbSetHarcamaTuru = _context.Set<HarcamaTuru>();

		}

		public List<Gelir> gelirleriListele(int sirketId)
		{
			List<Gelir> gelirList = new List<Gelir>();
			decimal sum =(decimal)_dbSetKiralama.Where(d=>d.sirketId==sirketId).Sum(d => d.ucret);
			Gelir gelir = new Gelir();
			gelir.gelir = sum;
			gelir.gelirTuru = "Kiralama";
			gelirList.Add(gelir);
			return gelirList;
		}

		public List<Gider> giderList()
		{
			int toplam = 0;
			string harcamaTuru = "";
			List<Gider> giderList = new List<Gider>();
			List<int> a= _dbSetHarcamalar.Select(u => u.harcamaTuruId)
							.Distinct()
							.ToList();
			foreach (int item in a)
			{
				toplam = _dbSetHarcamalar.Where(d => d.harcamaId == item).Sum(d => d.ucret);
				harcamaTuru = _dbSetHarcamaTuru.Where(d => d.harcamaId == item).Select(s => s.harcamaTuru).FirstOrDefault();
				Gider gider = new Gider();
				gider.gider = toplam;
				gider.giderTuru = harcamaTuru;
			}
			return giderList;
		}
	}
}

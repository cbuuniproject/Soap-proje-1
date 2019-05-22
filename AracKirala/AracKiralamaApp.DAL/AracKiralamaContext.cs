using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL
{
	public class AracKiralamaContext : DbContext
	{
		public AracKiralamaContext() : base("AracKiralamaContext")
		{

		}
		public DbSet<Arac> aracs { get; set; }
		public DbSet<Calisan> calisans { get; set; }
		public DbSet<Kiralama> kiralamas { get; set; }
		public DbSet<Kullanici> kullanicis { get; set; }
		public DbSet<Musteri> musteris { get; set; }
		public DbSet<Sirket> sirkets { get; set; }
		public DbSet<Harcamalar> harcamalar { get; set; }
		public DbSet<GunlukAracTakip> gunlukAracTakips{ get; set; }
		public DbSet<HarcamaTuru> harcamaTuru{ get; set; }
		public DbSet<Rol> rols{ get; set; }
	}
}

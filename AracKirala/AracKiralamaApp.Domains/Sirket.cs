using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Domains
{
    public class Sirket
    {
		public Sirket()
		{
			araclar = new List<Arac>();
			kiralamalar = new List<Kiralama>();
		}
		[Key]
		[Column(Order = 1)]
		public int sirketId { get; set; }
		[StringLength(50)]
		public string sirketAdi { get; set; }
		[StringLength(50)]
		public string sehir{ get; set; }
		[StringLength(100)]
		public string adres { get; set; }
		public ushort aracSayisi { get; set; }
		public int? sirketPuani { get; set; }
		public ICollection<Arac>  araclar{ get; set; }
		public ICollection<Kiralama> kiralamalar { get; set; }
		public ICollection<Calisan> calisanlar { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Domains
{
	public class Harcamalar
	{
		public Harcamalar()
		{
			aciklama = "";
		}
		[Key]
		[Column(Order = 1)]
		public int harcamaId { get; set; }
		public int harcamaTuruId { get; set; }
		public string  aciklama { get; set; }
		public DateTime tarih { get; set; }
		public int ucret { get; set; }

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Domains
{
	public class GunlukAracTakip
	{
		public GunlukAracTakip()
		{

		}
		[Key]
		[Column(Order = 1)]
		public int takipId { get; set; }
		public int aracId { get; set; }
		public int kiralamaId { get; set; }
		public int gunlukGidilenKm { get; set; }
		public DateTime tarih { get; set; }
	}

}

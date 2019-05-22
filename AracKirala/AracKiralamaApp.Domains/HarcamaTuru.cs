using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.Domains
{
	public class HarcamaTuru
	{
		[Key]
		[Column(Order = 1)]
		public int harcamaId { get; set; }
		[StringLength(50)]
		public string harcamaTuru { get; set; }

	}
}

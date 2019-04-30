using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.DAL;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			KiralamaBusiness kiralamaBusiness = new KiralamaBusiness();
			kiralamaBusiness.InsertKiralama(new Kiralama() { aracId = 1, geriAlisTarihi = DateTime.Now, musteriId = 1, sirketId = 1, sonKm = 4500, verilisKm = 3900, ucret = 280, verilisTarihi = DateTime.Now });
			Console.WriteLine("oldu");
			Console.ReadKey();
		}
	}
}

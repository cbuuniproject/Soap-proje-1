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
			kiralamaBusiness.InsertKiralama(new Kiralama() { aracId = 1, geriAlisTarihi = DateTime.Now, musteriId = 1, sirketId = 1, sonKm = 4200, verilisKm = 4000, ucret = 160, verilisTarihi = DateTime.Now });
            if (kiralamaBusiness.DeleteKiralamaById(1))
            {
                Console.WriteLine("True");
            }
			Console.ReadKey();
		}
	}
}

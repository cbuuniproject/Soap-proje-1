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
			UnitOfWork unitOfWork = new UnitOfWork(new AracKiralamaContext());
			unitOfWork.SirketRepository.Add(new Sirket() { sirketAdi = "UbiSoft",adres="Bağcılar",aracSayisi=25,sehir="İstanbul", sirketPuani=50 });
			unitOfWork.Complete();
			System.Console.Write("Oldu");
			System.Console.ReadKey();
		}
	}
}

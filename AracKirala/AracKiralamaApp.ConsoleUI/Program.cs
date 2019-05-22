using AracKiralamaApp.Business.Concretes;
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
			KullaniciBusiness kullaniciBusiness = new KullaniciBusiness();
			List<Kullanici> kullanicis= kullaniciBusiness.SelectAllKullanicis();
			foreach (var item in kullanicis)
			{
				Console.WriteLine(item.kullaniciAd);
			}
			
			Console.Read();
		}
	}
}

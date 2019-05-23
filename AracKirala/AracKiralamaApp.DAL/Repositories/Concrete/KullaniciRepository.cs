using AracKiralamaApp.DAL.Repositories.Abstract;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class KullaniciRepository : Repository<Kullanici>, IKullaniciRepository
	{
		public KullaniciRepository(AracKiralamaContext context) : base(context)
		{

		}
		protected AracKiralamaContext AracKiralamaContext { get { return _context as AracKiralamaContext; } }

		public Kullanici idAl(string username)
		{
			Kullanici kullanici = (Kullanici)_dbSet.Select(x => x.kullaniciAd == username);
			return kullanici;
		}

		public void AddWithHash(Kullanici kullanici)
		{
			kullanici.parola = md5Sifrele(kullanici.parola);
			_dbSet.Add(kullanici);
		}

		public int maxKullaniciId()
		{
			return _dbSet.Max(x => x.kullaniciId);
		}

		public bool sifreDogrulama(string username, string pass)
		{
			var isUserValid = _dbSet.FirstOrDefault(x => x.kullaniciAd == username && x.parola == pass);
			if (isUserValid != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public string md5Sifrele(string sifre)
		{
			string hash = "www.emrekoyuncu.net";
			byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
			using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
			{
				byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
				using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
				{
					ICryptoTransform transform = tripDes.CreateEncryptor();
					byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
					return Convert.ToBase64String(results, 0, results.Length);
				}
			}
		}
	}
}

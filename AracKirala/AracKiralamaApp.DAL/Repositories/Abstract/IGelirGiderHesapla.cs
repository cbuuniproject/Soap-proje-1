﻿using AracKiralamaApp.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Abstract
{
	public interface IGelirGiderHesapla
	{
		List<Gelir> gelirleriListele(int sirketId);
		List<Gider> giderList();
	}
}
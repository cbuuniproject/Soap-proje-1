﻿using AracKiralamaApp.DAL.Repositories.Abstract;
using AracKiralamaApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralamaApp.DAL.Repositories.Concrete
{
	public class SirketRepository:Repository<Sirket>,ISirketRepository
	{
		public SirketRepository(AracKiralamaContext context):base(context)
		{
				
		}
		protected AracKiralamaContext PersonnelContext { get { return _context as AracKiralamaContext; } }
	}
}

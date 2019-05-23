using AracKiralamaApp.Business.Concretes;
using AracKiralamaApp.Domains;
using AracKiralamaApp.WebApi_.Models;
using AracKiralamaApp.WebApi_.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiralamaApp.WebApi_.Controllers
{
    public class RolController : ApiController
    {
		public IHttpActionResult Get()
		{
			using (var rolBusiness = new RolBusiness())
			{
				// Get customers from business layer (Core App)
				List<Rol> rollar = rolBusiness.SelectAllRols();

				// Prepare a content
				var content = new ResponseContent<Rol>(rollar);

				// Return content as a json and proper http response
				return new StandartResult<Rol>(content, Request);
			}
		}

		public IHttpActionResult Get(int id)
		{
			ResponseContent<Rol> content;

			using (var rolBusiness = new RolBusiness())
			{
				// Get customer from business layer (Core App)
				List<Rol> rols = null;
				try
				{
					var c = rolBusiness.SelectRolById(id);
					if (c != null)
					{
						rols = new List<Rol>();
						rols.Add(c);
					}

					// Prepare a content
					content = new ResponseContent<Rol>(rols);

					// Return content as a json and proper http response
					return new XmlResult<Rol>(content, Request);
				}
				catch (Exception)
				{
					// Prepare a content
					content = new ResponseContent<Rol>(null);
					return new XmlResult<Rol>(content, Request);
				}
			}
		}

		public IHttpActionResult Post([FromBody]Rol rol)
		{
			var content = new ResponseContent<Rol>(null);
			if (rol != null)
			{
				using (var rolBusiness = new RolBusiness())
				{
					content.Result = rolBusiness.InsertRol(rol) ? "1" : "0";

					return new StandartResult<Rol>(content, Request);
				}
			}

			content.Result = "0";

			return new StandartResult<Rol>(content, Request);
		}

		// DELETE api/<controller>/5
		public IHttpActionResult Delete(int id)
		{
			var content = new ResponseContent<Rol>(null);

			using (var rolBusiness = new RolBusiness())
			{
				content.Result = rolBusiness.DeleteRolById(id) ? "1" : "0";

				return new StandartResult<Rol>(content, Request);
			}
		}
	}
}

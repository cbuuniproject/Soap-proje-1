using AracKiralamaApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AracKiralamaApp.WebAPI.Results
{
	public class XmlResult<T> : StandartResult<T>, IHttpActionResult where T : class
	{

		public XmlResult(ResponseContent<T> data, HttpRequestMessage request) : base(data, request)
		{
		}

		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{

			var response = new HttpResponseMessage()
			{
				StatusCode = ConvertStatusCode(_data.Result),
				Content = new ObjectContent<ResponseContent<T>>(_data,
					new XmlMediaTypeFormatter { UseXmlSerializer = true }),
				RequestMessage = _request
			};
			return Task.FromResult(response);
		}
	}
}
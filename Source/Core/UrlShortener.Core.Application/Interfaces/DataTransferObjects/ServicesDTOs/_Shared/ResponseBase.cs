using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Application.Interfaces.DataTransferObjects.ServicesDTOs._Shared
{
	public class ResponseBase<TResponse>
	{
		public ResponseHeader Header { get; set; }
		public TResponse? ContentData { get; set; }
	}

	public class ResponseBase
	{
		public ResponseHeader Header { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Skeddly.Model;

namespace Skeddly
{
	public partial class SkeddlyClient : ISkeddlyClient
    {
		private Exception CreateLocalException(System.Net.HttpStatusCode statusCode, ErrorResponse errorResponse)
		{
			if (errorResponse != null)
			{
				if (errorResponse.ErrorCode == "CredentialNotFound")
					throw new CredentialNotFoundException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "InvalidRoleOrAccessDenied")
					return new InvalidRoleOrAccessDeniedException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "InvalidAccessKey")
					return new InvalidAccessKeyException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "ActionExecutionNotFound")
					return new ActionExecutionNotFoundException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "ActionNotFound")
					return new ActionNotFoundException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "UnauthorizedOperation")
					return new UnauthorizedOperationException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "ManagedInstanceGroupNotFound")
					return new ManagedInstanceGroupNotFoundException(errorResponse.Message);
				else if (errorResponse.ErrorCode == "TimeZoneNotFound")
					return new Model.TimeZoneNotFoundException(errorResponse.Message);
				return new SkeddlyWebException(statusCode, errorResponse.ErrorCode, errorResponse.Message);
			}
			else
			{
				return new SkeddlyWebException(statusCode, statusCode.ToString(), "An error has occurred: " + statusCode.ToString());
			}
		}
	}
}

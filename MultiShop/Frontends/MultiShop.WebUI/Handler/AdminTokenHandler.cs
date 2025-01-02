using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.WebUI.Services.Interface;
using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handler
{
	public class AdminTokenHandler : DelegatingHandler
	{
		private readonly IHttpContextAccessor _httpContext;
		private readonly IIdentityService _identityService;

		public AdminTokenHandler(IHttpContextAccessor httpContext, IIdentityService identityService)
		{
			_httpContext = httpContext;
			_identityService = identityService;
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var accessToken = await _httpContext.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

			if (!string.IsNullOrEmpty(accessToken))
			{
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
			}

			var response = await base.SendAsync(request, cancellationToken);

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				var refreshSuccess = await _identityService.GetRefreshTokenAdmin();

				if (refreshSuccess)
				{
					accessToken = await _httpContext.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

					if (!string.IsNullOrEmpty(accessToken))
					{
						request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
						response = await base.SendAsync(request, cancellationToken);
					}
				}
			}

			if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Redirect)
			{
				var responses = new HttpResponseMessage(HttpStatusCode.Redirect);
				responses.Headers.Location = new Uri("AdminLoginPanel/Index", UriKind.Relative);
				return responses;
			}

			return response;
		}
	}

}

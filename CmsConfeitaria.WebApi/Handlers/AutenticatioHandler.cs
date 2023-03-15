using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading;

namespace CmsConfeitaria.WebApi.Handlers
{
    public class AutenticatioHandler
    {
        private readonly RequestDelegate _next;

        public AutenticatioHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var identity = new GenericIdentity("Usuario");
            var principal = new GenericPrincipal(identity, new string[] { "admin" });

            Thread.CurrentPrincipal = principal;
            context.User = principal;

            var bytePassword = Encoding.ASCII.GetBytes("Usuario:123");
            string userSenha = Convert.ToBase64String(bytePassword);


            context.Request.Headers.Add("Authorization", $"Basic {userSenha}");

            await _next(context);
        }
    }

    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header missing.");
            }

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            if (authHeader.Scheme != "Basic")
            {
                return AuthenticateResult.Fail("Invalid authorization scheme.");
            }

            string[] credentials = new string[] { };

            credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter ?? string.Empty)).Split(':', 2);


            if (credentials.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid credentials.");
            }

            var username = credentials[0];
            var password = credentials[1];

            
            /*
             * Colocar aqui o metodo de autenticação do serviço
             *  */

            if (username != "validuser" || password != "validpassword")
            {
                return AuthenticateResult.Fail("Invalid username or password.");
            }
            /****************************************/


            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}

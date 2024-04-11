namespace BrickedUpBrickBuyer.CustomMiddleware
{
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public ContentSecurityPolicyMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Response.Headers.ContainsKey("Content-Security-Policy"))
            {
                context.Response.Headers.Add("Content-Security-Policy",
                 "default-src 'self';" +
                 "connect-src 'self';" );
            }
            await requestDelegate(context);
        }
    }
}

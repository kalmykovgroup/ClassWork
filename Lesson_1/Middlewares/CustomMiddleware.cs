namespace Lesson_1.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public CustomMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await _next(context);
        
            }
            catch (Exception ex) {

                if (!_env.IsDevelopment())
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Внутренняя ошибка сервера");
                }
                else
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync(ex.ToString());
                }
            }
          
        }
    }
}

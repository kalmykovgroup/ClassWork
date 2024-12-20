using System.Text.Json;
using System.Text.RegularExpressions;

namespace WebApplication1
{
      

    public class Program
    {
        static List<User> users = new List<User>
        {
            new() { Id = Guid.NewGuid().ToString(), Name = "vova", Email = "vova@mail.ru" },
            new() { Id = Guid.NewGuid().ToString(), Name = "Alice", Email = "alice@mail.ru" },
            new() { Id = Guid.NewGuid().ToString(), Name = "vova2", Email = "vova2@mail.ru" }
        };

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler();
            }

            //app.MapGet("/", void () => throw new Exception());
            app.Run(async (context) =>
            {
                var responce = context.Response;
                var request = context.Request;
                var path = request.Path;

                string expForGuid = @"^/api/users/\w{8}-\w{4}-\w{4}-\w{4}-\w{12}$";
                if (path == "/api/users" && request.Method == "GET")
                {
                   await GetAllPeople(responce);
                }
                else if (Regex.IsMatch(path, expForGuid) && request.Method == "GET")
                {
                    string? id = path.Value?.Split("/")[3];
                    await GetUser(id, responce);
                }
                else if (path == "/api/users" && request.Method == "PUT")
                {
                   await UpdateUser(responce, request);
                }
                else if (Regex.IsMatch(path, expForGuid) && request.Method == "Delete")
                {
                    string? id = path.Value?.Split("/")[3];
                    await DeleteUser(id, responce);
                }
                else
                {
                    responce.ContentType = "text/html; charset=utf-8";
                    await responce.SendFileAsync("html/index.html");
                }
            });

            app.Run();

            /*
             Results.File();
            Results.Byte();
            Results.Stream();
             */

       
        }

        static async Task GetAllPeople(HttpResponse response)
        { 
            response.ContentType = "application/json";
             
            response.StatusCode = 200;

            await response.WriteAsJsonAsync(JsonSerializer.Serialize<List<User>>(users));
        }

        static async Task GetUser(string id, HttpResponse response)
        { 
            response.ContentType = "application/json";

            response.StatusCode = 200;

            await response.WriteAsJsonAsync(JsonSerializer.Serialize<User?>(users.Where(u => u.Id == id).FirstOrDefault()));
        }

        static async Task UpdateUser(HttpResponse response, HttpRequest request)
        { 
            response.ContentType = "application/json";

            response.StatusCode = 200;

            await response.WriteAsJsonAsync(JsonSerializer.Serialize<List<User>>(users));
        }

        static async Task DeleteUser(string? id, HttpResponse response)
        {
            // Установить заголовок Content-Type
            response.ContentType = "application/json";
             

            User? user = users.Where(u => u.Id == id).FirstOrDefault();

            if (user != null) {
                users.Remove(user);

                response.StatusCode = 204;
                await response.WriteAsJsonAsync(JsonSerializer.Serialize<bool>(true));
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(JsonSerializer.Serialize<bool>(false));
            } 

        }
    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

  
}

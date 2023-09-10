


class Company
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string Specialization { get; set; }
    public int YearFounded { get; set; }
}



public class RoutingMiddleware

{

    readonly RequestDelegate next;

    public RoutingMiddleware(RequestDelegate next)

    {

        this.next = next;

    }

    public async Task InvokeAsync(HttpContext context)

    {

        string path = context.Request.Path;

        if (path == "/company")

        {

            Company myCompany = new Company
            {
                Name = "Apple",
                Country = "USA",
                Specialization = "Electronics",
                YearFounded = 1976
            };
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(myCompany));

        }

        else if (path == "/rand")

        {

            Random random = new Random();
            int randomNumber = random.Next(101);

            // Повертаємо випадкове число як текстову відповідь
            await context.Response.WriteAsync("Random number: "+randomNumber.ToString());

        }

        else

        {

            context.Response.StatusCode = 404;

            await context.Response.WriteAsync("Not Found");

        }

    }

}


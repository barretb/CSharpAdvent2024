using Bogus;

namespace CSharpAdvent2024.ApiService
{
    public static class NaughtyNiceEndpoints
    {
        public static void AddNaughtyNiceEndpoints(this WebApplication app)
        {
            app.MapGet("/getnaughtylist", (NaughtyNiceService service) => service.GetNaughtyList())
                .WithName("GetNaughtyList");

            app.MapGet("/getnicelist", (NaughtyNiceService service) => service.GetNiceList())
                .WithName("GetNiceList");

            app.MapPost("/addnaughtylist", (NaughtyNiceService service) =>
            {
                var faker = new Faker("en");
                service.AddToNaughtyList(faker.Name.FullName());
            })
            .WithName("AddToNaughtyList");

            app.MapPost("/addnicelist", (NaughtyNiceService service) => {
                var faker = new Faker("en");
                service.AddToNiceList(faker.Name.FullName());
            })
            .WithName("AddToNiceList");
        }
    }
}

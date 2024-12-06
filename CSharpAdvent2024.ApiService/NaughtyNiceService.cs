using Bogus;

namespace CSharpAdvent2024.ApiService
{
    public class NaughtyNiceService
    {
        public List<string> NaughtyList { get; set; } = new List<string>();
        public List<string> NiceList { get; set; } = new List<string>();

        public void AddToNaughtyList(string name)
        {
            NaughtyList.Add(name);
        }

        public void AddToNiceList(string name)
        {
            NiceList.Add(name);
        }

        public List<string> GetNaughtyList()
        {
            if (!NaughtyList.Any())
            {
                var faker = new Faker("en");
                NaughtyList.Add(faker.Name.FullName());
            }
            return NaughtyList;
        }

        public List<string> GetNiceList()
        {
            if (!NiceList.Any())
            {
                var faker = new Faker("en");
                NiceList.Add(faker.Name.FullName());
            }
            return NiceList;
        }
    }
}

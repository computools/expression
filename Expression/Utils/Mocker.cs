namespace Expressions
{
    public class Mocker
    {
        public static IQueryable<Person> GetAllPersons()
        {
            Random random = new Random();
            var positions = new List<string> { "Developer", "Manager", "Tester" };
            var organizations = new List<string> { "Tesla", "Microsoft", "Google", "Apple" };
            var people = new List<Person>();

            for (var i = 1; i <= 200; i++)
            {
                var firstname = $"Firstname{i}";
                var lastname = $"Lastname{i}";
                var email = $"email{i}@example.com";
                var phone1 = $"123456789_{i}";
                var phone2 = $"987654321_{i}";
                var customerId = i * 100;
                var customerNumber = i * 10;
                var organizationName = organizations[random.Next(organizations.Count)];
                var position = positions[random.Next(positions.Count)];

                people.Add(new Person
                {
                    Id = i,
                    Lastname = lastname,
                    Firstname = firstname,
                    Email = email,
                    Phone1 = phone1,
                    Phone2 = phone2,
                    CustomerId = customerId,
                    CustomerNumber = customerNumber,
                    OrganizationName = organizationName,
                    Position = position
                });
            }

            return people.AsQueryable();
        }
    }
}

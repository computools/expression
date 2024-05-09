namespace Expressions
{
    public class Person
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int? CustomerId { get; set; }
        public int? CustomerNumber { get; set; }
        public string OrganizationName { get; set; }
        public string Position { get; set; }

        public void PrintProperties()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Lastname: {Lastname}");
            Console.WriteLine($"Firstname: {Firstname}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Phone1: {Phone1}");
            Console.WriteLine($"Phone2: {Phone2}");
            Console.WriteLine($"CustomerId: {CustomerId}");
            Console.WriteLine($"CustomerNumber: {CustomerNumber}");
            Console.WriteLine($"OrganizationName: {OrganizationName}");
            Console.WriteLine($"Position: {Position}");
        }
    }
}

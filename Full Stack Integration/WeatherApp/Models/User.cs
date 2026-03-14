namespace WeatherApp.Models
{
    public class User
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required Address Address { get; set; }
    }

    public class Address
    {
        public required string Street { get; set; }
        public required string Suite { get; set; }
        public required string City { get; set; }
        public required string Zipcode { get; set; }
    }
}
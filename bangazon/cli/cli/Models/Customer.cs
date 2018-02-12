namespace cli
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string  ZipCode { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string first, string last, string address, string city, string state, string zip, string phone)
        {
            FirstName = first;
            LastName = last;
            StreetAddress = address;
            City = city;
            State = state;
            ZipCode = zip;
            PhoneNumber = phone;
        } 
    }
}
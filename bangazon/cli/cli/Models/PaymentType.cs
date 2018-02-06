namespace cli
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }
        public PaymentType(int id, string name, string account, int customerId)
        {
            PaymentTypeId = id;
            Name = name;
            AccountNumber = account;
            CustomerId = customerId;
        }
    }
}
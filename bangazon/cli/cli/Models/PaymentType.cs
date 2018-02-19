namespace cli
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }

        public int CustomerId { get; set; }
    }
}
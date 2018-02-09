namespace cli
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int? PaymentTypeId { get; set; }

        public Order(int id, int customerId, int? paymentType)
        {
            OrderId = id;
            CustomerId = customerId;
            PaymentTypeId = paymentType;
        }
    }
}
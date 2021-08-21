namespace Chapter_1.Task_2
{
    internal struct Order
    {
        private readonly string _paylink;

        public Order(string payLink)
        {
            _paylink = payLink;
        }

        public string Paylink => _paylink;
    }
}

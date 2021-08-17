internal class Program
{
    private static void Main()
    {
        var orderForm = new OrderForm();
        var paymentHandler = new PaymentHandler();

        var paymentForm = orderForm.ShowForm();

        paymentForm.ShowInfo();
        paymentForm.Pay();

        paymentHandler.ShowPaymentResult(paymentForm);
    }
}

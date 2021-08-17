internal class QiwiForm : IPaymentForm
{
    public string Name => "QIWI";

    public bool PaymentSuccesful { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine("Перевод на страницу QIWI...");
    }

    public void Pay()
    {
        PaymentSuccesful = true;
    }
}

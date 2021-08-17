internal class WebMoneyForm : IPaymentForm
{
    public string Name => "WebMoney";

    public bool PaymentSuccesful { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine("Вызов API WebMoney...");
    }

    public void Pay()
    {
        PaymentSuccesful = true;
    }
}

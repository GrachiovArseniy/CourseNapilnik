internal class CardForm : IPaymentForm
{
    public string Name => "Card";

    public bool PaymentSuccesful { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine("Вызов API банка эмитера карты Card...");
    }

    public void Pay()
    {
        PaymentSuccesful = true;
    }
}

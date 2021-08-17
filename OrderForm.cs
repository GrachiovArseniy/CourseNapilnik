internal class OrderForm
{
    public IPaymentForm ShowForm()
    {
        Console.WriteLine("Мы принимаемЖ QIWI, WebMoney, Card");

        // Симуляция веб интерфейса
        Console.WriteLine("Какой системой вы хотите совершить оплату?");

        string formId = Console.ReadLine().ToLower();

        switch (formId)
        {
            case "qiwi":
                return new QiwiForm();
            case "webmoney":
                return new WebMoneyForm();
            case "card":
                return new CardForm();
            default:
                OnPaymentError("Данный способ оплаты не найден или недоступен");
                throw new InvalidOperationException();
        }
    }

    public void OnPaymentError(string error)
    {
        Console.WriteLine(error);
    }
}

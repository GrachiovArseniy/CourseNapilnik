internal class PaymentHandler
{
    public void ShowPaymentResult(IPaymentForm paymentForm)
    {
        Console.WriteLine($"Вы оплатили с помощью {paymentForm.Name}");

        Console.WriteLine($"Проверка платежа через {paymentForm.Name}...");

        Console.WriteLine(paymentForm.PaymentSuccesful ? "Оплата прошла успешно!" : "Произошла ошибка!");
    }
}

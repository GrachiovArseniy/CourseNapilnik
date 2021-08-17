internal interface IPaymentForm
{
    public string Name { get; }

    public bool PaymentSuccesful { get; }

    public void ShowInfo();

    public void Pay();
}

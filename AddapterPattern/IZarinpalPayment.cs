namespace AddapterPattern
{
    public interface IZarinpalPayment
    {
        string Pay(decimal amount);
    }
    public class ZarinpalPayment : IZarinpalPayment
    {
        public string Pay(decimal amount) => $"Paid {amount} using ZarinPay";
    }
}

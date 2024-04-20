namespace AdapterPatternAPI.Services
{
    public interface ISamanPayment
    {
        string Pay(decimal amount);
    }

    public class SamanPayment : ISamanPayment
    {
        public string Pay(decimal amount) => $"Paid {amount} using SamanPay";
    }
}

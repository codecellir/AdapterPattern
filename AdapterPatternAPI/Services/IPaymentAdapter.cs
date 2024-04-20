namespace AdapterPatternAPI.Services
{
    public interface IPaymentAdapter
    {
        string Pay(decimal amount);
    }

    public class ZarinpalPaymentAdapter(IZarinpalPayment zarinpalPayment) : IPaymentAdapter
    {
        public string Pay(decimal amount) => zarinpalPayment.Pay(amount);
    }

    public class SamanPaymentAdaptor(ISamanPayment samanPayment) : IPaymentAdapter
    {
        public string Pay(decimal amount) => samanPayment.Pay(amount);
    }
}

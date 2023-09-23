using Dapr.Client;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DaprClient _client;
        public PaymentService(DaprClient client)
        {
            _client = client;
        }

        public string HandlePayment()
        {
            return "Succesfull";

        }
    }
}

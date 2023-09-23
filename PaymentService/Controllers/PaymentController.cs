using Dapr;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Services;
using ShoppingCart.Domain;
using System.Diagnostics.Contracts;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("/payment")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _ctx;
        public PaymentController(IPaymentService service)
        {
            _ctx = service;
        }
        public ActionResult HandlePayment(PaymentRequestedIntegrationEvent integrationEvent)
        {
            Console.WriteLine(_ctx.HandlePayment());
            return Ok();
        }
    }
}
}

using Dapr;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Domain;

namespace ShipmentService.Controllers
{
    [ApiController]
    public class ShipmentController : Controller
    {
        [Topic("pubSub", "shipment")]
        public ActionResult ShipCargo(ShipmentRequestedIntegrationEvent evnt)
        {
            Console.WriteLine(evnt.UserID + ": shipment is on the way to" + evnt.Address);
            return Ok(evnt);
        }
    }
}

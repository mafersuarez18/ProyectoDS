using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsDS.Data;
using PaymentsDS.Models;
using PaymentsDS.Models.Entities;

namespace PaymentsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var allPayments = dbContext.Payments.ToList();
            return Ok(allPayments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPaymentsById(int id)
        {
            var Payment = dbContext.Payments.Find(id);

            if (Payment == null)
            {

                return NotFound();
            }

            return Ok(Payment);
        }

        [HttpPost]
        public IActionResult AddPayments(AddPaymentsDto addpaymentsDto)
        {
            var paymentsentity = new Payment()
            {
                Id = addpaymentsDto.Id,
                date = addpaymentsDto.date,
                amount  = addpaymentsDto.amount,
                state = addpaymentsDto.state,

            };

            dbContext.Payments.Add(paymentsentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Payment added successfully" });

        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePayment(int id, UpdatePaymentsDto updatePaymentDto)
        {
            var existingPayment = dbContext.Payments.Find(id);
            if (existingPayment == null)
            {
                return NotFound();
            }
            existingPayment.date = updatePaymentDto.date;
            existingPayment.amount = updatePaymentDto.amount;
            existingPayment.state = updatePaymentDto.state;

            dbContext.SaveChanges();
            return Ok(existingPayment);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePayments(int id)
        {
            var existingPayment = dbContext.Payments.Find(id);

            if (existingPayment is null)
            {
                return NotFound();
            }
            dbContext.Payments.Remove(existingPayment);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}



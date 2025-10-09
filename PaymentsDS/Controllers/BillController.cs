using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsDS.Data;
using PaymentsDS.Models;
using PaymentsDS.Models.Entities;

namespace PaymentsDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BillController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllBills()
        {
            var allBills = dbContext.Bills.ToList();
            return Ok(allBills);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetBillsById(int id)
        {
            var Bill = dbContext.Bills.Find(id);

            if (Bill == null)
            {

                return NotFound();
            }

            return Ok(Bill);
        }
        

        [HttpPost]
        public IActionResult AddBills(AddBillsDto addbillsDto)
        {
            var billentity = new Bill()
            {
               date = addbillsDto.date,

            };

            dbContext.Bills.Add(billentity);
            dbContext.SaveChanges();

            return Ok(new { message = "Bill added successfully" });

        }
        ///no lo veo necesario
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateBill(int id, UpdateBillsDto updateBillDto)
        {
            var existingBill = dbContext.Bills.Find(id);
            if (existingBill == null)
            {
                return NotFound();
            }
            existingBill.date = updateBillDto.date;
            
            dbContext.SaveChanges();
            return Ok(existingBill);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBills(int id)
        {
            var existingBill = dbContext.Bills.Find(id);

            if (existingBill is null)
            {
                return NotFound();
            }
            dbContext.Bills.Remove(existingBill);
            dbContext.SaveChanges();

            return Ok();


        }

    }
}


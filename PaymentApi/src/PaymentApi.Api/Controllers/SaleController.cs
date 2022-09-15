using Microsoft.AspNetCore.Mvc;
using PaymentApi.Application.Interfaces;
using PaymentApi.Domain;

namespace PaymentApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {        

        private readonly ISaleService saleService;

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sale = saleService.GetById(id);
            if (sale == null) return NotFound();
            return Ok(sale) ;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sale sale)
        {
            try
            {
                var createdSale = saleService.Create(sale);
                return Ok(createdSale);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SaleStatus saleStatus)
        {
            try
            {
                var updatedSale = saleService.Update(id, saleStatus);
                return Ok(updatedSale);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using PaymentApi.Application.Dto;
using PaymentApi.Application.Interfaces;

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
        public IActionResult Post([FromBody] CreateSaleDto sale)
        {
            try
            {
                var createdSale = saleService.Create(sale);
                return Ok(createdSale);
            } catch (Exception ex)
            {
                return BadRequest(ex.InnerException?.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateSaleDto updateSaleDto)
        {
            try
            {
                var updatedSale = saleService.Update(id, updateSaleDto);
                return Ok(updatedSale);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
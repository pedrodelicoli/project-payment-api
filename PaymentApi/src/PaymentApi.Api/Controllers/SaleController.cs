using AutoMapper;
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

        /// <summary>
        /// Busca uma venda por Id.
        /// </summary>
        /// <remarks>        
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Uma venda</returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sale = saleService.GetById(id);
            if (sale == null) return NotFound();
            return Ok(sale) ;
        }

        /// <summary>
        /// Cria uma venda.
        /// </summary>
        /// <remarks>        
        /// </remarks>
        /// <param name="sale"></param>
        /// <returns>Uma nova venda criada</returns>
        

        [HttpPost]
        public IActionResult Post([FromBody] CreateSaleDto sale)
        {
            try
            {
                var createdSale = saleService.Create(sale);
                return Ok(createdSale);
            }
            catch (AutoMapperMappingException autoMapper)
            {
                return BadRequest(autoMapper.InnerException?.Message);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            } 
        }

        /// <summary>
        /// Altera status de uma venda.
        /// </summary>
        /// <remarks>        
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="updateSaleDto"></param>
        /// <returns>A venda que foi alterada</returns>

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
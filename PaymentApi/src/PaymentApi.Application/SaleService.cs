using AutoMapper;
using PaymentApi.Application.Dto;
using PaymentApi.Application.Interfaces;
using PaymentApi.Domain;
using PaymentApi.Repository.Interfaces;

namespace PaymentApi.Application
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper autoMapper;

        public SaleService(
            ISaleRepository saleRepository,
            IMapper autoMapper
            )
        {
            this.saleRepository = saleRepository;
            this.autoMapper = autoMapper;
        }

        public SaleDto Create(CreateSaleDto sale)
        {
            Sale createSale = autoMapper.Map<Sale>(sale);
            return autoMapper.Map<SaleDto>(saleRepository.Create(createSale));
        }

        public SaleDto GetById(int id)
        {
            return autoMapper.Map<SaleDto>(saleRepository.GetById(id));
        }

        public SaleDto Update(int id, UpdateSaleDto updateSaleDto)
        {
            Sale sale = saleRepository.GetById(id);
            sale.UpdateStatus(updateSaleDto.Status);
            return autoMapper.Map<SaleDto>(saleRepository.Update(sale));
        }
    }
}
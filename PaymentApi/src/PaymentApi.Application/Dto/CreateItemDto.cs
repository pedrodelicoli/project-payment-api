namespace PaymentApi.Application.Dto
{
    public class CreateItemDto
    {

        /// <summary>
        /// Nome do item
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Quantidade que foi vendida
        /// </summary>
        public int? Quantity { get; set; }

        public CreateItemDto(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public CreateItemDto()
        {

        }
    }

    
}

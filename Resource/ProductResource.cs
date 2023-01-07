using Dws.Note_one.Api.Domain.Helpers;

namespace Dws.Note_one.Api.Resource
{
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

    }
}
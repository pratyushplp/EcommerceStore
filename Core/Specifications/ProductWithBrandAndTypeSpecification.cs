using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypeSpecification : SpecificationBase<Product>
    {
        public ProductWithBrandAndTypeSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductWithBrandAndTypeSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}

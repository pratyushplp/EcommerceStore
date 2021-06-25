using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class ProductCountSpecification : SpecificationBase<Product>
    {
        //NOTE: this specification is used to get count Before pagination .

        public ProductCountSpecification(ProductSpecParams productSpecParams) : 
                   base(x => (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.Contains(productSpecParams.Search))
                   && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                   && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {


        }

    }
}

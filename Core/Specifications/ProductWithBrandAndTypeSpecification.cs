using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductWithBrandAndTypeSpecification : SpecificationBase<Product>
    {
        public ProductWithBrandAndTypeSpecification(ProductSpecParams productSpecParams)
            :base(x=> (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.Name.Contains(productSpecParams.Search))
                   && (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId)
                   && (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            AddPagination(productSpecParams.PageIndex*(productSpecParams.PageSize - 1), productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch(productSpecParams.Sort)
                {
                    case "NameAsc" : 
                        AddOrderBy(x => x.Name);
                        break;
                    case "NameDesc":
                        AddOrderByDesc(x => x.Name);
                        break;
                    case "PriceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }

            }

        }

        public ProductWithBrandAndTypeSpecification(int id) : base(x=>x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}

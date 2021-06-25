using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specifications
{
    public class ProductSpecParams
    {

        public string Sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        private const int maxPageSize = 50;
        public int PageIndex { get; set; } 

        public int _pageSize = 5;
        public int PageSize { get => _pageSize; set=> _pageSize = value > maxPageSize? maxPageSize: value; }
        public string _search;
        public string Search { get => _search; set => _search = value == null? string.Empty :value.ToLower(); }





    }
}

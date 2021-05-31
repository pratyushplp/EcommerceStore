using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //NOTE : we created the specification class to overcome the drawback of generic pattern while using GenericRepositryAsync 
        //where we could not include other database mainly the productbrand and productType, thus we needed to added certain specification when needed for certain classes (e.g. products)
        //Specification for where and include ( or others with similar signature as where and include)        
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }

    }
}

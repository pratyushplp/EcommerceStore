using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class SpecificationBase<T> : ISpecification<T>
    {
        public SpecificationBase()
        {

        }

        public SpecificationBase(Expression<Func<T, bool>> _Criteria)
        {
            Criteria = _Criteria;
        }
        public Expression<Func<T, bool>> Criteria { get;  }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> _Expression)
        {
            Includes.Add(_Expression);
        }


    }
}

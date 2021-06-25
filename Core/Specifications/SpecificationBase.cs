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

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get;  private set; }

        protected void AddInclude(Expression<Func<T, object>> _Expression)
        {
            Includes.Add(_Expression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> _orderby)
        {
            OrderBy = _orderby;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> _orderbyDesc)
        {
            OrderByDesc = _orderbyDesc;
        }

        protected void AddPagination( int skip, int take)
        {
            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
        }



    }
}

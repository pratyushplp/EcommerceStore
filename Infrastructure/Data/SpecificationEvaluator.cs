using Core.Models;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    class SpecificationEvaluator <TEntity> where TEntity : ProductBase
    {
        //SpecificationEvaluator class is used to evaluate the queries(i.e Expressions) generated using specificationbase class.
        //The  linq Expressions when used inside standard query operations(like where) returns an Iqueryable which is used by SpecificationEvaluator to furthur evaluate the queries.

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);

            }

            if(spec.OrderBy !=null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            //NOTE : order imp. Pagination should take place only after all other processes
            if(spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }


            //using aggregate method to List of expression (i.e Includes) with query as seed value 
            //used to aggregate the where query and all the include statements(1 or more) into one and return as an Iqueryable
            query = spec.Includes.Aggregate(query, (accumulation, include) => accumulation.Include(include));

            return query;
        }



    }
}

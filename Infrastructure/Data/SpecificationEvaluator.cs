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



            //using aggregate method to List of expression (i.e Includes) with query as seed value 
            //used to aggregate the where query and all the include statements(1 or more) into one and return as an Iqueryable
            query = spec.Includes.Aggregate(query, (accumulation, include) => accumulation.Include(include));


            return query;
        }



    }
}

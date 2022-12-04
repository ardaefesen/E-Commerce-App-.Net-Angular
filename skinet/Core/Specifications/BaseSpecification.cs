using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        
        }

        Expression<Func<T, bool>> Criteria {get;}

        Expression<Func<T, bool>> ISpecification<T>.Criteria => throw new NotImplementedException();

        List<Expression<Func<T, object>>> Includes {get;} = 
            new List<Expression<Func<T, object>>>();

        List<Expression<Func<T, object>>> ISpecification<T>.Includes => throw new NotImplementedException();

        protected void AddInclude(Expression<Func<T,object>> includeExpression){
                Includes.Add(includeExpression);
            }
    }
}
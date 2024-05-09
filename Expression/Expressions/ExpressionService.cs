using System.Linq.Expressions;

namespace Expressions
{
    public class ExpressionService
    {
        public IEnumerable<Person> GetAllPersons(string searchString)
        {
            IEnumerable<Person> query;

            query = Mocker.GetAllPersons();

            if (!string.IsNullOrEmpty(searchString))
            {
                var searchParts = searchString.Split(' ');

                Expression<Func<Person, bool>> predicate = null;
                var x = Expression.Parameter(typeof(Person), "x");

                System.Linq.Expressions.Expression expression = searchParts.Select(part => Expression.OrElse(
                        Expression.OrElse(CheckContains(x, "FirstName", part), CheckContains(x, "LastName", part)),
                        Expression.OrElse(CheckContains(x, "OrganizationName", part), CheckContains(x, "Position", part))))
                    .Aggregate(Expression.AndAlso);

                predicate = Expression.Lambda<Func<Person, bool>>(expression, x);
                query = query.Where(predicate!.Compile());
            }

            return query;
        }

        private System.Linq.Expressions.Expression CheckContains(ParameterExpression x, string fieldName, string part)
        {
            return Expression.AndAlso(
                Expression.NotEqual(Expression.Property(x, fieldName), Expression.Constant(null)),
                Expression.Call(Expression.Call(Expression.Property(x, fieldName), "ToLower", null),
                    "Contains", null, Expression.Constant(part.ToLower(), typeof(string)))
            );
        }
    }
}

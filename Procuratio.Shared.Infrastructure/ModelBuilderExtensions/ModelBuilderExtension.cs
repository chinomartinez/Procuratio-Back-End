using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Procuratio.Shared.Infrastructure.ModelBuilderExtensions
{
    public static class ModelBuilderExtension
    {
        public static void ApplyMultiTenantGlobalQueryFilter<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
        {
            IEnumerable<Type> entities = GetEntities<TInterface>(modelBuilder);

            foreach (Type entity in entities)
            {
                ParameterExpression newParam = Expression.Parameter(entity);
                Expression newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                
                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
            }
        }

        public static void ApplyMultiTenantGlobalMetadata<TInterface>(this ModelBuilder modelBuilder, string propertyName)
        {
            IEnumerable<Type> entities = GetEntities<TInterface>(modelBuilder);

            foreach (Type entity in entities)
            {
                modelBuilder.Entity(entity).Property(propertyName).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
        }

        private static IEnumerable<Type> GetEntities<TInterface>(ModelBuilder modelBuilder)
        {
            return modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(e => e.ClrType);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
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
        public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<TInterface, bool>> expression)
        {
            IEnumerable<Type> entities = GetEntities<TInterface>(modelBuilder);

            foreach (Type entity in entities)
            {
                ParameterExpression newParam = Expression.Parameter(entity);
                Expression newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                
                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
            }
        }

        public static void ApplyTenantConfiguration(this ModelBuilder modelBuilder, Expression<Func<ITenant, bool>> expression)
        {
            IEnumerable<Type> entities = GetEntities<ITenant>(modelBuilder);

            foreach (Type entity in entities)
            {
                ParameterExpression newParam = Expression.Parameter(entity);
                Expression newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);

                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
                modelBuilder.Entity(entity).Property("BranchId").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
        }

        private static IEnumerable<Type> GetEntities<TInterface>(ModelBuilder modelBuilder)
        {
            return modelBuilder.Model
                .GetEntityTypes()
                .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(e => e.ClrType);
        }

        public static void ApplyTenantConfiguration(this ModelBuilder modelBuilder, int branchId)
        {
            IEnumerable<Type> entities = GetEntities<ITenant>(modelBuilder);

            Expression<Func<ITenant, bool>> expression = x => x.BranchId == branchId;

            foreach (Type entity in entities)
            {
                ParameterExpression newParam = Expression.Parameter(entity);
                Expression newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);

                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
                modelBuilder.Entity(entity).Property("BranchId").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
        }
    }
}

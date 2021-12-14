using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Procuratio.ProcuratioFramework.ProcuratioFramework.BaseEntityDomain.Interfaces;
using Procuratio.Shared.Infrastructure.Exceptions;
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
        public static void ApplyTenantConfiguration(this ModelBuilder modelBuilder, Expression<Func<ITenant, bool>> expression)
        {
            const string property = "BranchId";

            if (string.IsNullOrEmpty(typeof(ITenant).GetProperty(property).Name)) { throw new PropertyNotFoundException(property); }

            IEnumerable<Type> entities = modelBuilder.Model.GetEntityTypes()
                .Where(x => x.ClrType.GetInterface(typeof(ITenant).Name) is not null)
                .Select(x => x.ClrType);

            foreach (Type entity in entities)
            {
                ParameterExpression newParam = Expression.Parameter(entity);
                Expression newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);

                modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
                modelBuilder.Entity(entity).Property(property).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }
        }
    }
}

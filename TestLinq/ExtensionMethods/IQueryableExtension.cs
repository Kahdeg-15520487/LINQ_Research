using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System.Reflection;

namespace TestLinq.ExtensionMethods
{
    public static class IQueryableExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Microsoft.EntityFrameworkCore.Storage.Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            QueryCompiler queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            QueryModelGenerator modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            Remotion.Linq.QueryModel queryModel = modelGenerator.ParseQuery(query.Expression);
            IDatabase database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            DatabaseDependencies databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            QueryCompilationContext queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            RelationalQueryModelVisitor modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            string sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}

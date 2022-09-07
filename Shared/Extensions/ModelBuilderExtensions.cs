using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Index = Microsoft.EntityFrameworkCore.Metadata.Internal.Index;

namespace Jobit.API.Shared.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // TODO: It's time to change name convention for this properties
            // For properties
            entity.SetTableName(entity.GetTableName()?.ToSnakeCase());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnBaseName().ToSnakeCase());
            }
            // For primary keys
            foreach (var primaryKey in entity.GetKeys())
            {
                primaryKey.SetName(primaryKey.GetName()?.ToSnakeCase());
            }
            // For foreign keys
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                Console.WriteLine(foreignKey.GetConstraintName());
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.ToSnakeCase());
            }
            // For indexes?
            foreach (var index in entity.GetIndexes())
            {
                Console.WriteLine(index.GetDatabaseName());
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
            }
        }
    }
}
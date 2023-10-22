namespace ContosoRetailDwExpander.Model;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public sealed class CsvIgnoreAttribute : Attribute
{
}
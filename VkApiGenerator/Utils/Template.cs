namespace VkApiGenerator.Utils
{
    public class Template
    {
        public const string ThrowIfNumberIsNegative = "VkErrors.ThrowIfNumberIsNegative(() => {0});";

        public const string Method = @"public @Model.ReturnType @Model.Name(@Model.Params)
{
    @Model.Check

    @Model.ParamsDefinition

    @Model.Invoke

    @Model.Return
}";
    }
}
using System;

namespace VkApiGenerator.Console.Model
{
    public enum VkParamType
    {
        ListOfLongs
        
    }

    [Flags]
    public enum VkParamRestrictions
    {
        None = 0,
        PositiveDigit = 1
    }
}
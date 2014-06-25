using System;

namespace VkApiGenerator.Model
{
    [Flags]
    public enum VkParamRestrictions
    {
        None = 0,
        PositiveDigit = 1
    }

    public enum ReturnType
    {
        Unknown = 0,
        Bool = 1,
        Collection = 2,
        Void = 3,
        Long = 4,
        String = 5,
        Double = 6
    }
}
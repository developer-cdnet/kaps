namespace Kaps.Domain.Enums.Core;

public class EnumValueAttribute : Attribute
{
    public string Value { get; }

    public EnumValueAttribute(string value)
    {
        Value = value;
    }
}
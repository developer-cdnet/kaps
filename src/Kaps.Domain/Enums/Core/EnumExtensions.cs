namespace Kaps.Domain.Enums.Core;

public static class EnumExtensions
{
    public static string GetValue(this Enum enumValue)
    {
        var type = enumValue.GetType();
        var memberInfo = type.GetMember(enumValue.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumValueAttribute), false);
        return attributes.Length > 0 ? ((EnumValueAttribute)attributes[0]).Value : null;
    }
}
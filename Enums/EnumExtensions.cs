using System.ComponentModel.DataAnnotations;
using System.Reflection;

public static class EnumExtensions
{
  public static string? GetDisplayName(this Enum enumValue)
  {
    return enumValue.GetType().GetMember(enumValue.ToString())
      ?.First()
      ?.GetCustomAttribute<DisplayAttribute>()
      ?.GetName();
  }

  public static string? GetDisplayNameFirstLetter(this Enum enumValue)
  {
    return enumValue.GetType().GetMember(enumValue.ToString())
      ?.First()
      ?.GetCustomAttribute<DisplayAttribute>()
      ?.GetName()
      ?.Substring(0, 1);
  }

  public static T GetValueFromDisplayName<T>(string displayName)
  {
    var type = typeof(T);

    if (!type.IsEnum)
      throw new ArgumentException("O Parametro enviado nao e um enum");

    foreach (var field in type.GetFields())
    {
      var attribute = Attribute.GetCustomAttribute(field, typeof(DisplayAttribute)) as DisplayAttribute;

      if (attribute != null)
      {
        if (attribute.Name == displayName)
          return (T)field.GetValue(null)!;
      }
      else
      {
        if (field.Name == displayName)
          return (T)field.GetValue(null)!;
      }
    }

    throw new ArgumentException("Nao foi encontrado o valor");
  }
}
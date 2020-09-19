using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Maximus.ControlCenter.UI.Control
{
  public class EnumWithDescription<T>
  {
    public EnumWithDescription(T value)
    {
      Value = value;
      Type myEnumType = typeof(T);
      if (!myEnumType.IsEnum)
        throw new ArgumentException($"{typeof(T).Name} is not a Enum.", "T");
      Type enumUnderlyingType = myEnumType.GetEnumUnderlyingType();
      NativeValue = Convert.ChangeType(value, enumUnderlyingType);
      FieldInfo fieldInfo = myEnumType.GetField(value.ToString());
      Description = ((DescriptionAttribute)fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault())?.Description ?? value.ToString();
    }

    public T Value { get; }

    public object NativeValue { get; }
    public string Description { get; }

    public static EnumWithDescription<T>[] GetEnumValuesArray()
    {
      Array allItems = Enum.GetValues(typeof(T));
      EnumWithDescription<T>[] result = new EnumWithDescription<T>[allItems.Length];
      for (int i = 0; i < allItems.Length; i++)
        result[i] = new EnumWithDescription<T>((T)allItems.GetValue(i));
      return result;
    }
  }
}

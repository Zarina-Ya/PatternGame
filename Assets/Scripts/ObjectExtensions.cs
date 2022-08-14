using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static partial class ObjectExtensions
{
    //const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    //public static T Clone<T>(this T obj)
    //{
    //    if (typeof(T).IsValueType)
    //        return obj;
    //    if (!obj.IsSerializable())
    //        return obj.CloneReflect();
    //    var cloneable = obj as ICloneable;
    //    if (cloneable != null)
    //        return (T)cloneable.Clone();
    //    var b = new BinaryFormatter();
    //    byte[] buffer;
    //    using (var stream = new MemoryStream())
    //    {
    //        b.Serialize(stream, obj);
    //        buffer = stream.GetBuffer();
    //    }

    //    T result;
    //    using (var stream = new MemoryStream(buffer))
    //        result = (T)b.Deserialize(stream);
    //    return result;
    //}

    //public static bool IsSerializable<T>(this T obj)
    //{
    //    return typeof(T).Attributes.HasFlag(TypeAttributes.Serializable) || obj is ISerializable;
    //}

    //private static T CloneReflect<T>(this T obj)
    //{
    //    try
    //    {
    //        Type type = obj.GetType();
    //        if (type.IsValueType || obj is string)
    //            return obj;


    //        T copy;

    //        try
    //        {
    //            copy = Activator.CreateInstance<T>();
    //        }
    //        catch
    //        {
    //            var constr = type.GetConstructors(Flags).First();
    //            ParameterInfo[] parameterInfos = constr.GetParameters();
    //            var parameters =
    //                parameterInfos.Select(x => x.ParameterType)
    //                              .Select(t => t.IsValueType ? Activator.CreateInstance(t) : null)
    //                              .ToArray();
    //            copy = (T)constr.Invoke(parameters);
    //        }


    //        foreach (var fieldInfo in type.GetFields(Flags))
    //        {
    //            var value = fieldInfo.GetValue(obj).Clone();
    //            fieldInfo.SetValue(copy, value);
    //        }
    //        foreach (var propertyInfo in type.GetProperties(Flags))
    //        {
    //            var value = propertyInfo.GetValue(obj, null).Clone();
    //            propertyInfo.SetValue(copy, value, null);
    //        }

    //        return copy;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new NotSupportedException("Не удается получить данные о типе", ex);
    //    }
    //}
    public static T DeepCopy<T>(this T self)
    {
        if (!typeof(T).IsSerializable)
        {
            throw new ArgumentException("Type must be iserializable");
        }
        if (ReferenceEquals(self, null))
        {
            return default;
        }
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}
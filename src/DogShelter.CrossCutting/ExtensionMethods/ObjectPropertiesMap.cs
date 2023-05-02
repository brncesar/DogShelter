﻿using System.Reflection;

namespace DogShelter.CrossCutting.ExtensionMethods;

public static class ObjectPropertiesMap
{
    private static void TrySetSourcePropertyValueOnTargetObject<TTarget>(object source, PropertyInfo sourceProperty, TTarget targetObject, PropertyInfo targetProperty, bool ignoreNullValues = false)
    {
        var sourceType = source.GetType();
        var targetType = typeof(TTarget);

        if (ignoreNullValues && source.GetType().GetProperty(sourceProperty.Name).GetValue(source, null) is null) return;

        var isSourcePropertyNullable = sourceProperty.PropertyType.IsGenericType;
        var isTargetPropertyNullable = targetProperty.PropertyType.IsGenericType && targetProperty.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);

        if (isSourcePropertyNullable == isTargetPropertyNullable)
        {
            if (sourceProperty != null && sourceProperty.PropertyType == targetProperty.PropertyType)
            {
                var sourceValue = sourceType.GetProperty(sourceProperty.Name).GetValue(source, null);
                targetType.GetProperty(targetProperty.Name).SetValue(targetObject, sourceValue, null);
            }
        }
        else if (isTargetPropertyNullable && sourceProperty.PropertyType.UnderlyingSystemType == targetProperty.PropertyType.GetGenericArguments()[0])
        {
            var sourceValue = sourceType.GetProperty(sourceProperty.Name).GetValue(source, null);
            targetType.GetProperty(targetProperty.Name).SetValue(targetObject, sourceValue, null);
        }
    }

    public static TTarget MapValuesTo<TTarget>(this object source, bool ignoreNullValues = false)
    {
        try
        {
            var sourceType = source.GetType();
            var targetType = typeof(TTarget);

            var arrSourceProperties = sourceType.GetProperties();
            var arrTargetProperties = targetType.GetProperties();

            var ass = Assembly.GetAssembly(targetType);
            var targetObject = (TTarget)ass.CreateInstance(targetType.FullName);

            if (arrSourceProperties.Length < arrTargetProperties.Length)
            {

                foreach (var sourceProperty in arrSourceProperties)
                {
                    var targetProperty = arrTargetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

                    if (targetProperty is null) continue;

                    TrySetSourcePropertyValueOnTargetObject<TTarget>(source, sourceProperty, targetObject, targetProperty, ignoreNullValues);
                }
            }
            else
            {
                foreach (var targetProperty in arrTargetProperties)
                {
                    var sourceProperty = arrSourceProperties.FirstOrDefault(sp => sp.Name == targetProperty.Name);

                    if (sourceProperty is null) continue;

                    TrySetSourcePropertyValueOnTargetObject<TTarget>(source, sourceProperty, targetObject, targetProperty, ignoreNullValues);
                }
            }

            return targetObject;
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }

    public static void MapValuesTo<TTarget>(this object source, ref TTarget targetObject, bool ignoreNullValues = false)
    {
        try
        {
            var sourceType = source.GetType();
            var targetType = typeof(TTarget);

            var arrSourceProperties = sourceType.GetProperties();
            var arrTargetProperties = targetType.GetProperties();

            if (arrSourceProperties.Length < arrTargetProperties.Length)
            {
                foreach (var sourceProperty in arrSourceProperties)
                {
                    var targetProperty = arrTargetProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

                    if (targetProperty is null) continue;

                    TrySetSourcePropertyValueOnTargetObject(source, sourceProperty, targetObject, targetProperty, ignoreNullValues);
                }
            }
            else
            {
                foreach (var targetProperty in arrTargetProperties)
                {
                    var sourceProperty = arrSourceProperties.FirstOrDefault(sp => sp.Name == targetProperty.Name);

                    if (sourceProperty is null) continue;

                    TrySetSourcePropertyValueOnTargetObject(source, sourceProperty, targetObject, targetProperty, ignoreNullValues);
                }
            }
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }

    public static List<TTarget> MapValuesToNewList<TSource, TTarget>(this ICollection<TSource> sourceList)
    {
        try
        {
            var targetListType = Type.GetType(typeof(List<TTarget>).AssemblyQualifiedName);
            var targetList = (List<TTarget>)Activator.CreateInstance(targetListType);

            targetList.AddRange(from object sourceItem in sourceList select sourceItem.MapValuesTo<TTarget>());

            return targetList;
        }
        catch (Exception exc)
        {
            throw exc;
        }
    }
}
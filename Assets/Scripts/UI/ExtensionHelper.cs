using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtensionHelper
{
    public static Vector3 SetZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);

    public static T RandomValue<T>(this IEnumerable<T> collection)
    {
        int count = collection.Count();
        if (count == 0)
        {
            return default;
        }
        
        int hashCode = Math.Abs(Guid.NewGuid().GetHashCode());
        return collection.ElementAt(hashCode % count);
    }
}
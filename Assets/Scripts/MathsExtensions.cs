using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathsExtensions
{
    public static bool IsBetween(this float value, float min, float max, bool exclusiveMin = false, bool exclusiveMax = false)
    {
        return (exclusiveMin ? value > min : value >= min) && (exclusiveMin ? value < max : value <= max);
    }
}

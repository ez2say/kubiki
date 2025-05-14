using UnityEngine;

namespace Helpers
{
    public static class ColorExtensions
    {
        public static string ToColorString(this Color color)
        {
            return $"{color.r:F2},{color.g:F2},{color.b:F2}";
        }
    }
}
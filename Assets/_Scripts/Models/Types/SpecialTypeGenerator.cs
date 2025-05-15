using Models.Types;
using UnityEngine;

public static class SpecialTypeGenerator
{
    public static FigureSpecialType GetRandom()
    {
        float roll = Random.value;
        if (roll < 0.05f) return FigureSpecialType.Explosive;
        else if (roll < 0.1f) return FigureSpecialType.Heavy;
        else if (roll < 0.15f) return FigureSpecialType.Sticky;
        else if (roll < 0.2f) return FigureSpecialType.Frozen;
        return FigureSpecialType.Normal;
    }
}
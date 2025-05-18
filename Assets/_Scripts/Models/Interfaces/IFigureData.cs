using UnityEngine;
using Models.Types;

namespace Models.Interfaces
{
    public interface IFigureData
    {
        FigureType Type { get; }
        GameObject Prefab { get; }
        FigureSpecialType SpecialType { get; }
    }
}
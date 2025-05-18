using UnityEngine;
using Models.Types;
using Models.Interfaces;
using Models.Implementations;

namespace Factories
{
    public struct FigureData : IFigureData
    {
        public FigureType Type { get; set; }
        public GameObject Prefab { get; set; }
        public FigureSpecialType SpecialType { get; set; }

        public string GroupId =>
            $"{Type.Shape}_{BaseFigure.ColorToString(Type.FrameColor)}_{Type.AnimalSprite.name}";
    }
}
using UnityEngine;
using Models.Types;

namespace Models.Interfaces
{
    public interface IFigureType
    {
        ShapeType Shape { get; }
        Color FrameColor { get; }
        Sprite AnimalSprite { get; }
    }
}
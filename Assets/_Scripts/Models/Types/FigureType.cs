using UnityEngine;
using Models.Interfaces;

namespace Models.Types
{
    [System.Serializable]
    public class FigureType : IFigureType
    {
        public ShapeType Shape { get; private set; }
        public Color FrameColor { get; private set; }
        public Sprite AnimalSprite { get; private set; }

        public FigureType(ShapeType shape, Color frameColor, Sprite animalSprite)
        {
            Shape = shape;
            FrameColor = frameColor;
            AnimalSprite = animalSprite;
        }
    }

    public enum ShapeType { Circle, Square, Triangle }
}
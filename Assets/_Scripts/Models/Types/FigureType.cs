using UnityEngine;

namespace Models.Types
{
    [System.Serializable]
    public class FigureType
    {
        public ShapeType Shape;
        public Color FrameColor;
        public Sprite AnimalSprite;
    }

    public enum ShapeType { Circle, Square, Triangle }
}
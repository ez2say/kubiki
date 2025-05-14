using UnityEngine;

namespace Models.Types
{
    [System.Serializable]
    public class FigureType
    {
        public ShapeType Shape;
        public Color FrameColor;
        public AnimalType Animal;
    }

    public enum ShapeType { Circle, Square, Triangle }
    public enum AnimalType { Lion, Tiger, Bear, Rabbit }
}
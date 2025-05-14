using Models.Types;
using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class DefaultTypeProvider : ITypeProvider
    {
        public List<FigureType> GetAvailableTypes()
        {
            var result = new List<FigureType>();

            ShapeType[] shapes = (ShapeType[])System.Enum.GetValues(typeof(ShapeType));
            AnimalType[] animals = (AnimalType[])System.Enum.GetValues(typeof(AnimalType));
            Color[] colors = new[]
            {
                Color.red,
                Color.blue,
                Color.green,
                Color.yellow
            };

            foreach (var shape in shapes)
            {
                foreach (var animal in animals)
                {
                    foreach (var color in colors)
                    {
                        result.Add(new FigureType
                        {
                            Shape = shape,
                            FrameColor = color,
                            Animal = animal
                        });
                    }
                }
            }

            return result;
        }
    }
}
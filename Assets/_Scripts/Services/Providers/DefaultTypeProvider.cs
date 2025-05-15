using Models.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class DefaultTypeProvider : ITypeProvider
    {
        [SerializeField] private AnimalSprites animalSprites;

        public DefaultTypeProvider(AnimalSprites sprites)
        {
            animalSprites = sprites;
        }

        public List<FigureType> GetAvailableTypes()
        {
            var result = new List<FigureType>();

            ShapeType[] shapes = (ShapeType[])System.Enum.GetValues(typeof(ShapeType));
            Color[] colors = new[]
            {
                Color.red,
                Color.blue,
                Color.green,
                Color.yellow
            };

            Sprite[] animals = new[]
            {
                animalSprites.Lion,
                animalSprites.Tiger,
                animalSprites.Bear,
                animalSprites.Rabbit
            };

            foreach (var shape in shapes)
            {
                foreach (var color in colors)
                {
                    foreach (var animal in animals)
                    {
                        result.Add(new FigureType
                        {
                            Shape = shape,
                            FrameColor = color,
                            AnimalSprite = animal
                        });
                    }
                }
            }

            return result;
        }
    }
}
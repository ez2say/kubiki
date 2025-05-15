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
            ShapeType[] shapes = GenerateShapes();
            Color[] colors = GenerateColors();
            Sprite[] animals = GenerateAnimals();
            CreateFigure(result, shapes, colors, animals);

            return result;
        }

        private static void CreateFigure(List<FigureType> result, ShapeType[] shapes, Color[] colors, Sprite[] animals)
        {
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
        }

        private Sprite[] GenerateAnimals()
        {
            return new[]
                        {
                animalSprites.Lion,
                animalSprites.Tiger,
                animalSprites.Bear,
                animalSprites.Rabbit
            };
        }

        private static Color[] GenerateColors()
        {
            return new[]
                        {
                Color.red,
                Color.blue,
                Color.green,
                Color.yellow
            };
        }

        private static ShapeType[] GenerateShapes()
        {
            return (ShapeType[])System.Enum.GetValues(typeof(ShapeType));
        }
    }
}
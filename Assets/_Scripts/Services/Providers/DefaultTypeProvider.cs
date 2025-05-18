using Models.Types;
using Services.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class DefaultTypeProvider : ITypeProvider
    {
        private AnimalSprites _animalSprites;

        public DefaultTypeProvider(AnimalSprites sprites)
        {
            _animalSprites = sprites;
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
                        result.Add(new FigureType(shape, color, animal));
                    }
                }
            }
        }

        private Sprite[] GenerateAnimals()
        {
            return new[]
                        {
                _animalSprites.Lion,
                _animalSprites.Tiger,
                _animalSprites.Bear,
                _animalSprites.Rabbit
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
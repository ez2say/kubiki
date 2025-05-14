using System.Collections.Generic;
using UnityEngine;
using Models.Types;
using Factories;

namespace Core
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject circlePrefab;
        [SerializeField] private GameObject squarePrefab;
        [SerializeField] private GameObject trianglePrefab;

        private void Start()
        {

            var types = new List<FigureType>
            {
                new FigureType { Shape = ShapeType.Circle, FrameColor = Color.red, Animal = AnimalType.Lion },
                new FigureType { Shape = ShapeType.Circle, FrameColor = Color.yellow, Animal = AnimalType.Rabbit },
                new FigureType { Shape = ShapeType.Square, FrameColor = Color.blue, Animal = AnimalType.Tiger },
                new FigureType { Shape = ShapeType.Triangle, FrameColor = Color.green, Animal = AnimalType.Bear },
            };

            // Выбираем случайный префаб
            GameObject prefab = GetRandomPrefab(circlePrefab, squarePrefab, trianglePrefab);

            // Создаём фабрику
            var factory = new BasicFigureFactory(types, prefab);

            // Создаём фигурку
            var figure = factory.CreateFigure();
            figure.OnClick(); // Тест клика
        }

        private GameObject GetRandomPrefab(params GameObject[] prefabs)
        {
            return prefabs[Random.Range(0, prefabs.Length)];
        }
    }
}
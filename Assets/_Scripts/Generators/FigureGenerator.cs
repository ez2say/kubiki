using System.Collections.Generic;
using UnityEngine;
using Models.Types;
using Models.Interfaces;
using Models.Implementations;

namespace Factories
{
    public class FigureGenerator : IFigureGenerator
    {
        private readonly Queue<IFigureData> _dataPool = new();

        private readonly Dictionary<string, List<FigureData>> _figureGroups = new();

        public FigureGenerator(
            List<FigureType> availableTypes,
            GameObject[] figurePrefabs,
            int figureCount)
        {
            var allFigures = new List<FigureData>();
            int tripletCount = figureCount / 3;

            for (int i = 0; i < tripletCount; i++)
            {
                FigureType type = GetRandomType(availableTypes);
                GameObject prefab = GetRandomPrefab(figurePrefabs);
                FigureSpecialType specialType = SpecialTypeGenerator.GetRandom();

                var groupKey = $"{type.Shape}_{BaseFigure.ColorToString(type.FrameColor)}_{type.AnimalSprite.name}";

                if (!_figureGroups.ContainsKey(groupKey))
                {
                    _figureGroups[groupKey] = new List<FigureData>();
                }

                for (int j = 0; j < 3; j++)
                {
                    var figure = new FigureData
                    {
                        Type = new FigureType(
                            shape: GetShapeFromPrefab(prefab),
                            frameColor: type.FrameColor,
                            animalSprite: type.AnimalSprite
                        ),
                        Prefab = prefab,
                        SpecialType = specialType
                    };

                    _figureGroups[groupKey].Add(figure);
                    allFigures.Add(figure);
                }
            }

            Shuffle(allFigures);

            foreach (var data in allFigures)
            {
                _dataPool.Enqueue(data);
            }
        }
        private ShapeType GetShapeFromPrefab(GameObject prefab)
        {
            string name = prefab.name.ToLower();

            if (name.Contains("circle")) return ShapeType.Circle;
            if (name.Contains("square")) return ShapeType.Square;
            if (name.Contains("triangle")) return ShapeType.Triangle;

            return ShapeType.Circle;
        }

        public IFigureData GetNextFigureData()
        {
            if (_dataPool.Count == 0)
            {
                Debug.LogWarning("Figure pool is empty!");
                return null;
            }

            return _dataPool.Dequeue();
        }

        private static void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int randomIndex = Random.Range(i, list.Count);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

        private GameObject GetRandomPrefab(GameObject[] prefabs) =>
            prefabs[Random.Range(0, prefabs.Length)];

        private FigureType GetRandomType(List<FigureType> types) =>
            types[Random.Range(0, types.Count)];
    }
}
using System.Collections.Generic;
using UnityEngine;
using Models.Implementations;
using Models.Types;
using Models.Interfaces;

namespace Factories
{
    public class BaseFigureFactory : IFigureFactory
    {
        private readonly List<FigureType> _availableTypes;
        private readonly GameObject[] _prefabs;

        public BaseFigureFactory(List<FigureType> availableTypes, params GameObject[] prefabs)
        {
            _availableTypes = availableTypes;
            _prefabs = prefabs;
        }

        public IFigure CreateFigure(FigureSpecialType specialType = FigureSpecialType.Normal)
        {
            var prefab = GetRandomPrefab(_prefabs);
            var go = Object.Instantiate(prefab);
            IFigure figure = go.GetComponent<BaseFigure>();

            switch (specialType)
            {
                case FigureSpecialType.Heavy:
                    figure = new HeavyFigureDecorator(figure);
                    break;
                case FigureSpecialType.Sticky:
                    figure = new StickyFigureDecorator(figure);
                    break;
                case FigureSpecialType.Explosive:
                    figure = new ExplosiveFigureDecorator(figure);
                    break;
                case FigureSpecialType.Frozen:
                    figure = new FrozenFigureDecorator(figure);
                    break;
            }

            figure.Initialize(GetRandomType());
            return figure;
        }

        private FigureType GetRandomType()
        {
            return _availableTypes[Random.Range(0, _availableTypes.Count)];
        }

        private GameObject GetRandomPrefab(GameObject[] prefabs)
        {
            return prefabs[Random.Range(0, prefabs.Length)];
        }
    }
}
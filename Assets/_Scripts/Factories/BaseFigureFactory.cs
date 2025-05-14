using System.Collections.Generic;
using UnityEngine;
using Models.Implementations;
using Models.Interfaces;
using Models.Types;

namespace Factories
{
    public class BasicFigureFactory : IFigureFactory
    {
        private readonly List<FigureType> _availableTypes = new();
        private readonly GameObject _prefab;

        public BasicFigureFactory(List<FigureType> availableTypes, GameObject prefab)
        {
            _availableTypes = availableTypes;
            _prefab = prefab;
        }

        public IFigure CreateFigure()
        {
            var go = Object.Instantiate(_prefab);
            var figure = go.GetComponent<BaseFigure>();
            var type = GetRandomType();

            figure.Initialize(type);
            return figure;
        }

        private FigureType GetRandomType()
        {
            return _availableTypes[Random.Range(0, _availableTypes.Count)];
        }
    }
}
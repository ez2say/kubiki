using System.Collections;
using UnityEngine;
using Models.Interfaces;
using Models.Types;
using System.Collections.Generic;

namespace Services
{
    public class CoroutineFigureSpawner : IFigureSpawner
    {
        private readonly IFigureFactory _figureFactory;
        private readonly ISpawnPointProvider _spawnPointProvider;
        private readonly ISpawnPositionStrategy _positionStrategy;
        private readonly MonoBehaviour _monoProvider;
        private readonly float _dropDelay;
        private readonly int _figureCount;

        private List<IFigure> _spawnedFigures = new();

        public CoroutineFigureSpawner(
            IFigureFactory figureFactory,
            ISpawnPointProvider spawnPointProvider,
            ISpawnPositionStrategy positionStrategy,
            MonoBehaviour monoProvider,
            float dropDelay,
            int figureCount)
        {
            _figureFactory = figureFactory;
            _spawnPointProvider = spawnPointProvider;
            _positionStrategy = positionStrategy;
            _monoProvider = monoProvider;
            _dropDelay = dropDelay;
            _figureCount = figureCount;
        }

        public void SpawnFigures()
        {
            _monoProvider.StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            Transform spawnPoint = _spawnPointProvider.GetSpawnPoint();

            for (int i = 0; i < _figureCount; i++)
            {
                var specialType = SpecialTypeGenerator.GetRandom();
                IFigure figure = _figureFactory.CreateFigure(specialType);

                _spawnedFigures.Add(figure);

                if (figure is MonoBehaviour mb)
                {
                    Vector3 spawnPos = _positionStrategy.CalculateSpawnPosition(spawnPoint);
                    mb.transform.position = spawnPos;
                    figure.OnFall();
                }

                yield return new WaitForSeconds(_dropDelay);
            }
        }
    }
}
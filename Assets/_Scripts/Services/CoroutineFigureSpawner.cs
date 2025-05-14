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
        private readonly float _dropDelay;
        private readonly int _figureCount;

        private List<IFigure> _spawnedFigures = new();

        public CoroutineFigureSpawner(
            IFigureFactory figureFactory,
            ISpawnPointProvider spawnPointProvider,
            float dropDelay,
            int figureCount)
        {
            _figureFactory = figureFactory;
            _spawnPointProvider = spawnPointProvider;
            _dropDelay = dropDelay;
            _figureCount = figureCount;
        }

        public void SpawnFigures()
        {
            MonoBehaviour mono = new GameObject("FigureSpawner").AddComponent<FigureSpawnerRunner>();

            mono.StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            Transform spawnPoint = _spawnPointProvider.GetSpawnPoint();

            for (int i = 0; i < _figureCount; i++)
            {
                IFigure figure = _figureFactory.CreateFigure();

                _spawnedFigures.Add(figure);

                if (figure is MonoBehaviour mb)
                {
                    float randomXOffset = Random.Range(-0.5f, 0.5f);
                    Vector3 spawnPos = spawnPoint.position + Vector3.right * randomXOffset;
                    mb.transform.position = spawnPos;
                }

                yield return new WaitForSeconds(_dropDelay);
            }
        }
    }

    internal class FigureSpawnerRunner : MonoBehaviour { }
}
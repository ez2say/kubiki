using System.Collections;
using UnityEngine;
using Models.Interfaces;
using Models.Types;
using Services.Interfaces;

namespace Services
{
    public class CoroutineFigureSpawner : IFigureSpawner
    {
        private readonly IFigureGenerator _figureGenerator;
        private readonly ISpawnPointProvider _spawnPointProvider;
        private readonly ISpawnPositionStrategy _positionStrategy;
        private readonly MonoBehaviour _monoProvider;
        private readonly float _dropDelay;
        private readonly int _figureCount;

        public CoroutineFigureSpawner(
            IFigureGenerator figureGenerator,
            ISpawnPointProvider spawnPointProvider,
            ISpawnPositionStrategy positionStrategy,
            MonoBehaviour monoProvider,
            float dropDelay,
            int figureCount)
        {
            _figureGenerator = figureGenerator;
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
                FieldCountManager.Instance.RegisterFigure();

                IFigureData data = _figureGenerator.GetNextFigureData();

                if (data == null)
                    yield break;

                Vector3 spawnPos = _positionStrategy.CalculateSpawnPosition(spawnPoint);

                var go = Object.Instantiate(data.Prefab, spawnPos, Quaternion.identity);

                var figureSystem = go.GetComponent<FigureSystem>();

                if (figureSystem != null)
                {
                    figureSystem.Initialize(data.Type, data.SpecialType);
                }

                IFigure figure = go.GetComponent<IFigure>();

                if (figure != null)
                {
                    figure.OnFall();
                }

                yield return new WaitForSeconds(_dropDelay);
            }
        }
    }
}
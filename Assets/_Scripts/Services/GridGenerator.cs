using UnityEngine;
using Models.Interfaces;
using Services;
using Factories;
using Models.Types;

namespace Services
{
    public class GridGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject circlePrefab;
        [SerializeField] private GameObject squarePrefab;
        [SerializeField] private GameObject trianglePrefab;
        [SerializeField] private float dropDelay = 0.2f;
        [SerializeField] private int figureCount = 9;

        private IFigureSpawner _spawner;

        public void Initialize()
        {
            ITypeProvider typeProvider = new DefaultTypeProvider();
            ISpawnPointProvider spawnPointProvider = new SceneSpawnPointProvider();

            IFigureFactory factory = new BaseFigureFactory(
                typeProvider.GetAvailableTypes(),
                circlePrefab,
                squarePrefab,
                trianglePrefab
            );

            _spawner = new CoroutineFigureSpawner(
                factory,
                spawnPointProvider,
                dropDelay,
                figureCount
            );

            _spawner.SpawnFigures();
        }
    }
}
using UnityEngine;
using Models.Interfaces;
using Services;
using Factories;
using Models.Types;


public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GameObject circlePrefab;
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private GameObject trianglePrefab;
    [SerializeField] private float dropDelay = 0.2f;
    [SerializeField] private int figureCount = 9;
    [SerializeField] private AnimalSprites _animalSprites;

    private IFigureSpawner _spawner;

    public void Initialize()
    {
        ITypeProvider typeProvider = new DefaultTypeProvider(_animalSprites);

        ISpawnPointProvider spawnPointProvider = new SceneSpawnPointProvider();

        ISpawnPositionStrategy spawnPositionStrategy = new RandomOffsetSpawnStrategy();

        IFigureFactory factory = new BaseFigureFactory(
            typeProvider.GetAvailableTypes(),
            circlePrefab,
            squarePrefab,
            trianglePrefab
        );

        _spawner = new CoroutineFigureSpawner(
            factory,
            spawnPointProvider,
            spawnPositionStrategy,
            this,
            dropDelay,
            figureCount
        );

        _spawner.SpawnFigures();
    }
}
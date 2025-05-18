using UnityEngine;
using Models.Interfaces;
using Services;
using Services.Interfaces;
using Factories;

public class GameInitializer : MonoBehaviour, IGameInitializer
{
    [SerializeField] private GameObject[] _prefabList;
    [SerializeField] private float dropDelay = 0.2f;
    [SerializeField] private int figureCount = 9;
    [SerializeField] private AnimalSprites _animalSprites;

    private IFigureSpawner _spawner;

    public void Initialize()
    {

        ITypeProvider typeProvider = new DefaultTypeProvider(_animalSprites);

        ISpawnPointProvider spawnPointProvider = new SceneSpawnPointProvider();

        ISpawnPositionStrategy spawnPositionStrategy = new RandomOffsetSpawnStrategy();

        IFigureGenerator factory = new FigureGenerator(
            typeProvider.GetAvailableTypes(),
            _prefabList,
            figureCount
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


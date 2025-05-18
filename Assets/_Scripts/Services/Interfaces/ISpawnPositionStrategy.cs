using UnityEngine;

namespace Services.Interfaces
{
    public interface ISpawnPositionStrategy
    {
        Vector3 CalculateSpawnPosition(Transform spawnPoint);
    }
}
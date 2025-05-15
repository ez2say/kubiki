using UnityEngine;

namespace Services
{
    public interface ISpawnPositionStrategy
    {
        Vector3 CalculateSpawnPosition(Transform spawnPoint);
    }
}
using UnityEngine;

namespace Services
{
    public class RandomOffsetSpawnStrategy : ISpawnPositionStrategy
    {
        public Vector3 CalculateSpawnPosition(Transform spawnPoint)
        {
            float randomXOffset = Random.Range(-0.5f, 0.5f);
            return spawnPoint.position + Vector3.right * randomXOffset;
        }
    }
}
using Services.Interfaces;
using UnityEngine;

namespace Services
{
    public class RandomOffsetSpawnStrategy : ISpawnPositionStrategy
    {
        public Vector3 CalculateSpawnPosition(Transform spawnPoint)
        {
            return spawnPoint.position ;
        }
    }
}
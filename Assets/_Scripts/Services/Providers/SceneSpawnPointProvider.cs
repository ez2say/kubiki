using UnityEngine;
using Models.Interfaces;

namespace Services
{
    public class SceneSpawnPointProvider : ISpawnPointProvider
    {
        public Transform GetSpawnPoint()
        {
            var go = GameObject.Find("SpawnPoint");
            return go ? go.transform : null;
        }
    }
}
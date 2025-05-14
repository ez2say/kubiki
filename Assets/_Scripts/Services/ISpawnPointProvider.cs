using UnityEngine;

namespace Services
{
    public interface ISpawnPointProvider
    {
        Transform GetSpawnPoint();
    }
}
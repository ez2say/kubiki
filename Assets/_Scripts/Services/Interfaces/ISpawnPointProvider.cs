using UnityEngine;

namespace Services.Interfaces
{
    public interface ISpawnPointProvider
    {
        Transform GetSpawnPoint();
    }
}
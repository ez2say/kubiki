using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig", order = 0)]
public class GameConfig : ScriptableObject
{
    public float DropDelay = 0.2f;
    public int FigureCount = 9;
}
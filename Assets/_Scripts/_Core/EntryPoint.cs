using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    private GridGenerator gridGenerator;


    private void Start()
    {
        gridGenerator = GetComponent<GridGenerator>();
        gridGenerator.Initialize();
    }
}

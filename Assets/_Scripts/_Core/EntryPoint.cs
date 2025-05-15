using UnityEngine;
using Services;


public class EntryPoint : MonoBehaviour
{
    private GridGenerator gridGenerator;


    private void Start()
    {
        gridGenerator = GetComponent<GridGenerator>();
        gridGenerator.Initialize();
    }
}

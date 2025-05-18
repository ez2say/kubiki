using UnityEngine;
using Services.Interfaces;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    private IGameInitializer _gameInitializer;


    private void Start()
    {
        _gameInitializer = gameObject.GetComponent<IGameInitializer>();

        _gameInitializer.Initialize();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

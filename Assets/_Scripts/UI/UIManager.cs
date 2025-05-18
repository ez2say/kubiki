using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private GameObject _victoryScreen;
        [SerializeField] private GameObject _gameOverScreen;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            _victoryScreen.SetActive(false);
            _gameOverScreen.SetActive(false);
        }

        public void ShowVictory()
        {
            _victoryScreen.SetActive(true);
        }

        public void ShowGameOver()
        {
            _gameOverScreen.SetActive(true);
        }
    }
}
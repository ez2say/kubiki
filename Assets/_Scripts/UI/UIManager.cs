using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private GameObject gameOverScreen;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void ShowVictory()
        {
            victoryScreen.SetActive(true);
        }

        public void ShowGameOver()
        {
            gameOverScreen.SetActive(true);
        }
    }
}
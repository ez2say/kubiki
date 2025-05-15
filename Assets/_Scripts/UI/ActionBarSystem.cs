using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Models.Interfaces;
using Helpers;
using Services;

namespace UI
{
    public class ActionBarSystem : MonoBehaviour
    {
        public static ActionBarSystem Instance;

        [SerializeField] private Transform barContainer;
        [SerializeField] private GameObject actionItemPrefab;
        [SerializeField] private int maxSlots = 7;

        private List<IFigure> _figuresInBar = new();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddFigure(IFigure figure)
        {
            if (_figuresInBar.Count >= maxSlots)
            {
                Debug.Log("Бар заполнен! Вы проиграли.");
                /*UIManager.Instance.ShowGameOver();*/
                return;
            }

            // Уничтожаем объект на поле
            Destroy(((MonoBehaviour)figure).gameObject);

            // Добавляем в бар
            _figuresInBar.Add(figure);
            SpawnInBar(figure);

            CheckForMatch();
            CheckWinCondition();
        }

        private void SpawnInBar(IFigure figure)
        {
            var go = Instantiate(actionItemPrefab, barContainer);
            var item = go.GetComponent<ActionBarItem>();
            item.SetFigure(figure);
        }

        private void CheckForMatch()
        {
            var grouped = _figuresInBar
                .GroupBy(f => new
                {
                    f.Type.Shape,
                    AnimalName = f.Type.AnimalSprite.name, // сравниваем по имени спрайта
                    Color = f.Type.FrameColor.ToColorString()
                })
                .Where(g => g.Count() >= 3)
                .ToList();

            if (grouped.Count > 0)
            {
                foreach (var matched in grouped[0].Take(3))
                {
                    _figuresInBar.Remove(matched);
                }

                // Пересоздаём интерфейс
                foreach (Transform child in barContainer)
                    Destroy(child.gameObject);

                foreach (var figure in _figuresInBar)
                    SpawnInBar(figure);
            }
        }

        private void CheckWinCondition()
        {
            /*if (GridGenerator.Instance.IsFieldEmpty() && _figuresInBar.Count == 0)
            {
                Debug.Log("Вы победили!");
                UIManager.Instance.ShowVictory();
            }*/
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Models.Interfaces;
using Models.Types;
using Models.Types.Specials;

namespace UI
{
    public class ActionBarSystem : MonoBehaviour
    {
        public static ActionBarSystem Instance;

        [SerializeField] private Transform barContainer;
        [SerializeField] private GameObject actionItemPrefab;
        [SerializeField] private int maxSlots = 7;

        private int _matchCount = 0;
        private const int MatchToThaw = 3;

        private List<IFigure> _figuresInBar = new();
        private List<ActionBarItem> _actionBarSlots = new();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            InitializeSlots();
        }
        private void InitializeSlots()
        {
            foreach (Transform child in barContainer)
                Destroy(child.gameObject);

            _actionBarSlots.Clear();

            for (int i = 0; i < maxSlots; i++)
            {
                var go = Instantiate(actionItemPrefab, barContainer);
                var item = go.GetComponent<ActionBarItem>();
                _actionBarSlots.Add(item);
            }
        }

        public void AddFigure(IFigure figure)
        {
            if (_figuresInBar.Count >= maxSlots)
            {
                Debug.Log("Бар заполнен! Вы проиграли.");
                return;
            }

            _figuresInBar.Add(figure);

            Debug.Log($"[ActionBar] Фигура добавлена: {figure.GroupId}");
            UpdateBar();

            CheckForMatch();
            CheckWinCondition();
        }

        private void UpdateBar()
        {
            for (int i = 0; i < _actionBarSlots.Count; i++)
            {
                if (i < _figuresInBar.Count)
                {
                    _actionBarSlots[i].SetFigure(_figuresInBar[i]);
                }
                else
                {
                    _actionBarSlots[i].Clear();
                }
            }
        }

        private void CheckForMatch()
        {
            var grouped = _figuresInBar
                .GroupBy(f => f.GroupId)
                .Where(g => g.Count() >= 3)
                .ToList();

            if (grouped.Count > 0)
            {
                foreach (var group in grouped)
                {
                    var matchedGroup = group.Take(3).ToList();

                    foreach (var figure in matchedGroup)
                    {
                        figure.OnMatch();
                        _figuresInBar.Remove(figure);
                    }

                    _matchCount++;

                    if (_matchCount >= MatchToThaw)
                    {
                        ThawAllFrozenFigures();
                        _matchCount = 0;
                    }
                }

                UpdateBar();
            }
        }

        private void ThawAllFrozenFigures()
        {
            var allFigureSystems = FindObjectsOfType<FigureSystem>();

            foreach (var figureSystem in allFigureSystems)
            {
                var figure = figureSystem.GetFigure();

                if (figure is FrozenFigureDecorator frozenFigure)
                {
                    frozenFigure.Thaw();
                }
            }

            Debug.Log("Все фигурки разморожены!");
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
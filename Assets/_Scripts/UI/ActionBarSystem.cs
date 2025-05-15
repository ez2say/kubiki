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
                    _actionBarSlots[i].Clear(); // например, делает слот серым или прозрачным
                }
            }
        }

        private void CheckForMatch()
        {
            var grouped = _figuresInBar
                .GroupBy(f => new
                {
                    f.Type.Shape,
                    AnimalName = f.Type.AnimalSprite.name,
                    Color = f.Type.FrameColor.ToColorString()
                })
                .Where(g => g.Count() >= 3)
                .ToList();

            if (grouped.Count > 0)
            {
                _matchCount++;

                foreach (var matched in grouped[0].Take(3))
                {
                    matched.OnMatch();
                    _figuresInBar.Remove(matched);
                }

                if (_matchCount >= MatchToThaw)
                {
                    foreach (var fig in _figuresInBar)
                    {
                        if (fig is FrozenFigureDecorator frozen)
                            frozen.Thaw();
                    }
                    _matchCount = 0;
                }

                UpdateBar();

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
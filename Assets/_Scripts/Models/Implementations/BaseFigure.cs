using UnityEngine;
using Models.Interfaces;
using Models.Types;
using Helpers;
using UI;
using Services;

namespace Models.Implementations
{
    public class BaseFigure : IFigure
    {
        private readonly FigureType _type;

        private readonly SpriteRenderer _shapeRenderer;
        private readonly SpriteRenderer _animalRenderer;

        private readonly GameObject _gameObject;


        public string GroupId => $"{_type.Shape}_{ColorToString(_type.FrameColor)}_{_type.AnimalSprite.name}";

        public BaseFigure(FigureType type, SpriteRenderer shapeRenderer, SpriteRenderer animalRenderer, GameObject gameObject)
        {
            _type = type;
            _shapeRenderer = shapeRenderer;
            _animalRenderer = animalRenderer;
            _gameObject = gameObject;


            UpdateVisuals();
        }

        public FigureType Type => _type;


        private void UpdateVisuals()
        {
            if (_shapeRenderer != null) _shapeRenderer.color = _type.FrameColor;
            if (_animalRenderer != null) _animalRenderer.sprite = _type.AnimalSprite;
        }

        public void OnClick()
        {
            _gameObject.SetActive(false);
            ActionBarSystem.Instance.AddFigure(this);
        }

        public void OnFall() => Debug.Log("Base figure falling");

        public void OnMatch()
        {
            Object.Destroy(_shapeRenderer.gameObject);
            FieldCountManager.Instance.UnregisterFigure();
        }

        public bool Matches(IFigure other)
        {
            if (other == null) return false;
            return GroupId == other.GroupId;
        }

        public Sprite GetShapeSprite() => _shapeRenderer.sprite;

        public static string ColorToString(Color color, int decimals = 2)
        {
            return $"{Mathf.Round(color.r * 100) / 100}_{Mathf.Round(color.g * 100) / 100}_{Mathf.Round(color.b * 100) / 100}";
        }
    }
}
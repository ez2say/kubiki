using UnityEngine;
using Models.Interfaces;
using Models.Types;
using Helpers;
using UI;

namespace Models.Implementations
{
    public class BaseFigure : MonoBehaviour, IFigure
    {
        private FigureType _type;
        [SerializeField] private SpriteRenderer shapeRenderer;
        [SerializeField] private SpriteRenderer animalRenderer;

        public FigureType Type => _type;

        private bool _addedToBar = false;
        public bool IsMatched { get; set; }

        public void Initialize(FigureType type)
        {
            _type = type;
            UpdateVisuals();
        }

        public Sprite GetShapeSprite()
        {
            return shapeRenderer?.sprite;
        }

        private void UpdateVisuals()
        {
            if (shapeRenderer != null)
                shapeRenderer.color = _type.FrameColor;

            if (animalRenderer != null)
                animalRenderer.sprite = _type.AnimalSprite;
        }

        public virtual void OnClick()
        {
            if (_addedToBar) return;

            ActionBarSystem.Instance.AddFigure(this);
            _addedToBar = true;

            Destroy(gameObject); // <-- Удаление с поля
        }

        public virtual void OnFall()
        {
        }


        public virtual void OnMatch()
        {
            if (!IsMatched)
            {
                IsMatched = true;
                Destroy(gameObject);
            }
        }

        public bool Matches(IFigure other)
        {
            return _type.Shape == other.Type.Shape &&
                   _type.FrameColor.ToColorString() == other.Type.FrameColor.ToColorString() &&
                   _type.AnimalSprite.name == other.Type.AnimalSprite.name;
        }

        private void OnMouseDown()
        {
            OnClick();
        }
    }
}
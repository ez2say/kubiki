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

        public void Initialize(FigureType type)
        {
            _type = type;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            if (shapeRenderer != null)
                shapeRenderer.color = _type.FrameColor;

            if (animalRenderer != null)
                animalRenderer.sprite = _type.AnimalSprite;
        }

        public void OnClick()
        {
            ActionBarSystem.Instance.AddFigure(this);
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
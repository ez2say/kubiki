using UnityEngine;
using Models.Interfaces;
using Models.Implementations;
using Models.Types.Specials;

namespace Models.Types
{
    public class FigureSystem : MonoBehaviour, IFigureSystem
    {
        [SerializeField] private SpriteRenderer shapeRenderer;
        [SerializeField] private SpriteRenderer animalRenderer;

        private IFigure _figure;
        private static FigureInputHandler _inputHandler;

        public void Initialize(FigureType type, FigureSpecialType specialType = FigureSpecialType.None)
        {
            _figure = new BaseFigure(type, shapeRenderer, animalRenderer, gameObject);

            if (specialType != FigureSpecialType.None)
            {
                ApplyDecorators(specialType);
            }

            if (_inputHandler == null)
            {
                _inputHandler = new FigureInputHandler();
            }

            _inputHandler.SubscribeToClicks(OnFigureClicked);
        }

        public void OnFigureClicked(IFigure clickedFigure)
        {
            if (clickedFigure == _figure)
            {
                _figure.OnClick();
            }
        }

        private void OnDestroy()
        {
            _inputHandler.UnsubscribeToClicks(OnFigureClicked);
        }

        private void ApplyDecorators(FigureSpecialType specialType)
        {
            switch (specialType)
            {
                case FigureSpecialType.Frozen:
                    _figure = new FrozenFigureDecorator(_figure, transform);
                    break;
                case FigureSpecialType.Heavy:
                    _figure = new HeavyFigureDecorator(_figure);
                    break;
                case FigureSpecialType.Sticky:
                    _figure = new StickyFigureDecorator(_figure);
                    break;
                case FigureSpecialType.Explosive:
                    _figure = new ExplosiveFigureDecorator(_figure);
                    break;
            }
        }

        public void OnFall() => _figure?.OnFall();
        public void OnMatch() => _figure?.OnMatch();
        public bool Matches(IFigure other) => _figure?.Matches(other) ?? false;
        public IFigure GetFigure() => _figure;
    }

}

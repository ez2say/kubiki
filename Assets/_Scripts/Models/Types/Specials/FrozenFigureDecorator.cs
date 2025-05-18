using UnityEngine;
using Models.Interfaces;
using Models.Types;

namespace Models.Types.Specials
{
    public class FrozenFigureDecorator : IFigure
    {
        private readonly IFigure _figure;
        private readonly SpriteRenderer _iceRenderer;
        private bool _isFrozen = true;

        public FigureType Type => _figure.Type;
        public string GroupId => _figure.GroupId;

        public FrozenFigureDecorator(IFigure figure, Transform parentTransform)
        {
            _figure = figure;

            Transform effectChild = parentTransform.Find("Visual");


            _iceRenderer = effectChild.GetComponent<SpriteRenderer>();

            Sprite iceSprite = Resources.Load<Sprite>("Effects/ice");
            _iceRenderer.sprite = iceSprite;
            _iceRenderer.enabled = true;
        }

        public void Thaw()
        {
            if (_iceRenderer != null)
                _iceRenderer.enabled = false;

            _isFrozen = false;
        }

        public void OnClick() { if (!_isFrozen) _figure.OnClick(); }
        public void OnFall() { if (!_isFrozen) _figure.OnFall(); }
        public void OnMatch() { if (!_isFrozen) _figure.OnMatch(); }
        public bool Matches(IFigure other) => _figure.Matches(other);
        public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    }
}
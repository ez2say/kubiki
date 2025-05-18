using Models.Interfaces;
using UnityEngine;
using System.Collections;


namespace Models.Types.Specials
{//TODO: Добавить вес через rigidbody.mass
    public class HeavyFigureDecorator : IFigure
    {
        public string GroupId { get; }
        public FigureType Type => _figure.Type;

        private readonly IFigure _figure;
        private float _fastDropDelay = 0.05f;

        public HeavyFigureDecorator(IFigure figure) => _figure = figure;

        public virtual void OnClick() => _figure.OnClick();

        public virtual void OnFall() => CoroutineRunner.Instance.StartCoroutine(FastFall());

        private IEnumerator FastFall()
        {
            yield return new WaitForSeconds(_fastDropDelay);
            Debug.Log("Heavy fall!");
        }

        public virtual void OnMatch() => _figure.OnMatch();

        public bool Matches(IFigure other) => _figure.Matches(other);

        public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    }
}
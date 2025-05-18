using System.Collections.Generic;
using UnityEngine;
using Models.Interfaces;

namespace Models.Types.Specials
{//TODO:Реализовать взрывной декоратор
    public class ExplosiveFigureDecorator : IFigure
    {
        public string GroupId { get; }
        
        private readonly IFigure _figure;
        private List<IFigure> _adjacentFigures = new();

        public ExplosiveFigureDecorator(IFigure figure) => _figure = figure;

        public FigureType Type => _figure.Type;

        public void OnClick() => _figure.OnClick();

        public void OnFall() => _figure.OnFall();

        public void OnMatch()
        {
            foreach (var fig in _adjacentFigures)
            {
                fig.OnMatch();
            }

            _figure.OnMatch();
        }

        public bool Matches(IFigure other) => _figure.Matches(other);
        public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    }
}

using Models.Interfaces;
using System.Collections.Generic;
using UnityEngine;


namespace Models.Types.Specials
{
    //TODO: Регистрация соседа и последующее его транспортировка вместе с основной фигурой
    public class StickyFigureDecorator : IFigure
    {
        public string GroupId { get; }
        public FigureType Type => _figure.Type;

        private readonly IFigure _figure;
        private List<IFigure> _adjacentFigures = new();


        public StickyFigureDecorator(IFigure figure) => _figure = figure;

        public void RegisterAdjacent(IEnumerable<IFigure> figures) => _adjacentFigures.AddRange(figures);


        public void OnClick() => _figure.OnClick();

        public void OnFall()
        {
            _figure.OnFall();
            foreach (var fig in _adjacentFigures)
            {
                fig.OnFall();
            }
        }

        public void OnMatch() => _figure.OnMatch();

        public bool Matches(IFigure other) => _figure.Matches(other);

        public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    }
}
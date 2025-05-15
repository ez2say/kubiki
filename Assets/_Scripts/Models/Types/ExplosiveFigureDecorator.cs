using Models.Interfaces;
using Models.Types;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFigureDecorator : IFigure
{
    private readonly IFigure _figure;
    private List<IFigure> _adjacentFigures = new();

    public FigureType Type => _figure.Type;
    public bool IsMatched { get; set; }
    public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    public ExplosiveFigureDecorator(IFigure figure) => _figure = figure;

    public void RegisterAdjacent(IEnumerable<IFigure> figures) => _adjacentFigures.AddRange(figures);

    public void Initialize(FigureType type)
    {
        _figure.Initialize(type);
    }
    public void OnClick() => _figure.OnClick();

    public void OnFall() => _figure.OnFall();

    public void OnMatch()
    {
        if (!IsMatched)
        {
            IsMatched = true;
            foreach (var fig in _adjacentFigures)
            {
                fig.OnMatch();
            }
            Object.Destroy(((MonoBehaviour)_figure).gameObject);
        }
    }

    public bool Matches(IFigure other) => _figure.Matches(other);
}
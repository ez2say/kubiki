using Models.Interfaces;
using Models.Types;
using System.Collections.Generic;
using UnityEngine;

public class StickyFigureDecorator : IFigure
{
    private readonly IFigure _figure;
    private List<IFigure> _adjacentFigures = new();

    public FigureType Type => _figure.Type;
    public bool IsMatched { get; set; }
    public Sprite GetShapeSprite() => _figure.GetShapeSprite();

    public StickyFigureDecorator(IFigure figure) => _figure = figure;

    public void RegisterAdjacent(IEnumerable<IFigure> figures) => _adjacentFigures.AddRange(figures);

    public void Initialize(FigureType type)
    {
        _figure.Initialize(type);
    }

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
}
using Models.Interfaces;
using Models.Types;
using UnityEngine;

public class FrozenFigureDecorator : IFigure
{
    private readonly IFigure _figure;
    private bool _isFrozen = true;

    public FigureType Type => _figure.Type;
    public bool IsMatched { get; set; }

    public FrozenFigureDecorator(IFigure figure) => _figure = figure;
    public Sprite GetShapeSprite() => _figure.GetShapeSprite();
    public void Initialize(FigureType type)
    {
        _figure.Initialize(type);
    }

    public void OnClick()
    {
        if (!_isFrozen)
            _figure.OnClick();
    }

    public void OnFall()
    {
        if (!_isFrozen)
            _figure.OnFall();
    }

    public void OnMatch()
    {
        if (!_isFrozen)
            _figure.OnMatch();
    }

    public void Thaw()
    {
        _isFrozen = false;
        Debug.Log("Figure thawed!");
    }

    public bool Matches(IFigure other) => _figure.Matches(other);
}
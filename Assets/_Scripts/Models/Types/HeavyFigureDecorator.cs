using Models.Interfaces;
using Models.Types;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class HeavyFigureDecorator : IFigure
{
    private readonly IFigure _figure;
    private float _fastDropDelay = 0.05f;

    public FigureType Type => _figure.Type;
    public bool IsMatched { get; set; }
    public Sprite GetShapeSprite() => _figure.GetShapeSprite();

    public HeavyFigureDecorator(IFigure figure)
    {
        _figure = figure;
    }

    public void Initialize(FigureType type)
    {
        _figure.Initialize(type);
    }

    public virtual void OnClick() => _figure.OnClick();

    public virtual void OnFall()
    {

        CoroutineRunner.Instance.StartCoroutine(FastFall());
    }

    private IEnumerator FastFall()
    {
        yield return new WaitForSeconds(_fastDropDelay);
        Debug.Log("Heavy fall!");
    }

    public virtual void OnMatch() => _figure.OnMatch();

    public bool Matches(IFigure other) => _figure.Matches(other);
}
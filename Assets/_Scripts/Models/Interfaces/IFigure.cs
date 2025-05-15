using Models.Types;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IFigure
    {
        FigureType Type { get; }
        bool IsMatched { get; set; }

        void OnClick();
        void OnFall();
        void OnMatch();
        bool Matches(IFigure other);
        void Initialize(FigureType figureType);

        Sprite GetShapeSprite();
    }
}
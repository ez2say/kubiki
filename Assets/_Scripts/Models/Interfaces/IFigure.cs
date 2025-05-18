using Models.Types;
using UnityEngine;

namespace Models.Interfaces
{
    public interface IFigure
    {
        string GroupId { get; }
        FigureType Type { get; }
        void OnClick();
        void OnFall();
        void OnMatch();
        bool Matches(IFigure other);
        Sprite GetShapeSprite();

    }
}
using Models.Types;

namespace Models.Interfaces
{
    public interface IFigure
    {
        FigureType Type { get; }
        void OnClick();
        bool Matches(IFigure other);
    }
}

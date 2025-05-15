using Models.Types;

namespace Models.Interfaces
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(FigureSpecialType specialType = FigureSpecialType.Normal);
    }
}
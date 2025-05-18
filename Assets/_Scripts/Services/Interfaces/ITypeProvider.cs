using System.Collections.Generic;
using Models.Types;

namespace Services.Interfaces
{
    public interface ITypeProvider
    {
        List<FigureType> GetAvailableTypes();
    }
}
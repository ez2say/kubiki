using System.Collections.Generic;
using Models.Types;

namespace Services
{
    public interface ITypeProvider
    {
        List<FigureType> GetAvailableTypes();
    }
}
using Models.Types;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IFigureTypeGenerationStrategy
    {
        List<FigureType> GenerateTypes(AnimalSprites animalSprites);
    }
}
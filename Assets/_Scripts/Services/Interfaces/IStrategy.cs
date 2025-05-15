using Models.Types;
using System.Collections.Generic;

namespace Services
{
    public interface IFigureTypeGenerationStrategy
    {
        List<FigureType> GenerateTypes(AnimalSprites animalSprites);
    }
}
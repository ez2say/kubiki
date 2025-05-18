
namespace Services
{
    public class FieldCountManager
    {
        private static FieldCountManager _instance;

        public static FieldCountManager Instance => _instance ??= new FieldCountManager();

        private int _figuresOnField = 0;

        public void RegisterFigure() => _figuresOnField++;

        public void UnregisterFigure() => _figuresOnField--;

        public bool IsFieldEmpty() => _figuresOnField <= 0;
        public void Reset() => _figuresOnField = 0;
    }
}


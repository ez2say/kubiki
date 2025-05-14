using UnityEngine;
using Models.Interfaces;
using Models.Types;
using Helpers;

namespace Models.Implementations
{
    public class FigureBase : MonoBehaviour, IFigure
    {
        public FigureType Type => _type;
        
        private FigureType _type;


        public void Initialize(FigureType type)
        {
            _type = type;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.color = _type.FrameColor;
                Debug.Log($"Created: {_type.Shape} - {_type.Animal} - {_type.FrameColor.ToColorString()}");
            }
        }

        public void OnClick()
        {
            Debug.Log($"Clicked on {_type.Shape} {_type.Animal}");
        }

        public bool Matches(IFigure other)
        {
            return _type.Shape == other.Type.Shape &&
                   _type.Animal == other.Type.Animal &&
                   _type.FrameColor.ToColorString() == other.Type.FrameColor.ToColorString();
        }
    }
}
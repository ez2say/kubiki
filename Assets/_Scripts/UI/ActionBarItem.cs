using UnityEngine;
using Models.Interfaces;
using UnityEngine.UI;

namespace UI
{
    public class ActionBarItem : MonoBehaviour
    {
        [SerializeField] private Image shapeImage;
        [SerializeField] private Image animalImage;

        public void SetFigure(IFigure figure)
        {
            if (shapeImage == null || animalImage == null)
            {
                Debug.LogError("ShapeImage или AnimalImage не назначены!");
                return;
            }

            Sprite shapeSprite = figure.GetShapeSprite();

            if (shapeSprite != null)
            {
                shapeImage.sprite = shapeSprite;
                shapeImage.color = figure.Type.FrameColor;
            }
            else
            {
                shapeImage.color = figure.Type.FrameColor;
            }

            animalImage.sprite = figure.Type.AnimalSprite;
        }

        public void Clear()
        {
            if (shapeImage != null) shapeImage.sprite = null;
            if (animalImage != null) animalImage.sprite = null;
        }
    }
}
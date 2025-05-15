using UnityEngine;
using Models.Interfaces;

namespace UI
{
    public class ActionBarItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer iconRenderer;

        public void SetFigure(IFigure figure)
        {
            iconRenderer.sprite = figure.Type.AnimalSprite;

        }
    }
}
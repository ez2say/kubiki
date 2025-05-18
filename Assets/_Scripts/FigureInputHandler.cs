using UnityEngine;
using Game;
using Models.Interfaces;
using UnityEngine.InputSystem;
using System;
using Models.Types;

public class FigureInputHandler
{
    private readonly InputHandler inputHandler;

    public event Action<IFigure> OnFigureClickedEvent;

    public FigureInputHandler()
    {
        inputHandler = new InputHandler();
        inputHandler.Enable();

        inputHandler.GameInput.AddCallbacks(new InputActions());
        inputHandler.GameInput.Click.started += HandleClick;
    }

    private void HandleClick(InputAction.CallbackContext context)
    {
        Vector2 tapPosition = Mouse.current.position.ReadValue();
        Debug.Log($"[Input] Позиция клика: {tapPosition}");

        Ray ray = Camera.main.ScreenPointToRay(tapPosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            var figureSystem = hit.collider.GetComponent<FigureSystem>();

            IFigure figure = figureSystem?.GetFigure();

            OnFigureClickedEvent?.Invoke(figure);
        }
        else
        {
            Debug.Log("[Input] Нет попадания по Collider");
        }
    }

    public void SubscribeToClicks(System.Action<IFigure> callback)
    {
        OnFigureClickedEvent += callback;
    }

    public void UnsubscribeToClicks(System.Action<IFigure> callback)
    {
        OnFigureClickedEvent -= callback;
    }

    public void Dispose()
    {
        inputHandler.GameInput.Click.started -= HandleClick;
        inputHandler.Dispose();
    }

    private class InputActions : InputHandler.IGameInputActions
    {
        public void OnClick(InputAction.CallbackContext context) { }
    }
}
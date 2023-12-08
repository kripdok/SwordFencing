using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : ISubscriber
{
    private static PlayerInput _instance;

    private Camera _camera;

    public InputController Controller { get; private set; }

    public delegate void StartTouch(Vector2 position, float time);
    public delegate void EndTouch(Vector2 position, float time);

    public event StartTouch OnStartTouch;
    public event EndTouch OnEndTouch;

    public event UnityAction OnStart;
    public event UnityAction OnEnd;
    public event UnityAction<Vector3> OnMultiTap;

    public static PlayerInput Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerInput();
            }

            return _instance;
        }
    }

    private PlayerInput()
    {
        Controller = new InputController();
        Controller.Disable();

        Controller.Touch.MultiTap.performed += ctx => MultiTap();
        Controller.Touch.Contact.started += ctx => StartTouchPrimary(ctx);
        Controller.Touch.Contact.canceled += ctx => EndTouchPrimary(ctx);
    }

    public void Initialize(Camera camera)
    {
        _camera = camera;
    }

    public void OnEnables()
    {
        EventBus.Instance.Subscribe<DisablePlayerControlSignal>(DisableController);
        EventBus.Instance.Subscribe<EnablePlayerControlSignal>(EnableController);

    }

    public void OnDisables()
    {
        EventBus.Instance.UnSubscribe<DisablePlayerControlSignal>(DisableController);
        EventBus.Instance.UnSubscribe<EnablePlayerControlSignal>(EnableController);
        Controller.Disable();
    }

    public Vector2 GetMovePosition()
    {
        Vector2 position = Controller.Touch.Move.ReadValue<Vector2>();
        return _camera.ScreenToWorldPoint(position);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            OnStart?.Invoke();
            OnStartTouch(ScrineToWorld(Controller.Touch.Move.ReadValue<Vector2>()), (float)context.startTime);
        }
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEnd?.Invoke();
            OnEndTouch(ScrineToWorld(Controller.Touch.Move.ReadValue<Vector2>()), (float)context.time);
        }
    }

    private Vector3 ScrineToWorld(Vector3 position)
    {
        position.z = 0;
        return _camera.ScreenToWorldPoint(position);
    }

    private void MultiTap()
    {
        Vector3 tapPosition = ScrineToWorld(Controller.Touch.Move.ReadValue<Vector2>());
        OnMultiTap.Invoke(tapPosition);
    }

    private void EnableController(EnablePlayerControlSignal signal)
    {
        Controller.Enable();
    }

    private void DisableController(DisablePlayerControlSignal signal)
    {
        Controller.Disable();
    }
}
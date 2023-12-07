using System.Collections;
using UnityEngine;

public class ContactPointerController : ISubscriber
{
    private ContactPointer _pointer;
    private Coroutine _coroutine;
    private PlayerInput _input;
    private bool _isActive = false;

    public ContactPointerController(PlayerInput input, ContactPointer pointer)
    {
        _pointer = pointer;
        _pointer.gameObject.SetActive(false);
        _input = input;
    }

    public void OnEnables()
    {
        _input.OnStart += StartMoving;
        _input.OnEnd += EndMoving;
    }

    public void OnDisables()
    {
        _input.OnStart -= StartMoving;
        _input.OnEnd -= EndMoving;
    }

    private void StartMoving()
    {
        _isActive = true;
        _pointer.transform.position = _input.GetMovePosition();
        _pointer.gameObject.SetActive(true);

        if (_coroutine != null)
        {
            Coroutines.StopRoutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = Coroutines.StartRoutine(Moving());
    }

    private IEnumerator Moving()
    {
        while (_isActive)
        {
            yield return null;
            _pointer.transform.position = _input.GetMovePosition();
        }
    }

    private void EndMoving()
    {
        _pointer.gameObject.SetActive(false);
        _isActive = false;
    }
}
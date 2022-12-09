using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controls : MonoBehaviour
{
    // I was a bit lazy with the controls so I decided not to make any additional abstractions and straight up copypasted
    
    

    [SerializeField]
    private float _speed = 5f;

    public float moveInputFloat = 0;

    private InputManager _inputManager;
    private PhotonView _view;

    private void Awake()
    {
        _inputManager = new InputManager();
        _view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (_view.IsMine)
        {
            Move(_speed, moveInputFloat, Time.deltaTime);
        }
    }


    private void InputContextReader(InputAction.CallbackContext context)
    {
         moveInputFloat = context.ReadValue<float>();
    }


    protected void Move(float speed, float inputAxis, float time)
    {
        if (inputAxis == 0) return;
        var z = speed * inputAxis * time;
        transform.Translate(0, 0, z, Space.World);
    }

    private void OnEnable()
    {
        _inputManager.Player2.Move.performed += InputContextReader;
        _inputManager.Player2.Move.canceled += InputContextReader;
        _inputManager.Enable();
    }

    private void OnDisable()
    {
        _inputManager.Player2.Move.performed -= InputContextReader;
        _inputManager.Disable();
    }
}

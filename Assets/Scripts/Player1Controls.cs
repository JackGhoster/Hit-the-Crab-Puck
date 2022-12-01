using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controls : MonoBehaviour
{
    private InputManager _inputManager;

    [SerializeField]
    private float _speed = 5f;

    public float moveInputFloat = 0; 
    

    private void Awake()
    {
        _inputManager = new InputManager();
    }

    void Update()
    {
        Move(_speed, moveInputFloat, Time.deltaTime);
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
        _inputManager.Player1.Move.performed += InputContextReader;
        _inputManager.Player1.Move.canceled += InputContextReader;
        _inputManager.Enable();
    }

    private void OnDisable()
    {
        _inputManager.Player1.Move.performed -= InputContextReader;
        _inputManager.Disable();
    }
}

using SSE.Core.Abstractions.Controllers;
using SSE.Core.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SSE.Player.Controllers
{
    /// <summary>
    /// Контроллер игрока
    /// </summary>
    [RequireComponent(typeof(MoveController), typeof(RotateController), typeof(JumpController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RotateController cameraRotateController;

        private IMoving _moveController;
        private IRotating _playerRotateController;
        private IRotating _cameraRotateController;
        private IJumping _jumpController;
        private IRunning _runController;
        
        private Vector2 _moveDirection;
        private Vector2 _lookDirection;
        
        private PlayerInputSystem _playerInput;

        private void Awake()
        {
            _moveController = GetComponent<IMoving>();
            _playerRotateController = GetComponent<IRotating>();
            _cameraRotateController = cameraRotateController;
            _jumpController = GetComponent<IJumping>();
            _runController = GetComponent<IRunning>();
            _playerInput = new PlayerInputSystem();
            
            _moveDirection = new Vector2();
            _lookDirection = new Vector2();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Move.performed +=  Move;
            _playerInput.Player.Move.canceled += Move;
            _playerInput.Player.Look.performed += Look;
            _playerInput.Player.Jump.performed += Jump;
            _playerInput.Player.Run.started += StartRun;
            _playerInput.Player.Run.canceled +=  StopRun;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Move.performed -=  Move;
            _playerInput.Player.Move.canceled -= Move;
            _playerInput.Player.Look.performed -= Look;
            _playerInput.Player.Jump.performed -= Jump;
            _playerInput.Player.Run.started -= StartRun;
            _playerInput.Player.Run.canceled -=  StopRun;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            _moveController.Interact(_moveDirection);
        }
        
        private void Look(InputAction.CallbackContext ctx)
        {
            _lookDirection = _playerInput.Player.Look.ReadValue<Vector2>();
            _playerRotateController.Interact(new Vector3(0f, _lookDirection.x, 0f));
            _cameraRotateController.Interact(new Vector3(-_lookDirection.y, 0f, 0f));
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            _jumpController.Jump();
        }

        private void StartRun(InputAction.CallbackContext ctx)
        {
            _runController.Run(_moveController);
        }
        
        private void StopRun(InputAction.CallbackContext ctx)
        {
            _runController.StopRun(_moveController);
        }
    }
}
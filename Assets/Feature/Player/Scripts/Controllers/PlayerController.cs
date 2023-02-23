using SSE.Core.Abstractions.Controllers;
using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Controllers;
using SSE.Movement.Gravity.Abstractions.Controllers;
using SSE.Movement.Jump.Abstractions.Controller;
using SSE.Movement.Jump.Controller;
using SSE.Movement.Move.Abstractions.Controller;
using SSE.Movement.Move.Controller;
using SSE.Movement.Rotate.Abstractions.Controller;
using SSE.Movement.Rotate.Controller;
using SSE.Movement.Run.Abstractions.Controllers;
using SSE.Movement.Run.Controllers;
using SSE.Movement.Squat.Abstractions.Controller;
using SSE.Movement.Squat.Controller;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SSE.Player.Controllers
{
    /// <summary>
    /// Контроллер игрока
    /// </summary>
    [RequireComponent(typeof(CharacterController),typeof(MoveController), typeof(RotateController))]
    [RequireComponent(typeof(RunController), typeof(JumpController), typeof(SquatController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RotateController cameraRotateController;
        [SerializeField] private SurfaceDetector surfaceDownDetector;
        [SerializeField] private SurfaceDetector surfaceUpDetector;
        [SerializeField] private AccessBarController accessBarController;

        private CharacterController _characterController;
        private IMoving _moveController;
        private IGravitational _gravitateController;
        private IRotating _playerRotateController;
        private IRotating _cameraRotateController;
        private IJumping _jumpController;
        private IRunning _runController;
        private ISquat _squatController;

        private IAccessBar _accessBar;
        
        private Vector2 _moveDirection;
        private Vector2 _lookDirection;
        
        private PlayerInputSystem _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInputSystem();
            _characterController = GetComponent<CharacterController>();
            _moveController = GetComponent<IMoving>();
            _playerRotateController = GetComponent<IRotating>();
            _cameraRotateController = cameraRotateController;
            _jumpController = GetComponent<IJumping>();
            _runController = GetComponent<IRunning>();
            _squatController = GetComponent<ISquat>();
            _gravitateController = GetComponent<IGravitational>();
            
            Init();

            _accessBar = accessBarController;
            
            _moveDirection = new Vector2();
            _lookDirection = new Vector2();
        }

        private void Init()
        {
            _moveController.Init(_characterController);
            _jumpController.Init(_characterController, _gravitateController, surfaceDownDetector);
            _squatController.Init(_characterController, surfaceUpDetector, surfaceDownDetector);
            _gravitateController.Init(_characterController, surfaceDownDetector);
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Move.performed += Move;
            _playerInput.Player.Move.canceled += Move;
            _playerInput.Player.Look.performed += Look;
            _playerInput.Player.Jump.performed += Jump;
            _playerInput.Player.Run.started += StartRun;
            _playerInput.Player.Run.canceled +=  StopRun;
            _playerInput.Player.Squat.started += SitDown;
            _playerInput.Player.Squat.canceled += StandUp;
            _playerInput.AccessBar.KeyBoard.performed += ChooseObjectOnAccessBar;
            
            ((IRestricting)_squatController).AddRestricts(
                ((ICanRestrict)_jumpController).RestrictProperty, 
                ((ICanRestrict)_runController).RestrictProperty);
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
            _playerInput.Player.Squat.started -= SitDown;
            _playerInput.Player.Squat.canceled -= StandUp;
            _playerInput.AccessBar.KeyBoard.performed -= ChooseObjectOnAccessBar;
            
            ((IRestricting)_squatController).RemoveRestricts(
                ((ICanRestrict)_jumpController).RestrictProperty, 
                ((ICanRestrict)_runController).RestrictProperty);
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Move(InputAction.CallbackContext ctx)
        {
            _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            _moveController.Move(_moveDirection);
        }
        
        private void Look(InputAction.CallbackContext ctx)
        {
            _lookDirection = _playerInput.Player.Look.ReadValue<Vector2>();
            _playerRotateController.Rotate(new Vector3(0f, _lookDirection.x, 0f));
            _cameraRotateController.Rotate(new Vector3(-_lookDirection.y, 0f, 0f));
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

        private void SitDown(InputAction.CallbackContext ctx)
        {
            _squatController.SitDown(_moveController);
        }
        
        private void StandUp(InputAction.CallbackContext ctx)
        {
            _squatController.StandUp(_moveController);
        }
        
        private void ChooseObjectOnAccessBar(InputAction.CallbackContext ctx)
        {
            var number = _playerInput.AccessBar.KeyBoard.ReadValue<float>();
            if (number == 0)
                return;
            _accessBar.Choose((int)number);
        }
    }
}
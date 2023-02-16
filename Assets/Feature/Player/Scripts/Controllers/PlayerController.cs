using SSE.Core.Abstractions.Controllers;
using SSE.Core.Controllers;
using UnityEngine;

namespace SSE.Player.Controllers
{
    /// <summary>
    /// Контроллер игрока
    /// </summary>
    [RequireComponent(typeof(MoveController), typeof(RotateController), typeof(JumpController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private RotateController cameraRotateController;

        private Transform _transform;
        private IMoving _moveController;
        private IRotating _playerRotateController;
        private IRotating _cameraRotateController;
        private IJumping _jumpController;
        private IRunning _runController;
        private Vector3 _direction;

        private float _xRotation = 0;
        private float _yRotation = 0;

        private void Awake()
        {
            _moveController = GetComponent<IMoving>();
            _playerRotateController = GetComponent<IRotating>();
            _cameraRotateController = cameraRotateController;
            _jumpController = GetComponent<IJumping>();
            _runController = GetComponent<IRunning>();
            
            _direction = new Vector3();
            _transform = transform;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
                _jumpController.Jump();
            else if (Input.GetKeyDown(KeyCode.LeftShift))
                _runController.Run(_moveController);
            else if (Input.GetKeyUp(KeyCode.LeftShift))
                _runController.StopRun(_moveController);
                
            _xRotation -= Input.GetAxis("Mouse Y");
            _yRotation += Input.GetAxis("Mouse X");
            
            _xRotation = Mathf.Clamp(_xRotation, -9f, 9f);
            
            _direction.x = Input.GetAxis("Horizontal");
            _direction.z = Input.GetAxis("Vertical");
            
            _moveController.Interact(_transform.right * _direction.x + _transform.forward * _direction.z);
            _playerRotateController.Interact(new Vector3(0f, _yRotation, 0f));
            _cameraRotateController.Interact(new Vector3(_xRotation, 0f, 0f));
        }
    }
}
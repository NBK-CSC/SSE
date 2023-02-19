using SSE.Core.Abstractions.Controllers;
using System;
using System.Threading;
using System.Threading.Tasks;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер приседания
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class SquatController : BaseInteractController, ISquat, ICanRestrict, IRestricting
    {
        [SerializeField] private float boostCoef;
        [SerializeField] private Transform transformCamera;
        [SerializeField] private Transform positionSquatCamera;
        [SerializeField] private float heightSquatCharacterController;
        [SerializeField] private float speed = 2f;
        [SerializeField] private AnimationCurve curve;

        private CharacterController _characterController;
        private CancellationTokenSource _tokenSourceSitDown;
        private CancellationTokenSource _tokenSourceStandUp;
        private ISurfaceDetecting _surfaceDownDetector;
        private ISurfaceDetecting _surfaceUpDetector;
        private IMoving _moveController;

        private IRestricting _restricting;
        
        private Vector3 _startCameraPosition;
        private float _startHeightCharacterController;
        private Vector3 _centerStartPosition;
        private Vector3 _centerSquatPosition;

        public IRestricted RestrictProperty { get; } = new RestrictionProperty();

        public override event Action<bool> OnInteracted;

        private void Awake()
        {
            _tokenSourceSitDown = new CancellationTokenSource();
            _tokenSourceStandUp = new CancellationTokenSource();
            
            _startCameraPosition = transformCamera.localPosition;
        }

        public void Init(CharacterController characterController, ISurfaceDetecting surfaceUpDetector, ISurfaceDetecting surfaceDownDetector)
        {
            _characterController = characterController;
            _surfaceDownDetector = surfaceDownDetector;
            _surfaceUpDetector = surfaceUpDetector;
            _startHeightCharacterController = _characterController.height;
            _centerStartPosition = _characterController.center;
            _centerSquatPosition = _centerStartPosition - new Vector3(0, heightSquatCharacterController / 2, 0);

            _restricting = new RestrictController(this, gameObject);
        }

        public void AddRestricts(params IRestricted[] restricts) => _restricting.AddRestricts(restricts);
        
        public void RemoveRestricts(params IRestricted[] restricts) => _restricting.RemoveRestricts(restricts);

        public void SitDown(IBoostChangeable boostChangeable)
        {
            if (!_surfaceDownDetector.IsOnSurface || RestrictProperty.IsRestrict)
                return;
            OnInteracted?.Invoke(true);
            boostChangeable.AddBoost(boostCoef);
            _tokenSourceSitDown.Cancel();
            _tokenSourceStandUp.Cancel();
            _tokenSourceSitDown = new CancellationTokenSource();

            SetPosition(
                positionSquatCamera.localPosition, 
                _centerSquatPosition, 
                heightSquatCharacterController, 
                _tokenSourceSitDown.Token);
        }

        public async void StandUp(IBoostChangeable boostChangeable)
        {
            if (!_surfaceDownDetector.IsOnSurface || RestrictProperty.IsRestrict)
                return;
            _tokenSourceSitDown.Cancel();
            _tokenSourceStandUp.Cancel();
            _tokenSourceStandUp = new CancellationTokenSource();
            while (_surfaceUpDetector.IsOnSurface && !_tokenSourceStandUp.Token.IsCancellationRequested)
                await Task.Yield();
            OnInteracted?.Invoke(false);
            if (_tokenSourceStandUp.Token.IsCancellationRequested){
                return;
            }

            boostChangeable.RemoveBoost();

            SetPosition(
                _startCameraPosition,
                _centerStartPosition, 
                _startHeightCharacterController, 
                _tokenSourceStandUp.Token);
        }

        private void SetPosition(Vector3 endPosition, Vector3 characterCenter, float characterHeight, CancellationToken token)
        {
            _characterController.height = characterHeight;
            _characterController.center = characterCenter;
            SetCameraPosition(transformCamera.localPosition, endPosition, token);
        }
        
        private async Task SetCameraPosition(Vector3 startPosition, Vector3 endPosition, CancellationToken token)
        {
            var time = 0f;
            while (startPosition.Equals(endPosition) == false && !token.IsCancellationRequested)
            {
                if (time > 1f)
                {
                    transformCamera.localPosition = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(time));
                    break; 
                }
                transformCamera.localPosition = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(time));
                time += Time.deltaTime * speed;
                await Task.Delay((int)(Time.deltaTime * 1000), token);
            }
        }
    }
}
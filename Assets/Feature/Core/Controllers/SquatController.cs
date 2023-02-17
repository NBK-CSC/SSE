using SSE.Core.Abstractions.Controllers;
using System;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер приседания
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class SquatController : BaseInteractController, ISquatable
    {
        [SerializeField] private float boostCoef;
        [SerializeField] private Transform transformCamera;
        [SerializeField] private Transform positionSquatCamera;
        [SerializeField] private float heightSquatCharacterController;

        private CharacterController _characterController;
        private Vector3 _startCameraPosition;
        private float _startHeightCharacterController;

        public override event Action<bool> OnInteracted;

        private void Awake()
        {
            _startCameraPosition = transformCamera.localPosition;
            _characterController = GetComponent<CharacterController>();
            _startHeightCharacterController = _characterController.height;
        }
        
        public void Squat(IMoving moveController)
        {
            moveController.AddBoost(boostCoef);
            transformCamera.localPosition = positionSquatCamera.localPosition;
            _characterController.height = heightSquatCharacterController; 
            _characterController.center -= new Vector3(0, heightSquatCharacterController/2, 0);
            OnInteracted?.Invoke(true);
        }
        
        public void StandUp(IMoving moveController)
        {
            moveController.RemoveBoost();
            transformCamera.localPosition = _startCameraPosition;
            _characterController.height = _startHeightCharacterController;
            _characterController.center += new Vector3(0, heightSquatCharacterController/2, 0);
            OnInteracted?.Invoke(false);
        }
    }
}
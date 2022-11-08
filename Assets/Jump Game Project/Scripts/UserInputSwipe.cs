using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Jump_Game_Project.Scripts
{
    public class UserInputSwipe: ISwipe
    {
        /// <summary>
        /// The value MaxTime must be between 0.1 and 1
        /// </summary>
        public float MaxTime
        {
            get => _maxTime;

            set
            {
                if (value <= 0 || value > 1)
                    throw new ArgumentOutOfRangeException("MaxTime",value, "The value must be between 0.1 and 1");
                
                _maxTime = value;
            }
        }

        /// <summary>
        /// The value MaxDistance must be between 0.1 and 1
        /// </summary>
        public float MinDistance
        {
            get => _minDistance;
            set
            {
                if (value <= 0 || value > 1)
                    throw new ArgumentOutOfRangeException("MinDistance", value, "The value must be between 0.1 and 1");
                    
                _minDistance = value;
            }
        }

        #region Events

        public event ISwipe.ActionUp Up;
        public event ISwipe.ActionDown Down;
        public event ISwipe.ActionRight Right;
        public event ISwipe.ActionLeft Left;

        #endregion

        private float _maxTime = 0.5f;
        private float _minDistance = 0.2f;

        private readonly InputAction _touchPress;
        private readonly InputAction _touchPosition;

        private Vector2 _startedPosition;
        private Vector2 _endedPosition;

        private float _startedTime;
        private float _endedTime;

        public UserInputSwipe(InputAction touchPress, InputAction touchPosition)
        {
            _touchPress = touchPress;
            _touchPosition = touchPosition;

            _touchPress.started += StartedTouch;
            _touchPress.canceled += EndedTouch;
        }

        ~UserInputSwipe()
        {
            _touchPress.started -= StartedTouch;
            _touchPress.canceled -= EndedTouch;
        }

        public void Enable()
        {
            _touchPress?.Enable();
        }

        public void Disable()
        {
            _touchPress?.Disable();
        }

        private void StartedTouch(InputAction.CallbackContext obj)
        {
            _startedPosition = _touchPosition.ReadValue<Vector2>();
            _startedTime = (float)obj.startTime;
        }

        private void EndedTouch(InputAction.CallbackContext obj)
        {
            _endedPosition = _touchPosition.ReadValue<Vector2>();
            _endedTime = (float)obj.time;
            SwipeDetector();
        }

        private void SwipeDetector()
        {
            if (_endedTime - _startedTime > _maxTime) return;
            if (Vector2.Distance(_startedPosition, _endedPosition) < _minDistance) return;

            Debug.Log("Swipe detected");

            Vector2 direction = (_endedPosition - _startedPosition).normalized;
            SwipeDirection(direction);
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > 0.9f)
                Up?.Invoke();

            else if (Vector2.Dot(Vector2.down, direction) > 0.9f)
                Down?.Invoke();

            else if (Vector2.Dot(Vector2.right, direction) > 0.9f)
                Right?.Invoke();

            else if (Vector2.Dot(Vector2.left, direction) > 0.9f)
                Left?.Invoke();
        }
    }
}
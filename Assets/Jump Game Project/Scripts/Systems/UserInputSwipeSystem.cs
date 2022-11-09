using Assets.Jump_Game_Project.Scripts.Components;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Jump_Game_Project.Scripts.Systemss
{
    public class UserInputSwipeSystem : ComponentSystem
    {
        private EntityQuery _inputQuery;
        private UserControls _inputAction;

        private bool _swipeUp;
        private bool _swipeDown;
        private bool _swipeLeft;
        private bool _swipeRight;

        private float2 _startedPosition;
        private float2 _endedPosition;

        private float _startedTime;
        private float _endedTime;

        private float _minDistance;
        private float _maxTime;

        protected override void OnCreate()
        {
            _inputAction = new UserControls();
            
            _inputAction.Playeractionmap.PrimaryContact.started += StartedContact;
            _inputAction.Playeractionmap.PrimaryContact.canceled += EndedContact;
            
            _inputAction.Enable();
            
            _inputQuery = GetEntityQuery(
                ComponentType.ReadOnly<InputSwipeData>());
        }

        protected override void OnStopRunning()
        {
            _inputAction.Disable();
        }

        protected override void OnUpdate()
        {
            Entities.With(_inputQuery).ForEach(
                (Entity entity, ref InputSwipeData inputSwipeData) =>
                {
                    _maxTime = inputSwipeData.MaxTime;
                    _minDistance = inputSwipeData.MinDistance;
                    inputSwipeData.SwipeUp = _swipeUp;
                    inputSwipeData.SwipeDown = _swipeDown;
                    inputSwipeData.SwipeLeft = _swipeLeft;
                    inputSwipeData.SwipeRight = _swipeRight;
                });
        }

        private void StartedContact(InputAction.CallbackContext obj)
        {
            _startedPosition = _inputAction.Playeractionmap.PrimaryPosition.ReadValue<Vector2>();
            _startedTime = (float)obj.startTime;
        }

        private void EndedContact(InputAction.CallbackContext obj)
        {
            _endedPosition = _inputAction.Playeractionmap.PrimaryPosition.ReadValue<Vector2>();
            _endedTime = (float)obj.time;
            SwipeDetector();
        }

        private void SwipeDetector()
        {
            if (_endedTime - _startedTime > _maxTime) return;
            if (math.distance(_startedPosition, _endedPosition) < _minDistance) return;

            Debug.Log("Swiped");

            float2 direction = math.normalize(_endedPosition - _startedPosition);
            SwipeDirection(direction);
        }

        private void SwipeDirection(float2 direction)
        {
            if (math.dot(new float2(0, 1), direction) > 0.9f)
            {
                _swipeUp = true;
                Debug.Log("Swipe Up");
            }

            else if (math.dot(new float2(0, -1), direction) > 0.9f)
                _swipeDown = true;

            else if (math.dot(new float2(1, 0), direction) > 0.9f)
                _swipeRight = true;

            else if (math.dot(new float2(-1, 0), direction) > 0.9f)
                _swipeLeft = true;

            SwipeReset();
        }

        private void SwipeReset()
        {
            _swipeUp = false;
            _swipeDown = false;
            _swipeLeft = false;
            _swipeRight = false;
        }
    }
}
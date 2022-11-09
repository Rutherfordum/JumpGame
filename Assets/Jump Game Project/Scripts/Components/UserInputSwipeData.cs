using System;
using Unity.Entities;
using UnityEngine;

namespace Assets.Jump_Game_Project.Scripts.Components
{
    public class UserInputSwipeData: MonoBehaviour, IConvertGameObjectToEntity
    {
        [SerializeField][Range(0.1f,1f)]
        private float _minDistance = 0.2f;
        
        [SerializeField][Range(0.1f, 1f)]
        private float _maxTime = 0.5f;

        public bool swipeUp;

        public float MaxTime
        {
            get => _maxTime;

            set
            {
                if (value <= 0 || value > 1)
                    throw new ArgumentOutOfRangeException("MaxTime", value, "The value must be between 0.1 and 1");

                _maxTime = value;
            }
        }
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

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new InputSwipeData()
            {
                MaxTime = this.MaxTime,
                MinDistance = this.MinDistance
            });
        }
    }

    public struct InputSwipeData : IComponentData
    {
        public float MinDistance;
        public float MaxTime;
        public bool SwipeUp;
        public bool SwipeDown;
        public bool SwipeLeft;
        public bool SwipeRight;
    }
}
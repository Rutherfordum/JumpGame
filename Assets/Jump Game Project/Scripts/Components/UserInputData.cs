using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Jump_Game_Project.Scripts.Components
{
    public class UserInputData: MonoBehaviour, IConvertGameObjectToEntity
    {
        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new InputData());
        }
    }

    public struct InputData : IComponentData
    {
        public float2 Swipe;
    }
}
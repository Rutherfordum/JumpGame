using Unity.Entities;
using UnityEngine.InputSystem;

namespace Assets.Jump_Game_Project.Scripts.Systemss
{
    public class UserInputSwipeSystem: ComponentSystem
    {
        private EntityQuery _inputQuery;
        private UserControls _inputAction;

        protected override void OnCreate()
        {
            _inputAction = new UserControls();
            _inputAction.Playeractionmap.PrimaryContact.started += StartedContact;
            _inputAction.Playeractionmap.PrimaryContact.canceled += EndedContact;
        }

        protected override void OnUpdate()
        {

        }


        private void StartedContact(InputAction.CallbackContext obj)
        {

        }
        private void EndedContact(InputAction.CallbackContext obj)
        {

        }
        
    }
}
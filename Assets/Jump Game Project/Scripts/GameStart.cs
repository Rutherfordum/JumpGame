using TMPro;
using UnityEngine;

namespace Assets.Jump_Game_Project.Scripts
{
    public class GameStart: MonoBehaviour
    {
        private UserInputAction userInputAction;
        private ISwipe userInputSwipe;

        private void Awake()
        {
            userInputAction = new UserInputAction();

            userInputSwipe = new UserInputSwipe(userInputAction.PlayerSwipe.TouchPress,
                userInputAction.PlayerSwipe.TouchPosition);
        }

        void OnEnable()
        {
            userInputAction?.Enable();
        }

        void OnDisable()
        {
            userInputAction?.Disable();
        }
    }
}
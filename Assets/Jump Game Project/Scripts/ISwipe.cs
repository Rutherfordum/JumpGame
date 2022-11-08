namespace Assets.Jump_Game_Project.Scripts
{
    public interface ISwipe
    {
        public delegate void ActionUp();
        public event ActionUp Up;

        public delegate void ActionDown();
        public event ActionDown Down;

        public delegate void ActionRight();
        public event ActionRight Right;

        public delegate void ActionLeft();
        public event ActionLeft Left;
    }
}
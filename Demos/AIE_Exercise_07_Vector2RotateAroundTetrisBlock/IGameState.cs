namespace AIE_Exercise_07_Vector2RotateAroundTetrisBlock
{
    class IGameState
    {
        protected Program program;

        public IGameState(Program program)
        {
            this.program = program;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}

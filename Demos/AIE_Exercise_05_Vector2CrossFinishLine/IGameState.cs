namespace AIE_Exercise_05_Vector2CrossFinishLine
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

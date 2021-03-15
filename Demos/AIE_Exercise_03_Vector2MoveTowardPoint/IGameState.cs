namespace AIE_Exercise_03_Vector2MoveTowardPoint
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

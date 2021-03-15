namespace AIE_Exercise_08_Vetor2ReflectDemo
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

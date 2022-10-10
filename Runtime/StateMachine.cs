namespace States
{
    public class StateMachine<TContext, TState> where TState : IState<TContext>
    {
        private readonly TContext _context;
        private TState _state;

        protected TContext Context
        {
            get { return _context; }
        }
        
        public TState State
        {
            get => _state;
            set
            {
                var prevState = _state;
                prevState?.OnExit(_context, _state);

                _state = value;

                _state?.OnEnter(_context, prevState);
            }
        }

        public StateMachine(TContext context)
        {
            _context = context;
        }

        public void Update(float deltaTime)
        {
            State?.OnUpdate(_context, deltaTime);
        }

        public void FixedUpdate(float deltaTime)
        {
            State?.OnFixedUpdate(_context, deltaTime);
        }

        public void LateUpdate(float deltaTime)
        {
            State?.OnLateUpdate(_context, deltaTime);
        }
    }
}
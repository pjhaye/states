namespace States
{
    public interface IState<T> 
    {
        void OnEnter(T context, IState<T> prevState);
        void OnFixedUpdate(T context, float deltaTime);
        void OnUpdate(T context, float deltaTime);
        void OnLateUpdate(T context, float deltatTime);
        void OnExit(T context, IState<T> nextState);
    }
}
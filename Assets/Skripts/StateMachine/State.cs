public abstract class State
{
    protected float Runtime;
    protected float ConcreteRuntime;

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }

}
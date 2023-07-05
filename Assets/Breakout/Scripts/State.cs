using System.Collections;
public abstract class State
{
    protected ChangeState ChangeState;

    public State(ChangeState changeState)
    {
        ChangeState = changeState;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }
}

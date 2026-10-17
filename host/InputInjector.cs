namespace SofaTap;

public interface IInputInjector
{
    bool Available { get; }
    void Apply(ActionMessage action);
    void ReleaseAll();
}

public sealed class InputInjectionException(string message) : Exception(message);

public sealed class DryRunInput : IInputInjector
{
    public bool Available => false;
    public void Apply(ActionMessage action) { }
    public void ReleaseAll() { }
}

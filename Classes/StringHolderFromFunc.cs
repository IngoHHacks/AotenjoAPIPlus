namespace AotenjoAPIPlus.Classes;

public class StringHolderFromFunc : StringHolder
{
    private readonly Func<string> _func;

    public StringHolderFromFunc(Func<string> func)
    {
        _func = func;
    }

    public override string GetString()
    {
        return _func();
    }
}
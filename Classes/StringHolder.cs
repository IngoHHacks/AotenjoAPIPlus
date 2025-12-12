namespace AotenjoAPIPlus.Classes;

public abstract class StringHolder
{
    public abstract string GetString();
    public sealed override string ToString() => GetString();
    
    public static implicit operator StringHolder(string value) => new StringHolderFromString(value);
    public static implicit operator StringHolder(Func<string> func) => new StringHolderFromFunc(func);
    public static implicit operator string(StringHolder holder) => holder.GetString();
    public static implicit operator Func<string>(StringHolder holder) => holder.GetString;
}
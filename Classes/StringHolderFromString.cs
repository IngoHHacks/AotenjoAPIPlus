namespace AotenjoAPIPlus.Classes;

public class StringHolderFromString(string value) : StringHolder
{
    public override string GetString()
    {
        return value;
    }
}
namespace AotenjoAPIPlus.Classes;

public class StringHolderGroup
{
    public List<StringHolder> Holders { get; }
    
    public StringHolderGroup(params StringHolder[] holders)
    {
        Holders = holders.ToList();
    }
    
    public override string ToString()
    {
        return string.Join(",", Holders.Select(h => h.ToString()));
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9);
    }
    
    public static implicit operator StringHolderGroup((StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder) tuple)
    {
        return new StringHolderGroup(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10);
    }
    
    public static implicit operator StringHolderGroup(List<StringHolder> holders)
    {
        return new StringHolderGroup(holders.ToArray());
    }
    
    public static implicit operator StringHolderGroup(StringHolder[] holders)
    {
        return new StringHolderGroup(holders);
    }
    
    public static implicit operator StringHolderGroup(StringHolder holder)
    {
        return new StringHolderGroup(holder);
    }
    
    public static implicit operator string(StringHolderGroup group)
    {
        return group.ToString();
    }
    
    public static implicit operator StringHolder[](StringHolderGroup group)
    {
        return group.Holders.ToArray();
    }
    
    public static implicit operator List<StringHolder>(StringHolderGroup group)
    {
        return group.Holders;
    }
    
    public static implicit operator (StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4], group.Holders[5]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4], group.Holders[5], group.Holders[6]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4], group.Holders[5], group.Holders[6], group.Holders[7]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4], group.Holders[5], group.Holders[6], group.Holders[7], group.Holders[8]);
    }
    
    public static implicit operator (StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder, StringHolder)(StringHolderGroup group)
    {
        return (group.Holders[0], group.Holders[1], group.Holders[2], group.Holders[3], group.Holders[4], group.Holders[5], group.Holders[6], group.Holders[7], group.Holders[8], group.Holders[9]);
    }
    
    public StringHolder this[int index]
    {
        get => Holders[index];
        set => Holders[index] = value;
    }

    public void Deconstruct(out List<StringHolder> holders)
    {
        holders = Holders;
    }
    
    public void Deconstruct(out StringHolder[] holders)
    {
        holders = Holders.ToArray();
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5, out StringHolder holder6)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
        holder6 = Holders[5];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5, out StringHolder holder6, out StringHolder holder7)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
        holder6 = Holders[5];
        holder7 = Holders[6];
    }

    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5, out StringHolder holder6, out StringHolder holder7,
        out StringHolder holder8)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
        holder6 = Holders[5];
        holder7 = Holders[6];
        holder8 = Holders[7];
    }

    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5, out StringHolder holder6, out StringHolder holder7,
        out StringHolder holder8, out StringHolder holder9)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
        holder6 = Holders[5];
        holder7 = Holders[6];
        holder8 = Holders[7];
        holder9 = Holders[8];
    }
    
    public void Deconstruct(out StringHolder holder1, out StringHolder holder2, out StringHolder holder3,
        out StringHolder holder4, out StringHolder holder5, out StringHolder holder6, out StringHolder holder7,
        out StringHolder holder8, out StringHolder holder9, out StringHolder holder10)
    {
        holder1 = Holders[0];
        holder2 = Holders[1];
        holder3 = Holders[2];
        holder4 = Holders[3];
        holder5 = Holders[4];
        holder6 = Holders[5];
        holder7 = Holders[6];
        holder8 = Holders[7];
        holder9 = Holders[8];
        holder10 = Holders[9];
    }
}
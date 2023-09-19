﻿namespace Application.Common.Dynamic;

public sealed class Sort
{
    public string Field { get; set; }
    public string Direction { get; set; }

    public Sort()
    {
        Field = string.Empty;
        Direction = string.Empty;
    }

    public Sort(string field, string dir)
    {
        Field = field;
        Direction = dir;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler<T>
{
    protected T runner;
    public Handler(T player)
    {
        runner = player;
    }
}

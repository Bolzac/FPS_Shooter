using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View<T>
{
    protected T runner;
    public View(T player)
    {
        runner = player;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController<T>
{
    protected T Runner;

    public BaseController(T source)
    {
        Runner = source;
    }
}

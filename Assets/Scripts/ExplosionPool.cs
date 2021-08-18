using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : ObjectPool
{
    public static ExplosionPool Instance;

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Characters : Move
{
    public abstract void TakeDamage(float damageAmount);
    public virtual void TakeEffect( float effectTime, GameObject gameObject)
    {
        Effect.UseEffect(gameObject);
    }
    




}


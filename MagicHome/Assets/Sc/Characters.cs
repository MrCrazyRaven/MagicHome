using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Characters : Move
{
    public abstract void TakeDamage(float damageAmount);
    public virtual void TakeEffect( float effectTime, GameObject gameObject, Effect.Effects effects)
    {
        StartCoroutine(EffectTime( effectTime,effects));

        
    }


    private IEnumerator EffectTime(float effectTime, Effect.Effects effects)
    {
        Effect.UseEffect(gameObject, effects);
        while (effectTime > 0)
        {
            effectTime =- 1;
            yield return new WaitForSeconds(1);
        }
        Effect.UnUseEffect(gameObject, effects);

    }


}


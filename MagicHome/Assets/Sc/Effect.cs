using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Effect 
{
    public enum Effects
    {
        Fire,Ase
    }
    
    public static void UseEffect(GameObject gameObject, Effects effects)
    {
        switch (effects)
        {
            case Effects.Fire:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case Effects.Ase:
                gameObject.GetComponent<Enemy>().speed = gameObject.GetComponent<Enemy>().speed + 7;
                break;

            default:
                break;
        }
        
    }
    public static void UnUseEffect(GameObject gameObject, Effects effects)
    {
        switch (effects)
        {
            case Effects.Fire:
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                break;
            case Effects.Ase:
                gameObject.GetComponent<Enemy>().speed = gameObject.GetComponent<Enemy>().speed -7;
                break;

            default:
                break;
        }

    }

}

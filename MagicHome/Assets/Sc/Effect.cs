using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Effect 
{
    enum Effects
    {

    }
    
    public static void UseEffect(GameObject gameObject)
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{

    public void Hunt(float speed, GameObject target)
    {
        
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
        }
    }
    public void Hunt(float speed, Collider2D target)
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
        }
    }
    public void GoBack(float speed, GameObject target)
    {
        if (Vector2.Distance(transform.position, target.GetComponent<Transform>().position) > 1) { 
            if (target)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, speed * Time.deltaTime);
            }
        }
    }
}

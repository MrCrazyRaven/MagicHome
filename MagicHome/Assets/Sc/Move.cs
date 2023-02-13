using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{

    public void Hunt(float speed, GameObject target)
    {
        
        if (target)
        {
            if (target.transform.position.x < transform.position.x && transform.localScale.x > 0)
            {
                transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
            }
            else if(target.transform.position.x > transform.position.x && transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
            }

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

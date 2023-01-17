using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemys;
    [SerializeField] private Enemy _closest;

    
   
    


    // Update is called once per frame
    void Update()
    {
        if (FindClosestEnemy())
        {
            //if (Vector2.Distance(transform.position, FindClosestEnemy().GetComponent<Transform>().position) < 14)
            //{
                Vector3 difference = FindClosestEnemy().transform.position - transform.position;
                float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            //}

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            
            _enemys.Add(enemyComponent);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            _enemys.Remove(enemyComponent);
        }

    }
    public Enemy FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Enemy go in _enemys)
        {
            if (go != null)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (distance > curDistance)
                {
                    _closest = go;
                    distance = curDistance;
                }

            }
                
        }
        return _closest;
    }
    
}

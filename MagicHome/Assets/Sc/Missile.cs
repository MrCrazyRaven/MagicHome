using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Move
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Vector2 _impuls;
    [SerializeField] private List<GameObject> _enemys;
    [SerializeField] private GameObject _closest;
    public float distance;
    public LayerMask whatIsSolid;
    public int damage = 3;
    public string text;
    
    



    // Start is called before the first frame update
    void Start()
    {


        _enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        StartCoroutine(LvTame());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (FindClosestEnemy())
        {
            if (Vector2.Distance(transform.position, FindClosestEnemy().GetComponent<Transform>().position) < 14)
            {

                Hunt(4, FindClosestEnemy());
            }
            
        }
    }
    public GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in _enemys)
        {
            if (go == null)
            {
                _enemys.Remove(go);
            }
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (distance > curDistance)
            {
                _closest = go;
                distance = curDistance;
            }
        }
        return _closest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            Destroy(gameObject);
           
        }
       
    }
    private IEnumerator LvTame()
    {

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    
    
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public int damage = 5;
    [SerializeField] private float speed;
    private void Start()
    {
        
        StartCoroutine(LvTame());
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.TakeEffect(4, collision.gameObject);
                enemyComponent.TakeDamage(damage);
                Destroy(gameObject);
                

            }
            
        }
    private IEnumerator LvTame()
    {

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

}

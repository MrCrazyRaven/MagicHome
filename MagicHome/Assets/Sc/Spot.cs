using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField] private bool _enemy—heck;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spaunspawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Enemy—heck());
        
    }

   
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Enemy>())
        {
            
            _enemy—heck = true;

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            _enemy—heck = false;

        }

    }
    private IEnumerator Enemy—heck()
    {
        while (true)
        {
            
            if (_enemy—heck == false)
            {
                    Instantiate(_enemy, _spaunspawnPoint.position, transform.rotation);
                    Instantiate(_enemy, _spaunspawnPoint.position, transform.rotation);
                    Instantiate(_enemy, _spaunspawnPoint.position, transform.rotation);
            }
        yield return new WaitForSeconds(10);
        }
       
    }
}

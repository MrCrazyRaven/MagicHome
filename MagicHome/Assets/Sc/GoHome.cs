using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    private int scene;
    [SerializeField] private GameObject _goHome;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _goHome.SetActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _goHome.SetActive(false);

        }
    }
    
   
}

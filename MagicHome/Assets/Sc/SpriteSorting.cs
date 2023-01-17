using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorting : MonoBehaviour
{
    [SerializeField] private float _offset = 0;
    private int _sortingOrderBase = 0;
    private Renderer _renderer;
    private void Awake()
    {
        
        _renderer = GetComponent<Renderer>();
    }
    

    // Update is called once per frame
    void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + _offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Characters
{
    private GameObject[] _spots;
    private GameObject _player;
    [SerializeField]private GameObject _spot;
    public float speed;
    private float _attackDistance = 2f, _detectionDistance = 5f;
    [SerializeField] private float _health , _maxHealth = 10f;
    public static  UnityEvent onEnemyDied = new UnityEvent();
    

    void Start()
    {
        _spots = GameObject.FindGameObjectsWithTag("Spot");
        _health = _maxHealth;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position,_player.GetComponent<Transform>().position)  > _attackDistance )
        {
            if (Vector2.Distance(transform.position, _player.GetComponent<Transform>().position) < _detectionDistance)
            {
              Hunt(speed, _player);
            }
            else
            {
                GoBack(speed, FindClosestEnemy());
            }
        }
    }
    
    public override void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            onEnemyDied?.Invoke();
            Destroy(gameObject);
        }
    }
    public override void TakeEffect(float effectTime,GameObject gameObject ) 
    { 
        base.TakeEffect(effectTime, gameObject);
    }
    public GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in _spots)
        {
            
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (distance > curDistance)
            {
                _spot = go;
                distance = curDistance;
            }
        }
        return _spot;
    }

    
}


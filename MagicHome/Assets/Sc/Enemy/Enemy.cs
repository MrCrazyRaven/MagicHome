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
    private float _attackDistance = 4f, _detectionDistance = 15f;
    [SerializeField] private float _health , _maxHealth = 10f;
    public static  UnityEvent onEnemyDied = new UnityEvent();
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;
    private Player playerHealth;




    void Start()
    {
        _spots = GameObject.FindGameObjectsWithTag("Spot");
        _health = _maxHealth;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        //if (Vector2.Distance(transform.position,_player.GetComponent<Transform>().position)  > _attackDistance && 
        //    Vector2.Distance(transform.position, _player.GetComponent<Transform>().position) < _detectionDistance)
        //{
        //      Hunt(speed, _player);
        //}
        
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                    cooldownTimer = 0;
                    DamagePlayer();
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
    
   
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * 2f, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)            
            playerHealth = hit.transform.GetComponent<Player>();


        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y * 2f, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
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


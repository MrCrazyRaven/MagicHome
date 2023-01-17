using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Characters
{
    
    public float speed;
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _anim;
    [SerializeField] private float _health, _maxHealth = 10f;



    void Start()
    {
        _health = _maxHealth;
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerRb.velocity = new Vector2(_joystick.Horizontal * speed, _joystick.Vertical * speed);

        
    }

    public override void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
}

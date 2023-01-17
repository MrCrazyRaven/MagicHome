using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightMovement : MonoBehaviour
{
    public float speed;
    [SerializeField] private Rigidbody2D _aimRb;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D[] _enemys;
    public GameObject atakButtn;
    private float _damage = 10;

    void Start()
    {
        _aimRb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _aimRb.velocity = new Vector2(_joystick.Horizontal * speed, _joystick.Vertical * speed);
    }

    public void Explosion()
    {
        

        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, 2f);
        foreach (Collider2D collider in collider2Ds)
        {
            if (collider.GetComponent<Enemy>())
            {
                collider.GetComponent<Enemy>().TakeDamage(_damage);


                atakButtn.SetActive(true);
            }
        }
    }
}

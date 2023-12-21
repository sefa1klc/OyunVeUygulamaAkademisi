using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Force")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private bool grounded;
    public static bool isStarted;
    private bool isjump;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();//caching rigidbody2d
        _animator = GetComponent<Animator>();
        grounded = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isStarted && grounded)
            {
                _animator.SetTrigger("jump");
                grounded = false;
                isjump = true;
            }
            else
            {
                _animator.SetBool("GameStarted",true);
                isStarted = true;
            }
        }
        
        _animator.SetBool("grounded",grounded);
    }

    private void FixedUpdate()
    {
        if (isStarted)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }

        if (isjump)
        {
            _rigidbody2D.AddForce(new Vector2(0f,jumpForce));
            isjump = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
    
    
}

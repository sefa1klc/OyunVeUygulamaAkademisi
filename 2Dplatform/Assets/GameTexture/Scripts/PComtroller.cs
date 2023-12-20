using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PComtroller : MonoBehaviour
{
    public float jumForce = 2f;
    public float speed = 2f;
    private float moveDirection;
    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public Text scoreUI;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);
        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumForce);
            jump = false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed",speed);
            }else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed",speed);
            }
        }else if (grounded == true)
        {
            moveDirection = 0f;
            _animator.SetFloat("speed",0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.Space))
        {
            jump = true;
            grounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded",false);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { 
            _animator.SetBool("grounded",true);
            grounded = true;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("elmas"))
        {
            Destroy(other.gameObject);
            score.Scorecounter ++;
            scoreUI.text = "SCORE : " + score.Scorecounter.ToString();
        }
    }
}

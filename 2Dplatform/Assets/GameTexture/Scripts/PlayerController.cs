using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    private Animator _animator;
    private Rigidbody2D r2d;
    private Vector3 charPos;//to keep position
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Camera _camera;//serializefieldlar private olmasına rağmen editorde görünmesini istediğiiz değişkenleri içerir

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();//caching spriterenderer
        r2d = GetComponent<Rigidbody2D>();// caching
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }

    private void FixedUpdate()//fizik temelli kodlar buraya - 50fps
    {
        //r2d.velocity = new Vector2(speed, 0);
    }

    private void Update()// per frame
    {
        /*if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            speed = 2f;
        }
        else
        {
            speed = 0f;
        }*/
        
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime),charPos.y);
        transform.position = charPos;
        if (Input.GetAxis("Horizontal") == 0f)
        {
            _animator.SetFloat("speed", 0f);
        }
        else
        {
            _animator.SetFloat("speed",speed);
        }

        if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
        else if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        

    }

    private void LateUpdate()
    {
        //charpos.z -1f ifadesi kamera ve karakterin çakışmasını önlemek için yazıldı
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MoveSpeed = 6f;
    private Animator _animator;
    private bool faceRight = true;
    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame updalte
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!faceRight)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h < 0)
        {
            faceRight = false;
        }
        else if (h > 0)
        {
            faceRight = true;
        }

        rb.velocity = new Vector2(MoveSpeed * h, rb.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(h) * 5f);
    }
}
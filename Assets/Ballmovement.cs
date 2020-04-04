﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    public int speed = 30;

    public Rigidbody2D ball;
    
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        ball.velocity = new Vector2(-1,-1)*speed;
        anim.SetBool("isMove", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(ball.velocity.x>0)
        {
            ball.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            ball.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name=="WallVertical Right" || other.collider.name=="WallVertical Left")
        {
            StartCoroutine(jeda());
        }
    }

    IEnumerator jeda()
    {
        ball.velocity = Vector2.zero;
        anim.SetBool("isMove", false);
        ball.GetComponent<Transform>().position = Vector2.zero;
        yield return new WaitForSeconds(1);
        ball.velocity = new Vector2(-1,-1) * speed;
        anim.SetBool("isMove", true);
    }
}

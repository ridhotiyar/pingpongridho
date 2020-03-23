using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    public int speed = 30;

    public Rigidbody2D ball;
    
    // Start is called before the first frame update
    void Start()
    {
        ball.velocity = new Vector2(-1,-1)*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name=="Kanan" || other.collider.name=="Kiri")
        {
            GetComponent<Transform>().position = new Vector2(0,0);
        }
    }
}

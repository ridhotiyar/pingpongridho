using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballmovement : MonoBehaviour
{
    public int speed = 30;

    public Rigidbody2D ball;
    public GameObject MasterScript;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range (0,2) * 2 - 1;
        int y = Random.Range (0,2) * 2 - 1;
        ball.velocity = new Vector2(x, y)*speed;
        ball.GetComponent<Transform>().position = Vector2.zero;
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
            MasterScript.GetComponent<ScoringScript>().UpdateScore(other.collider.name);
            StartCoroutine(jeda());
        }
    }

    IEnumerator jeda()
    {
        ball.velocity = Vector2.zero;
        anim.SetBool("isMove", false);
        ball.GetComponent<Transform>().position = Vector2.zero;

        yield return new WaitForSeconds(1);
        
        int x = Random.Range (0,2) * 2 - 1;
        int y = Random.Range (0,2) * 2 - 1;
        ball.velocity = new Vector2(x, y) * speed;
        anim.SetBool("isMove", true);
    }
}

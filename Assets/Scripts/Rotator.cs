using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;

    private float randX;
    private float randY;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        randX = Random.Range(-1f, 1f);
        randY = Random.Range(-1f, 1f);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
        //rb2d.AddForce(new Vector2(transform.forward.x, transform.forward.y));  
        //rb2d.velocity = 1;
        rb2d.AddForce(new Vector2(randX, randY) * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        randX *= -1;
        randY *= -1;
    }




}

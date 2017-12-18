using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Vector2 vel;

    //function that chooses random direction for the ball
    // ball will then start to move

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    //initialize rb2d variable
    //call GoBall()

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2); //2 second wait before ball starts moving
    }

    //ball is adjusted when hitting the paddle

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("paddle1"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }

        if (collision.collider.CompareTag("paddle2"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }



    void Update()
    {
        //when ball goes behind leftplayer
        if (transform.position.x < -10f)
        {
            //give right player a point
            level3score.instance.GiverightPlayerPoint();

            this.transform.position = new Vector3(0f, 0f, 0f);
            GoBall();
        }

        //when ball goes behind rightplayer
        if (transform.position.x > 10f)
        {
            //give left player a point
            level3score.instance.GiveleftPlayerPoint();

            this.transform.position = new Vector3(0f, 0f, 0f);
            GoBall();
        }

    }
}






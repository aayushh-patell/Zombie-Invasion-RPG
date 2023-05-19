using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Lets Us Use Our Rigidbody To Change The Movement And Rotation Of Our Object
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates And Returns Direction In Custom Method
        Vector3 direction = Direction();

        // Atan2 Calculates The Angle Between 0 And A Vector2 Point And Returns Data As (y,x)

        // Calculates The Angle Between Our Enemy And Player Objects And Converts Our Output Value From Radians To Degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Sets Our Rigidbody's Rotation
        rb.rotation = angle;

        // Sets Our Movement Variable To The Value Of Our Direction And Makes Sure The Value Is Between -1 And 1
        direction.Normalize();
        movement = direction;
    }

    private Vector3 Direction()
    {
        // Returns Direction
        return player.position - transform.position;
    }

    private void FixedUpdate()
    {
        // Calls Method
        moveCharacter(movement);
    }

    // Takes Our Current Position And Moves It In The Direction Of Our Player Object, It Also Controls The Movement Speed Of Our Enemy
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If An Enemy Comes In Contact With The Player Then Lives Decrease And The Enemy Dies
        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }

        // If An Enemy Comes In Contact With A Bullet Then It Destroys
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}

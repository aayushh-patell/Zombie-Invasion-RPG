using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Rigidbody2D rb;

    public int lives = 3;

    public Text lifeCount;

    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Collecting X And Y Input And Storing It In The Movement Variable
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Collects Current Position Of Our Mouse In Pixel Coordinates And Converts To World Units
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Sets lifeCount vaue to lives' value
        lifeCount.text = "Lives: " + lives.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When there is a collision with an enemy, lives will decrease
        lives--;

        // Sets lifeCount vaue to lives' value
        lifeCount.text = "Lives: " + lives.ToString();

        // If lives reach 0, the player will die And the colonel will send another message
        if (lives == 0)
        {
            Destroy(gameObject);
            Debug.Log("Soldier You Have Failed Us");
        }
    }

    void FixedUpdate()
    {
        // Controls Movemena
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Determines The Direction We're Pointing In
        Vector2 lookDir = mousePos - rb.position;

        // Atan2 Calculates The Angle Between 0 And A Vector2 Point And Returns Data As (y,x)

        // Figures Out The Z Value Of The Direction We Want To Point In And Converts Our Output Value From Radians To Degrees And Offsets The Angle By 90 Degrees
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = angle;
    }
}

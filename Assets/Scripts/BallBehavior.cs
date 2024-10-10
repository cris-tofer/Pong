using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float angle;
    float speed = 5.0f;
    float Player1Score;
    float Player2Score;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        switch (Mathf.Round(Random.Range(1, 5)))
        {
            case 1f:
                angle = 27;//up and to the left
                break;
            case 2f:
                angle = 29;//down and to the left
                break;
            case 3f:
                angle = 37;//down and to the right 
                break;
            case 4f:
                angle = 32;//up and to the right
                break;
            default:
                break;
        }
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // resets the ball to its starting point and changes its angle
    void resetBall()
    {
        switch (Mathf.Round(Random.Range(1, 5)))
        {
            case 1f:
                angle = 27;//up and to the left
                break;
            case 2f:
                angle = 29;//down and to the left
                break;
            case 3f:
                angle = 37;//down and to the right 
                break;
            case 4f:
                angle = 32;//up and to the right
                break;
            default:
                break;
        }
        transform.position = new Vector3(0, 0);
        speed = 5.0f;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Debug.Log("Player 1 Score: " + Player1Score);
        Debug.Log("Player 2 Score: " + Player2Score);
    }
    
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;
        //add a point
        if (transform.position.x < -8.45f)
        {
            Player2Score++;
            resetBall();
        }
        if (transform.position.x > 8.45f)
        {
            Player1Score++;
            resetBall();
        }

        //Bounce off walls
        if (transform.position.y > 4.5f)
        {
            direction.y = -direction.y;

            speed += 0.1f;
            transform.position = new Vector3(transform.position.x, 4.5f);
        }
        if (transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
            speed += 0.1f;
            transform.position = new Vector3(transform.position.x, -4.5f);
        }

        //Bounce off left paddle
        if (transform.position.x - 0.5f > -7.2f && transform.position.x - 0.5f < -7f){
            if (transform.position.y - 0.5f <= Player1.PrintPosition().y + 1.25f && transform.position.y + 0.5f >= Player1.PrintPosition().y - 1.25f)
            {
                direction.x = -direction.x;
                speed += 0.1f;
                transform.position = new Vector3(-6.5f, transform.position.y);
            }
        }
        //Bounce off right paddle
        if (transform.position.x + 0.5f < 7.2f && transform.position.x + 0.5f > 7f)
        {
            if (transform.position.y - 0.5f <= Player2.PrintPosition().y + 1.25f && transform.position.y + 0.5f >= Player2.PrintPosition().y - 1.25f)
            {
                direction.x = -direction.x;
                speed += 0.1f;
                transform.position = new Vector3(6.5f, transform.position.y);
            }
        }

    }
}
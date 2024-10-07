using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    float angle;
    float speed = 5.0f;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(1, 360) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;
        //add a point
        if (transform.position.x < -7.45f)
        {
            direction.x = -direction.x;
            speed += 0.1f;
            //Player2Point++;
            //speed = 5.0f;
            //angle = Random.Range(1, 360) * Mathf.Deg2Rad;
            //direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }
        if (transform.position.x > 8.5f)
        {
            direction.x = -direction.x;
            speed += 0.1f;
            //Player1Point++;
            //speed = 5.0f;
            //angle = Random.Range(1, 360) * Mathf.Deg2Rad;
            //direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        }

        //Bounce off walls
        if (transform.position.y > 8.5f)
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

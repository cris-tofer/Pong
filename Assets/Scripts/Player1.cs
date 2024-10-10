using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    float angle;
    float speed = 5.0f;
    static Vector2 position;
    Vector2 direction;
    float y;
    float x;

    public static Vector2 PrintPosition()
    {
        return (position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        x = transform.position.x;
        y = transform.position.y;
        position = new Vector2(x, y);
        // Paddle movement
        if (Input.GetKey(KeyCode.W) && transform.position.y < 3.75f)
        {
            angle = 90 * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector3 change = direction * speed * dt;
            transform.position += change;
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -3.75f)
        {
            angle = 270 * Mathf.Deg2Rad;
            direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector3 change = direction * speed * dt;
            transform.position += change;
        }

        //safty net
        if (transform.position.y > 3.75f)
        {
            transform.position = new Vector3(-7.1f, 3.75f);
        }
        if (transform.position.y < -3.75f)
        {
            transform.position = new Vector3(-7.1f, -3.75f);
        }
    }
}
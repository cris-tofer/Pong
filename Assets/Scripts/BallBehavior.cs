using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallBehavior : MonoBehaviour
{
    float angle;
    float speed = 5.0f;
    Vector2 direction = Vector2.right;
    Vector2 position = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        float angle = Random.Range(1, 360) * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 change = direction * speed * dt;
        transform.position += change;
        if (transform.position.x < -7.5f)
        {
            direction.x = -direction.x;
            speed += 0.1f;
        }
        if (transform.position.x > 7.5f)
        {
            direction.x = -direction.x;
            speed += 0.1f;
        }
        if (transform.position.y > 4.5f)
        {
            direction.y = -direction.y;
            speed += 0.1f;
        }
        if (transform.position.y < -4.5f)
        {
            direction.y = -direction.y;
            speed += 0.1f;
        }
    }
}

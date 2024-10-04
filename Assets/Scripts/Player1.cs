using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    float speed = 2.5f;
    Vector2 position = new Vector2 (-6.5f, 0f);
    Vector2 direction = new Vector2(1, 1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        //getting the imputs and moving the block
        if (Input.GetKeyDown(KeyCode.W) && position.y < 4.5f)
        {
            direction.y = 1f;
            Vector3 change = direction * (speed + dt);
            transform.position += change;
        }
        if (Input.GetKeyDown(KeyCode.S) && position.y > -4.5f)
        {
            direction.y = -1f;
            Vector3 change = direction * speed * dt;
            transform.position += change;
        }
        
        //safty nets
        if (position.y > 4.5f)
        {
            position.y = 4.5f;
        }
        if (position.y < -4.5f)
        {
            position.y = -4.5f;
        }
    }
}

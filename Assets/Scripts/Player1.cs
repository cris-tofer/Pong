using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    float speed = 2.5f;
    Vector2 position = (-4, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        if (IsKeyDown(Key.w) == true)
        {
            Debug.Log("w");
        }
    }
}

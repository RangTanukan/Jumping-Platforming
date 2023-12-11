using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}


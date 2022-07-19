using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;    
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "RocketLeft") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "RocketRight") {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 rocketPos, float rocketHeight) {
        return (ballPos.y - rocketPos.y) / rocketHeight;
    }   
}

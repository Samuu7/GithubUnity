using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 0;

    public float timeBetweenReverse = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D obstacleRigidBody = GetComponent<Rigidbody2D>();
        obstacleRigidBody.velocity = Vector2.up * speed;

        InvokeRepeating("Reverse", 0, timeBetweenReverse);
    }


    void Reverse()
    {
        Rigidbody2D obstacleRigiBody = GetComponent<Rigidbody2D>();
        obstacleRigiBody.velocity *= -1;
    }
}

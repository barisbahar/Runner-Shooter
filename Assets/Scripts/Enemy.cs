using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform playerPos;
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (GameManager.instance.score > 20 && GameManager.instance.score < 50)
        {
            speed = 8;
        }
        if (GameManager.instance.score > 49 && GameManager.instance.score < 75)
        {
            speed = 15;
        }
        if (GameManager.instance.score > 74)
        {
            speed = 18.5f;
        }
        if (Vector2.Distance(transform.position, playerPos.position) > 0.3f)
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

}

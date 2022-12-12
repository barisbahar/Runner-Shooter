using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    Rigidbody2D physics;
    Animator animator;
    public float speed;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    private Bullet counter;
    public GameObject getbulletscript;
    public bool startcheck = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        physics = GetComponent<Rigidbody2D>();
        counter = getbulletscript.GetComponent<Bullet>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -25, 10.5f), Mathf.Clamp(transform.position.y, -3.7f, 15));
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        //     animator.SetBool("Walk", true);
        //     animator.SetBool("Idle", false);

        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        //     animator.SetBool("Walk", true);
        //     animator.SetBool("Idle", false);

        // }
        // else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        // {
        //     animator.SetBool("Walk", true);
        //     animator.SetBool("Idle", false);
        // }
        // else
        // {
        //     animator.SetBool("Idle", true);
        //     animator.SetBool("Walk", false);
        // }
    }
    void FixedUpdate()
    {
        physics.MovePosition(physics.position + movement * speed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - physics.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        physics.rotation = angle;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Start")
        {
            startcheck = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Start")
        {
            other.isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameOver.instance.Setup(GameManager.instance.score);
        }
    }
}

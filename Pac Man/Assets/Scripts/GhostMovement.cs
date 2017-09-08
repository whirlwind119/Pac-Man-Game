using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 10;
    public string orientation;

    private Rigidbody2D rb;
    float time;

    // Use this for initialization
    void Start()
    {
        time = Time.time;
        chooseDirection();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (orientation == "up")
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 90f);
            rb.velocity = Vector2.up * speed * Time.deltaTime;
        }
        if (orientation == "left")
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 180f);
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        if (orientation == "down")
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 270f);
            rb.velocity = Vector2.down * speed * Time.deltaTime;
        }
        if (orientation == "right")
        {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0f);
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
        if(Time.time - time > 2)
        {
            chooseDirection();
            time = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            Destroy(c.gameObject);
        }
    }

    private void chooseDirection()
    {
        int num = Random.Range(0, 4);
        if (num == 0)
        {
            orientation = "right";
        }
        else if (num == 1)
        {
            orientation = "left";
        }
        else if (num == 2)
        {
            orientation = "up";
        }
        else if (num == 3)
        {
            orientation = "down";
        }
    }



}

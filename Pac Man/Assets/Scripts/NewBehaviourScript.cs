using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float speed = 100;
    public string orientation;
    public static int score = 0;


    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        orientation = "right";
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            orientation = "up";
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            orientation = "left";
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            orientation = "down";
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            orientation = "right";
        }
        
        if (orientation == "up") {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 90f);
            rb.velocity = Vector2.up * speed * Time.deltaTime;
        }
        if (orientation == "left") {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 180f);
            rb.velocity = Vector2.left * speed * Time.deltaTime;
        }
        if (orientation == "down") {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 270f);
            rb.velocity = Vector2.down * speed * Time.deltaTime;
        }
        if (orientation == "right") {
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0f);
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "coin") {
            Destroy(c.gameObject);
            score++;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public float speed = 100;
    public string orientation;
    public static int score = 0;
    public static int num_lives = 3;
    public static int highest_score = 0;
	public GameObject life2;
	public GameObject life1;


    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        orientation = "right";
        rb = GetComponent<Rigidbody2D>();

		life2 = (GameObject)Instantiate (life2, new Vector2 (-2, 5), Quaternion.identity);
		life1 = (GameObject)Instantiate (life1, new Vector2 (-2, 4), Quaternion.identity);

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

    private void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.tag == "ghost") {
            num_lives--;
			if (num_lives == 2) {
				Destroy (life2);
			} else if (num_lives == 1) {
				Destroy (life1);
			}
            orientation = "right";
            gameObject.transform.position = new Vector2((float)13.5, 9);
        }
    }



}

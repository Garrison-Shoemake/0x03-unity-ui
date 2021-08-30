using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 500f;
	private int score = 0;
	public int health = 5;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	
	void Update()
	{
		if (health <= 0)
		{
			score = 0;
			health = 5;
			SceneManager.LoadScene("maze");
		}
	}

	void FixedUpdate () 
	{
		
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			score += 1;
			SetScoreText();
			Destroy(other.gameObject);
		}
		if (other.tag == "Trap")
		{
			health -= 1;
			Debug.Log("Health: " + health);
		}
		if (other.tag == "Goal")
		{
			Debug.Log("You win!");
		}
	}

	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}
}

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
	public Text healthText;
	public Text winLoseText;
	public Image winLoseBG;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	
	void Update()
	{
		if (health == 0)
		{
			winLoseBG.gameObject.SetActive(true);
			winLoseText.gameObject.SetActive(true);
			winLoseText.color = Color.white;
			winLoseText.text = "Game Over!";
			winLoseBG.color = Color.red;
			StartCoroutine(LoadScene(3));
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
			SetHealthText();
		}
		if (other.tag == "Goal")
		{
			winLoseBG.gameObject.SetActive(true);
			winLoseText.gameObject.SetActive(true);
			winLoseText.color = Color.black;
			winLoseText.text = "You Win!";
			winLoseBG.color = Color.green;
			StartCoroutine(LoadScene(3));
		}
	}
	IEnumerator LoadScene(float seconds)
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("maze");
	}
	void SetScoreText()
	{
		scoreText.text = "Score: " + score;
	}
	void SetHealthText()
	{
		healthText.text = "Health: " + health;
	}
}

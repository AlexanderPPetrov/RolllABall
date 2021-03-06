﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	private Rigidbody rb;

	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other){
		//Destroy(other.gameObject)
		if(other.gameObject.CompareTag("Collectable")){
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();

		}
	}
	void SetCountText(){
		countText.text = "Count: " + count.ToString();
	}
}
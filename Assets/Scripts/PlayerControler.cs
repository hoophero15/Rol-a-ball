using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerControler : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private float oldJump;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movment = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movment * speed);

		if (Input.GetKeyDown ("space") && rb.transform.position.y == oldJump){
			Vector3 jump = new Vector3 (0.0f, 200.0f, 0.0f);
			rb.AddForce (jump);
		}

		oldJump = rb.transform.position.y;
	}

	void OnTriggerEnter(Collider other) {
		// Destroy(other.gameObject);
		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			if(count >= 17){
				winText.text = "You Win!";
			}
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString();
	}
}

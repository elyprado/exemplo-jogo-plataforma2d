using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNPC : MonoBehaviour {
	private Rigidbody2D rig;
	private float mov = 1F;

	void Start () {
		rig = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		if (mov > 0) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			GetComponent<SpriteRenderer> ().flipX = false;
		}
		rig.velocity = new Vector2 (mov, rig.velocity.y);
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			if (col.gameObject.transform.position.y >
			    gameObject.transform.position.y + 1) {
				Destroy (gameObject); //NPC morre
			} else {
				Destroy (col.gameObject); //NPC mata
			}	
		} else if (col.gameObject.tag == "Fire") {
			Destroy (gameObject); //NPC morre
		} else {
			mov = mov * -1; //NPC muda de direção
		}
	}
}

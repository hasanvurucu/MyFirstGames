using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoMovementScript : MonoBehaviour {

	private float speed;

	private int wayChance;

	void Start () {

		speed = Random.Range (6f, 8f);

		wayChance = Random.Range (1, 3);

		//if chance is 2, speed = speed, if not: opposite way
		if (wayChance == 1)
			speed = -speed;


	}


	void Update () {

		Vector2 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "hitableLimit") 
		{
			speed = -speed;
		}
		if (collision.tag == "objDestroy") 
		{
			Object.Destroy (this.gameObject);
		}

	}
}

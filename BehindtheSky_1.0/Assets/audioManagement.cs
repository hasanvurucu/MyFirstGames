using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagement : MonoBehaviour {

	public cameraMovement camMov;
	public GameObject cameraObj;


	public GameObject soundtrack1;
	public GameObject soundtrack3;
	public GameObject soundtrack2;

	// Use this for initialization
	void Start () 
	{
		soundtrack3.SetActive (false);
		soundtrack2.SetActive (false);
	}

	void Awake()
	{
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 st1pos = soundtrack1.transform.position;
		Vector3 st3pos = soundtrack3.transform.position;
		Vector2 st2pos = soundtrack2.transform.position;

		if (camMov.score <= 950)//ST1
		{
			st1pos = cameraObj.transform.position;
		}
		if (cameraObj.transform.position.y - st1pos.y >= 90)
		{
			soundtrack1.SetActive (false);
		}//ST1

		//ST3
		if (st3pos.y - cameraObj.transform.position.y <= 200)
		{
			soundtrack3.SetActive (true);
		}
		if (camMov.score >= 1200 && camMov.score <= 10000)
		{
			st3pos = cameraObj.transform.position;
		}
		if (cameraObj.transform.position.y - st3pos.y >= 150)
		{
			soundtrack3.SetActive (false);
		}//ST3

		//ST2
		if (st2pos.y - cameraObj.transform.position.y <= 300)
		{
			soundtrack2.SetActive (true);
		}
		if (camMov.score >= 10500)
		{
			st2pos = cameraObj.transform.position;
		}



		soundtrack1.transform.position = st1pos;
		soundtrack3.transform.position = st3pos;
		soundtrack2.transform.position = st2pos;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapeButtonUsage : MonoBehaviour {

	void Update () {

		if (Input.GetKeyUp (KeyCode.Escape))
		{
			SceneManager.LoadScene ("menu");
		}
	}
}

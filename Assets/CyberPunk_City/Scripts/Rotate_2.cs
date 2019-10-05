using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //I changed this to a 5.. its brand new
        transform.Rotate(5.0f, 0, 0);
    }
}

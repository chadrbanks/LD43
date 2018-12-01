using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void SetColor( )
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

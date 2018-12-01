using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {


    public Tile tile;

	// Use this for initialization
	void Start ()
    {
        for (var x = -50; x < 50; x++ )
        {
            for (var y = -50; y < 50; y++)
            {
                Vector3 nv = new Vector3(x, 0, y);
                Tile b = Instantiate(tile, nv, Quaternion.identity) as Tile;
                b.SetColor();
                //b.Waste();
                //b.LinkM(this);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //int t, v = 10;
    //private bool setsy = false;
    //private MainEngine mainEngine;
    private GameEngine gameEngine;
    public Material[] mats;

    void Awake()
    {
        //
    }

    void Start()
    {
        //
    }

    public void Waste()
    {
        //transform.localScale += new Vector3(3F, 0, 2F);
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

	void Update()
	{
		//transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

		if (gameObject.transform.position.y < -12)
		{
			Destroy(gameObject);
		}
	}
}

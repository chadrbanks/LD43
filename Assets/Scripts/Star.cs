using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
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
        //
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

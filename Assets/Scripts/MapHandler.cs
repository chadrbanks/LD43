using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    public GameObject red, blue, green;

	void Start ()
    {
        blue.SetActive(true);
        red.SetActive(false);
        green.SetActive(false);
	}

    public void setHeader( int id )
    {
        if( id == 1 )
        {
            blue.SetActive(false);
            red.SetActive(false);
            green.SetActive(true);
        }
        else if( id == 2 )
        {
            blue.SetActive(true);
            red.SetActive(false);
            green.SetActive(false);
        }
        else if (id == 3)
        {
            blue.SetActive(false);
            red.SetActive(true);
            green.SetActive(false);
        }
        else
        {
            blue.SetActive(false);
            red.SetActive(false);
            green.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipButton : MonoBehaviour
{
    public int id;
    public TextMesh ss;
    public AudioSource hover;
    bool play = true;
    SpriteRenderer sr;

	void Start ()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if( play )
        {
            hover.Play();
            play = false;
        }

        sr.gameObject.transform.position = new Vector3(sr.gameObject.transform.position.x, sr.gameObject.transform.position.y, 9.0f);

        if (id == 1)
        {
            ss.text = "B15 Defender\nSpeed: 3\nHull: 20\nStorage: 15\nWeapons: 10\nCredits: 300";
        }
        else if (id == 2)
        {
            ss.text = "Speed Rogue\nSpeed: 5\nHull: 10\nStorage: 10\nWeapons: 5\nCredits: 500";
        }
        else if (id == 3)
        {
            ss.text = "Assult E13\nSpeed: 3\nHull: 50\nStorage: 10\nWeapons: 15\nCredits: 400";
        }
        else if (id == 4)
        {
            ss.text = "The Tank\nSpeed: 1\nHull: 30\nStorage: 20\nWeapons: 10\nCredits: 200";
        }
    }

    void OnMouseExit()
    {
        sr.gameObject.transform.position = new Vector3(sr.gameObject.transform.position.x, sr.gameObject.transform.position.y, 10.0f);
        ss.text = "";
        play = true;
    }

    void OnMouseDown()
    {
        Singleton.data.click.Play();

        if (id == 1)
        {
            Singleton.data.plyr.shipname = "B15 Defender";
            Singleton.data.plyr.speed = 3;
            Singleton.data.plyr.hull = 20;
            Singleton.data.plyr.hullmax = 20;
            Singleton.data.plyr.capmax = 15;
            Singleton.data.plyr.weapons = 10;
            Singleton.data.plyr.credits += 100;
        }
        else if (id == 2)
        {
            Singleton.data.plyr.shipname = "Speed Rogue";
            Singleton.data.plyr.speed = 5;
            Singleton.data.plyr.hull = 10;
            Singleton.data.plyr.hullmax = 10;
            Singleton.data.plyr.capmax = 10;
            Singleton.data.plyr.weapons = 5;
            Singleton.data.plyr.credits += 300;
        }
        else if (id == 3)
        {
            Singleton.data.plyr.shipname = "Assult E13";
            Singleton.data.plyr.speed = 3;
            Singleton.data.plyr.hull = 50;
            Singleton.data.plyr.hullmax = 50;
            Singleton.data.plyr.capmax = 10;
            Singleton.data.plyr.weapons = 15;
            Singleton.data.plyr.credits += 200;
        }
        else
        {
            Singleton.data.plyr.shipname = "The Tank";
            Singleton.data.plyr.speed = 1;
            Singleton.data.plyr.hull = 30;
            Singleton.data.plyr.hullmax = 30;
            Singleton.data.plyr.capmax = 20;
            Singleton.data.plyr.weapons = 10;
        }

        Singleton.data.plyr.ship = id;
        SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
    }
}

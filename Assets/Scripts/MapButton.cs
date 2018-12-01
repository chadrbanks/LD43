using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    public int planetid;
    public TextMesh pname;
    public TextMesh pdesc;
    public MapHandler mh;

    SpriteRenderer sr;
    public AudioSource hover;
    bool play = true;

	void Start ()
    {
        if (planetid == 4)
        {
            if (Singleton.data.plyr.aicomp >= 20)
            {
                //
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
        else if (planetid == 5)
        {
            if (Singleton.data.plyr.explored >= 1)
            {
                //
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseOver()
    {
        if (play)
        {
            hover.Play();
            play = false;
        }

        mh.setHeader(planetid);

        sr.transform.position = new Vector3(sr.transform.position.x, sr.transform.position.y, -1.0f);

        if (planetid == 1)
        {
            pname.text = "The Emerald Planet";
            pdesc.text = "The busiest planet with the\nmost people living on it.\nThis planets population\nexploded rapidly due to all\nof the highly valued\nmaterials on it.\nWith quick growth comes\nlots of crime though.";
        }
        else if (planetid == 2)
        {
            pname.text = "New Earth";
            pdesc.text = "An earth like planet!";
        }
        else if (planetid == 3)
        {
            pname.text = "Santigo 3G";
            pdesc.text = "A very hot planet with\ntripple the Earths gravity.\nAside from the space port\nabove the planet, there is\nnot a lot of activity on the\nsurface other than mining.";
        }
        else if (planetid == 4)
        {
            pname.text = "Space Station Base";
            pdesc.text = "A remote base in space.\nStrange things are\nhappening here.";
        }
        else if (planetid == 5)
        {
            pname.text = "Average Asteroid";
            pdesc.text = "This is no moon.\nThis appears to be normal.\nBut upon closer inspection....\nit is not!";
        }
        else
        {
            pname.text = "MISSINGNO";
        }
    }

    void OnMouseExit()
    {
        sr.transform.position = new Vector3(sr.transform.position.x, sr.transform.position.y, 0f);
        pname.text = "";
        pdesc.text = "";
        play = true;
    }

    // 1 - Gun
    // 2 - Crystals
    // 3 - Fuel
    // 4 - MedPod
    // 5 - Drugs
    void OnMouseDown()
    {
        Singleton.data.shipsound.Play();
        if (planetid == 1) // Green
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(5, 20);
            Singleton.data.prices[2] = Random.Range(50, 150);
            Singleton.data.prices[3] = Random.Range(90, 150);
            Singleton.data.prices[4] = Random.Range(900, 1500);
            Singleton.data.prices[5] = Random.Range(50, 100);
        }
        else if (planetid == 2) // Blue
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(1, 10);
            Singleton.data.prices[2] = Random.Range(250, 400);
            Singleton.data.prices[3] = Random.Range(150, 200);
            Singleton.data.prices[4] = Random.Range(750, 1000);
            Singleton.data.prices[5] = Random.Range(100, 200);
        }
        else if (planetid == 3) // Red
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(50, 150);
            Singleton.data.prices[2] = Random.Range(100, 250);
            Singleton.data.prices[3] = Random.Range(50, 100);
            Singleton.data.prices[4] = Random.Range(750, 1500);
            Singleton.data.prices[5] = Random.Range(10, 100);
        }
        else if (planetid == 4) // Sat
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(300, 500);
            Singleton.data.prices[2] = Random.Range(10, 200);
            Singleton.data.prices[3] = Random.Range(300, 500);
            Singleton.data.prices[4] = Random.Range(750, 1000);
            Singleton.data.prices[5] = Random.Range(50, 100);
        }
        else if (planetid == 5) // Asteroid
        {
            Singleton.data.prices[0] = 0;
            Singleton.data.prices[1] = Random.Range(200, 300);
            Singleton.data.prices[2] = Random.Range(300, 500);
            Singleton.data.prices[3] = Random.Range(90, 150);
            Singleton.data.prices[4] = Random.Range(750, 1000);
            Singleton.data.prices[5] = Random.Range(100, 200);
        }

        Singleton.data.plyr.planet = planetid;

        SceneManager.LoadScene("GameScene2", LoadSceneMode.Single);
    }

	void Update ()
    {
		
	}
}

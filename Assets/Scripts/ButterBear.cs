using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButterBear : MonoBehaviour
{
    private float timetime = 0;
    private int nextUpdate = 1;
    private int holdUpdate = 0;

	void Start ()
    {
		//
    }

    private void Update()
    {
        Color tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = tmp.a + 0.01F;
        GetComponent<SpriteRenderer>().color = tmp;

        if (tmp.a >= 1)
        {
            timetime += Time.deltaTime;
            if (timetime >= nextUpdate)
            {
                timetime = 0;

                if (holdUpdate >= 2)
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                }
                else
                {
                    holdUpdate++;
                }
            }
        }
    }
}

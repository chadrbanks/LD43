using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameButtonType
{
    Home, Cantina, Market, Mine, Explore, Leave, Mine2, Quest, Repair
}

public class GameButton : MonoBehaviour
{
    //public GameEngine engn;
    //public GameButtonType bt;

    //[SerializeField] private Material m_NormalMaterial;
    //[SerializeField] private Material m_OverMaterial;
    //[SerializeField] private Material m_ClickedMaterial;
    //[SerializeField] private Renderer m_Renderer;

    bool over = false;

    //public AudioSource hover;
    bool play = true;

    void Start()
    {
        //m_Renderer.material = m_NormalMaterial;
    }

    void OnMouseOver()
    {
        if (play)
        {
            //hover.Play();
            play = false;
        }

        if (!over)
        {
            //m_Renderer.material = m_OverMaterial;
        }

        over = true;
    }

    void OnMouseExit()
    {
        //m_Renderer.material = m_NormalMaterial;
        over = false;
        play = true;
    }

    void OnMouseDown()
    {
        
    }

    void OnMouseUp()
    {
        //Singleton.data.click.Play();
        /*
        if (bt == GameButtonType.Leave)
        {
            if( engn.Leave( ) )
            {
                int encounter = 30;

                if(Singleton.data.plyr.planet == 1)
                {
                    if( Random.Range( 1, 100 ) < 50 )
                        Singleton.data.raid = 1;
                    else
                        Singleton.data.raid = 2;
                }
                else if (Singleton.data.plyr.planet == 2)
                {
                    Singleton.data.raid = 1; // SF
                }
                else if (Singleton.data.plyr.planet == 3)
                {
                    Singleton.data.raid = 2; // Pirate?
                }
                else if (Singleton.data.plyr.planet == 4)
                {
                    Singleton.data.raid = 2; // Pirate?
                }
                else if (Singleton.data.plyr.planet == 5)
                {
                    if (Random.Range(1, 100) < 50)
                        Singleton.data.raid = 1;
                    else
                        Singleton.data.raid = 2;
                }

                if (Random.Range(1, 100) < encounter)
                {
                    SceneManager.LoadScene("EncounterScene", LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
                }
            }
        }
        else
        {
            engn.ClickedButton(bt);
        }
        */
        SceneManager.LoadScene("DeckSelectionManage", LoadSceneMode.Single);
    }
}
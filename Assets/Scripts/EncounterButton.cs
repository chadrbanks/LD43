using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EncounterButtonType
{
    Attack, Pay, Leave, Quit, Play
}

public class EncounterButton : MonoBehaviour
{
    public EncounterHandler engn;
    public EncounterButtonType bt;

    public AudioSource hover;
    bool play = true;

    //bool over = false;

    void Start()
    {
        //m_Renderer.material = m_NormalMaterial;
    }

    void OnMouseOver()
    {
        if (play)
        {
            hover.Play();
            play = false;
        }
    }

    void OnMouseExit()
    {
        play = true;
    }

    void OnMouseDown()
    {

    }

    void OnMouseUp()
    {
        Singleton.data.click.Play();

        if (bt == EncounterButtonType.Attack)
        {
            engn.Action( 1 );
        }
        else if (bt == EncounterButtonType.Leave)
        {
            engn.Action(2);
        }
        else if (bt == EncounterButtonType.Pay)
        {
            engn.Action(3);
        }
        else if (bt == EncounterButtonType.Quit)
        {
            engn.Action(4);
        }
        else if (bt == EncounterButtonType.Play)
        {
            engn.Action(5);
        }
    }
}
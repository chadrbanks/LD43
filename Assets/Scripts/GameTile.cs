using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTileType
{
    Agr, Civ, Eng, Med, Mil, Sci
}

public class GameTile : MonoBehaviour
{
    public GameTileType gt;
    public ShipEngine shipengn;

    //[SerializeField] private Material m_NormalMaterial;
    //[SerializeField] private Material m_OverMaterial;
    //[SerializeField] private Material m_ClickedMaterial;
    //[SerializeField] private Renderer m_Renderer;

    public AudioSource hover;
    bool over = false;
    bool play = true;

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
        //m_Renderer.material = m_ClickedMaterial;
    }

    void OnMouseUp()
    {
        //m_Renderer.material = m_OverMaterial;

        int i = 1;

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            i = 10;

        if (gt == GameTileType.Agr)
        {
            if( shipengn.civ >= i )
            {
                shipengn.civ -= i;
                shipengn.agr += i;
            }
        }
        else if (gt == GameTileType.Civ)
        {
            //
        }
        else if (gt == GameTileType.Eng)
        {
            if (shipengn.civ >= i)
            {
                shipengn.civ -= i;
                shipengn.eng += i;
            }
        }
        else if (gt == GameTileType.Med)
        {
            if (shipengn.civ >= i)
            {
                shipengn.civ -= i;
                shipengn.med += i;
            }
        }
        else if (gt == GameTileType.Mil)
        {
            if (shipengn.civ >= i)
            {
                shipengn.civ -= i;
                shipengn.mil += i;
            }
        }
        else if (gt == GameTileType.Sci)
        {
            if (shipengn.civ >= i)
            {
                shipengn.civ -= i;
                shipengn.sci += i;
            }
        }
    }
}

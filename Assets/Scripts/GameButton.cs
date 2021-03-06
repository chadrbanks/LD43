﻿using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameButtonType
{
    Advance, Quit
}

public class GameButton : MonoBehaviour
{
    public GameButtonType bt;
    public ShipEngine shipengn;

    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    [SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private Renderer m_Renderer;

    public AudioSource hover;
    bool over = false;
    bool play = true;

    void Start()
    {
        m_Renderer.material = m_NormalMaterial;
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
            m_Renderer.material = m_OverMaterial;
        }

        over = true;
    }

    void OnMouseExit()
    {
        m_Renderer.material = m_NormalMaterial;
        over = false;
        play = true;
    }

    void OnMouseDown()
    {
        m_Renderer.material = m_ClickedMaterial;
    }

    void OnMouseUp()
    {
        //Singleton.data.click.Play();

        m_Renderer.material = m_OverMaterial;//m_NormalMaterial;

        if (bt == GameButtonType.Advance)
        {
            shipengn.NextMonth();
        }
        else if (bt == GameButtonType.Quit)
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}
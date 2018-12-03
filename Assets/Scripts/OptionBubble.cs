using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBubble : MonoBehaviour
{
    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    [SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private Renderer m_Renderer;

    bool over = false;

    public int set;
    public int place;

    public TextMesh txt;

    ZombieHandler zombie;

    void Start()
    {
        m_Renderer.material = m_NormalMaterial;
    }

    public void SetEngine( ZombieHandler z, int s, int p )
    {
        set = s;
        place = p;
        zombie = z;
    }

    public void SetText(string t)
    {
        txt.text = t;
    }

    void OnMouseOver()
    {
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
    }

    void OnMouseDown()
    {
        m_Renderer.material = m_ClickedMaterial;
    }

    void OnMouseUp()
    {
        m_Renderer.material = m_OverMaterial;

        if( place == 0 )
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }

        if( zombie.OptionSet == set )
        {
            zombie.SelectOption(place);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubble : MonoBehaviour
{
    [SerializeField] private Material m_NormalMaterial;
    [SerializeField] private Material m_OverMaterial;
    //[SerializeField] private Material m_ClickedMaterial;
    [SerializeField] private Renderer m_Renderer;

    bool over = false;

    public TextMesh txt;

	// Use this for initialization
	void Start ()
    {
        m_Renderer.material = m_NormalMaterial;
    }

    public void SetText( string t )
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
        //m_Renderer.material = m_ClickedMaterial;
    }
}

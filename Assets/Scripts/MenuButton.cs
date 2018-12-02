using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MenuButtonType
{
	Start, Quit, Credits, Back, Load
}

public class MenuButton : MonoBehaviour
{
	//public MainEngine engn;
	public MenuButtonType bt;

	[SerializeField] private Material m_NormalMaterial;
	[SerializeField] private Material m_OverMaterial;
	[SerializeField] private Material m_ClickedMaterial;
	[SerializeField] private Renderer m_Renderer;

    bool over = false;

    public AudioSource hover;
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

		if (bt == MenuButtonType.Start)
        {
            Singleton.data.restartGame();

            SceneManager.LoadScene ("DeckSelectionBattle", LoadSceneMode.Single);
        }
        else if (bt == MenuButtonType.Load)
        {
            Singleton.data.LoadGame();
            SceneManager.LoadScene("DeckSelectionManage", LoadSceneMode.Single);
        }
        else if (bt == MenuButtonType.Back)
        {
            //Singleton.data.LoadGame();
            SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
        }
        else if (bt == MenuButtonType.Credits)
        {
            SceneManager.LoadScene("CreditScene", LoadSceneMode.Single);
        }
		else if (bt == MenuButtonType.Quit)
		{
			UnityEngine.Application.Quit ();

			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#endif
		}
	}
}
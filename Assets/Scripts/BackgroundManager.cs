using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Renderer m_Renderer;
    [SerializeField] public Material[] bgs;

	void Start ()
    {
        m_Renderer.material = bgs[ Singleton.data.plyr.planet ];
	}
}

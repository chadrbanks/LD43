using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreButton : MonoBehaviour
{
    GameEngine engn;

    public int id = 1;
    public bool buy;

    void Start()
    {
        //
    }

    void OnMouseDown()
    {
        engn.MarketClick(this, buy);
    }

    public void Setup(GameEngine ge)
    {
        engn = ge;
        //m_Renderer.material = engn.bgs[id];
    }

    void Update()
    {
        //
    }
}

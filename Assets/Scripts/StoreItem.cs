using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreItem : MonoBehaviour
{
    //GameEngine engn;
    public TextMesh  bstxt, qtytxt;

    public int id = 1;

    void Start()
    {
        //
    }

    void OnMouseDown()
    {
        //engn.ItemClickStore(this);
    }

    public void Setup(GameEngine ge)
    {
        //engn = ge;
        //m_Renderer.material = engn.bgs[id];
    }

    void Update()
    {
        bstxt.text = "B: " + Singleton.data.prices[id] + "  S: " + Mathf.Round(Singleton.data.prices[id] * .8f);
        qtytxt.text = "" + Singleton.data.plyr.goods[id];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEngine : MonoBehaviour
{
    public StoreButton[] marketbuttons;
    [SerializeField] public Material[] bgs;
    public TextMesh pname;
    public TextMesh pdesc;
    public TextMesh ship1, ship2, cantext;
    public GameObject market, cantina, mines;
    public GameObject[] cantinappl;

    bool cheap = false;

	void Start ()
    {
        for (int x = 0; x < marketbuttons.Length; x++)
        {
            marketbuttons[x].Setup(this);
        }

        for (int x = 0; x < cantinappl.Length; x++)
        {
            cantinappl[x].SetActive(false);
        }

        SetupPlanet();
    }

    public void SetupPlanet()
    {
        cantinappl[ Singleton.data.plyr.planet-1 ].SetActive( true );

        if (Singleton.data.plyr.planet == 1)
        {
            pname.text = "The Emerald Planet";
            cantext.text = "Ever since the Space Force started coming around here, it has been hard to find shipments of drugs.\nI have pleanty of sentry guns though.\nWanna trade one for one?";
            //pdesc.text = "The busiest planet with the\nmost people living on it.\nThis planets population\nexploded rapidly due to all\nof the highly valued\nmaterials on it.\nWith quick growth comes\nlots of crime though.";
        }
        else if (Singleton.data.plyr.planet == 2)
        {
            pname.text = "New Earth";
            cantext.text = "Hey Friend!\n\nI am working on a special project that I can't talk much about.\nBut you know that every ship has an AI assistant pilot on board right?\nWell fun fact, if you destroy a ship, Pirate or Space Force,\nyour AI will automatically download a copy of the one on-board the enemies ship.\nBrings those to me and I can reward you.\nWhat do you say, think we can be friends?";
            //pdesc.text = "An earth like planet!";
        }
        else if (Singleton.data.plyr.planet == 3)
        {
            pname.text = "Santigo 3G";
            cantext.text = "I need medi-pods down here. I have a lot of good workers getting hurt in this horrible work environmnet.\nI can't really pay much but we have tons of skilled workers and spare parts.\nHow about a free ship repair and upgrade for every medi-pod you bring me?";
            //pdesc.text = "A very hot planet with\ntripple the Earths gravity. Aside from the space port above the planet, there is not a lot of activity on the surface other than mining.";
        }
        else if (Singleton.data.plyr.planet == 4)
        {
            pname.text = "Space Station Base";
            cantext.text = "Fuel.\nBottom line is I need it, a lot of it.\nWe are creating a lot of new powerful technology here, and we are gearing up for war.\nFor every unit you bring me, I can turn it into 5.\n\nYour cut can be two of those 5 new fuel.\nJust keep in mind this neo-fuel is not the same as regular fuel. It cannot be re-sold on any market, but it also does not use your ships capacity.";
            //pdesc.text = "A very hot planet with\ntripple the Earths gravity. Aside from the space port above the planet, there is not a lot of activity on the surface other than mining.";
        }
        else if (Singleton.data.plyr.planet == 5)
        {
            pname.text = "Average Asteroid";
            cantext.text = "Simple operation here.\nOne sentry gun, one crystal, and 1000 credits.\nI upgrade your ships weapons and I also keep the credits.";
            //pdesc.text = "A very hot planet with\ntripple the Earths gravity. Aside from the space port above the planet, there is not a lot of activity on the surface other than mining.";
        }
        else
        {
            pname.text = "MISSINGNO";
            //pdesc.text = "Description.";
        }

        pdesc.text = "Select an action to the left.\n\nPlanet stats coming soon.";

        cantina.SetActive(false);
        market.SetActive(false);
        mines.SetActive(false);
    }

    public bool Leave()
    {
        if( Singleton.data.UseFuel() )
        {
            return true;
        }

        pdesc.text = "You do not have enough fuel to leave.";
        return false;
    }

    // TODO : This needs to be broken down into sub functions!
    public void ClickedButton( GameButtonType bt )
    {
        cantina.SetActive(false);
        market.SetActive(false);
        mines.SetActive(false);
        //lg.text = "Action completed: " + bt;
        if (bt == GameButtonType.Home )
        {
            SetupPlanet();
        }
        else if (bt == GameButtonType.Cantina)
        {
            cantina.SetActive(true);

            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Cantina";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "The Rusty Wrynn";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                pname.text = "Santigo Cantigo";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 4)
            {
                pname.text = "Sat Port";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 5)
            {
                pname.text = "Asteroid Escape!";
                pdesc.text = "";
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Repair)
        {
            if( Singleton.data.plyr.hullmax > Singleton.data.plyr.hull)
            {
                if (!cheap)
                {
                    int damage = Singleton.data.plyr.hullmax - Singleton.data.plyr.hull;
                    int cost = damage * 50;

                    if (Singleton.data.plyr.credits >= cost)
                    {
                        Singleton.data.plyr.credits -= cost;
                        Singleton.data.plyr.hull = Singleton.data.plyr.hullmax;
                    }
                    else
                    {
                        cheap = true;
                        pdesc.text = "You cannot afford the " + cost + " credits needed for repairs.";
                        pdesc.text = pdesc.text + "\n\nClick again to buy them in 50 credit increments (+1 hull).";
                    }
                }
                else
                {
                    if (Singleton.data.plyr.credits >= 50)
                    {
                        Singleton.data.plyr.credits -= 50;
                        Singleton.data.plyr.hull++;
                    }
                    else
                    {
                        //cheap = true;
                        pdesc.text = "You cannot afford the 50 credits needed for 1 hull repair.";
                    }
                }
             }
            else
            {
                pdesc.text = "Your ship does not need repairs.";
            }
        }
        else if (bt == GameButtonType.Quest)
        {
            cantina.SetActive(true);

            if (Singleton.data.plyr.planet == 1)
            {
                // if drugs give guns
                if (Singleton.data.plyr.goods[5] > 0)
                {
                    Singleton.data.plyr.goods[1]++;
                    Singleton.data.plyr.goods[5]--;

                    cantext.text = "Thank you, here is the sentry gun as promised.";
                }
                else
                {
                    cantext.text = "You have no drugs at all, why are you wasting my time?";
                }
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                // if ai give reward
                if (Singleton.data.plyr.aicore > 0)
                {
                    Singleton.data.plyr.aicore--;
                    Singleton.data.plyr.aicomp++;

                    int reward = (200 * Singleton.data.plyr.aicomp);
                    Singleton.data.plyr.credits += reward;

                    if (Singleton.data.plyr.aicomp == 20)
                    {
                        cantext.text = "Thanks for all the work you have been doing. Here is a key to my projects secret location!";
                    }
                    else
                    {
                        cantext.text = "Nice work! Here is " + reward + " credits, come back and it will be more next time!";
                    }
                }
                else
                {
                    cantext.text = "You have no cores, please come back after you aquire some!";
                }
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                if (Singleton.data.plyr.goods[4] > 0)
                {
                    Singleton.data.plyr.goods[4]--;

                    int roll = Random.Range(1, 100);
                    if (roll < 25)
                    {
                        Singleton.data.plyr.weapons++;
                    }
                    else if (roll < 50)
                    {
                        Singleton.data.plyr.hullmax++;
                        Singleton.data.plyr.hull++;
                    }
                    else if (roll < 75)
                    {
                        Singleton.data.plyr.capmax++;
                    }
                    else
                    {
                        Singleton.data.plyr.speed++;
                    }

                    Singleton.data.plyr.hull = Singleton.data.plyr.hullmax;

                    cantext.text = "Thank you, enjoy your ship upgrade!";
                }
                else
                {
                    cantext.text = "You have no medi-pods, come back when you are serious!";
                }
            }
            else if (Singleton.data.plyr.planet == 4)
            {
                // if fuel give 2 neo-fuel
                if (Singleton.data.plyr.goods[3] > 0)
                {
                    Singleton.data.plyr.neofuel += 2;
                    Singleton.data.plyr.goods[3]--;

                    cantext.text = "Thank you, here is 2 units of neo-fuel.";
                }
                else
                {
                    cantext.text = "You have no fuel, what am I supposed to do?";
                }
            }
            else if (Singleton.data.plyr.planet == 5)
            {
                // if crystal&gun&credits give +1 weapons
                if ( Singleton.data.plyr.goods[1] > 0 && Singleton.data.plyr.goods[2] > 0 && Singleton.data.plyr.credits >= 1000 )
                {
                    Singleton.data.plyr.weapons++;
                    Singleton.data.plyr.goods[1]--;
                    Singleton.data.plyr.goods[2]--;
                    Singleton.data.plyr.credits -= 1000;

                    cantext.text = "Nice doin' business!";
                }
                else
                {
                    cantext.text = "What do you want?";
                }
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Market )
        {
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Market";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "The Overground";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                pname.text = "Sand Road";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 4)
            {
                pname.text = "Trading Orb";
                pdesc.text = "";
            }
            else if (Singleton.data.plyr.planet == 5)
            {
                pname.text = "Aazaar";
                pdesc.text = "";
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Market goes here.";
            }

            market.SetActive(true);
        }
        else if (bt == GameButtonType.Mine)
        {
            if (Singleton.data.plyr.planet == 1)
            {
                pname.text = "The Green Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else if (Singleton.data.plyr.planet == 2)
            {
                pname.text = "New Earth";
                pdesc.text = "You cannot mine here.";
            }
            else if (Singleton.data.plyr.planet == 3)
            {
                pname.text = "Santigo Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else if (Singleton.data.plyr.planet == 4)
            {
                pname.text = "Space Station";
                pdesc.text = "You cannot mine here.";
            }
            else if (Singleton.data.plyr.planet == 5)
            {
                pname.text = "Asteroid Mines";
                pdesc.text = "";
                mines.SetActive(true);
            }
            else
            {
                pname.text = "MISSINGNO";
                pdesc.text = "Description.";
            }
        }
        else if (bt == GameButtonType.Mine2)
        {
            mines.SetActive(true);

            if (Singleton.data.UseFuel())
            {
                if (Singleton.data.plyr.planet == 1)
                {
                    float r = Random.Range(1, 100);

                    if( r < 25 )
                    {
                        pdesc.text = "You were unable to find anything!";
                    }
                    else if (r < 80)
                    {
                        float c = Random.Range(1, 250);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined some material worth " + c + " credits!";
                    }
                    else
                    {
                        Singleton.data.plyr.goods[2]++;
                        pdesc.text = "You mined some green crystal!";
                    }
                }
                else if (Singleton.data.plyr.planet == 2)
                {
                    //
                }
                else if (Singleton.data.plyr.planet == 3)
                {
                    float r = Random.Range(1, 100);

                    if (r < 25)
                    {
                        pdesc.text = "You were unable to find anything!";
                    }
                    else if (r < 80)
                    {
                        float c = Random.Range(1, 250);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined some material worth " + c + " credits!";
                    }
                    else
                    {
                        Singleton.data.plyr.goods[3]++;
                        pdesc.text = "You struck oil, the fuel has been added to your cargo!";
                    }
                }
                else if (Singleton.data.plyr.planet == 4)
                {
                    //
                }
                else if (Singleton.data.plyr.planet == 5)
                {
                    float r = Random.Range(1, 100);

                    if (r < 25)
                    {
                        pdesc.text = "You were unable to find anything!";
                    }
                    else if (r < 80)
                    {
                        float c = Random.Range(1, 250);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined some material worth " + c + " credits!";
                    }
                    else
                    {
                        float c = Random.Range(200, 500);
                        Singleton.data.plyr.credits += c;
                        pdesc.text = "You mined a big cache of material worth " + c + " credits!";
                    }
                }
                else
                {
                    pname.text = "MISSINGNO";
                    pdesc.text = "Description.";
                }
            }
            else
            {
                pdesc.text = "You do not have enough fuel to go mine.";
            }
        }
        else if (bt == GameButtonType.Explore )
        {
            if (Singleton.data.UseFuel())
            {
                if (Singleton.data.plyr.explored < 1)
                {
                    if (Singleton.data.plyr.planet == 2)
                    {
                        pname.text = "New Earth";
                        pdesc.text = "There is nothing on this planet to explore.";
                    }
                    else if (Random.Range(1, 100) < 11)
                    {
                        Singleton.data.plyr.explored = 1;

                        pname.text = "Hidden Map!";
                        pdesc.text = "You found coords to A hidden place!\n\nIt will now show up on your map!";
                    }
                    else
                    {
                        pname.text = "Nothing!";
                        pdesc.text = "You found nothing of value!";
                    }
                }
                else
                {
                    if (Singleton.data.plyr.planet == 1)
                    {
                        pname.text = "The Green Planet";
                        pdesc.text = "You find nothing.";
                    }
                    else if (Singleton.data.plyr.planet == 2)
                    {
                        pname.text = "New Earth";
                        pdesc.text = "There is not much on this planet to explore.";
                    }
                    else if (Singleton.data.plyr.planet == 3)
                    {
                        pname.text = "Santigo 3G";
                        pdesc.text = "You find nothing.";
                    }
                    else if (Singleton.data.plyr.planet == 4)
                    {
                        pname.text = "Satellite";
                        pdesc.text = "There is nothing on this satillite to explore.";
                    }
                    else if (Singleton.data.plyr.planet == 5)
                    {
                        pname.text = "Asteroid";
                        pdesc.text = "There is nothing on this tiny rock to explore.";
                    }
                    else
                    {
                        pname.text = "MISSINGNO";
                        pdesc.text = "Description.";
                    }
                }
            }
            else
            {
                pdesc.text = "You do not have any fuel to do this.";
            }
        }
        else
        {
            Debug.Log(bt);
        }
    }

    public int getCapacityUse()
    {
        return Singleton.data.plyr.goods[1] + Singleton.data.plyr.goods[2] + Singleton.data.plyr.goods[3] + Singleton.data.plyr.goods[4] + Singleton.data.plyr.goods[5];
    }

    public void MarketClick( StoreButton item, bool buy )
    {
        if( buy )
        {
            int cap = getCapacityUse();
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Singleton.data.plyr.credits >= Singleton.data.prices[item.id] * 10 && (Singleton.data.plyr.capmax - cap) >= 10)
                {
                    Singleton.data.plyr.credits -= Singleton.data.prices[item.id] * 10;
                    Singleton.data.plyr.goods[item.id] += 10;
                }
            }
            else if (Singleton.data.plyr.credits >= Singleton.data.prices[item.id] && cap < Singleton.data.plyr.capmax)
            {
                Singleton.data.plyr.credits -= Singleton.data.prices[item.id];
                Singleton.data.plyr.goods[item.id]++;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (Singleton.data.plyr.goods[item.id] >= 10)
                {
                    Singleton.data.plyr.credits += Mathf.Round(Singleton.data.prices[item.id] * 10 * .8F);
                    Singleton.data.plyr.goods[item.id] -= 10;
                }
            }
            else if (Singleton.data.plyr.goods[item.id] >= 1)
            {
                Singleton.data.plyr.credits += Mathf.Round(Singleton.data.prices[item.id] * .8F);
                Singleton.data.plyr.goods[item.id]--;
            }
        }
    }

    void Update ()
    {
        int cap = getCapacityUse();

        ship1.text = Singleton.data.plyr.shipname + "\nHull: " + Singleton.data.plyr.hull + " / " + Singleton.data.plyr.hullmax + "\nWeapons: " + Singleton.data.plyr.weapons + "\nSpeed: " + Singleton.data.plyr.speed;
        ship2.text = "Capacity: " + cap + " / " + Singleton.data.plyr.capmax + "\nFuel: " + Singleton.data.GetFuel() + "\nCredits: " + Singleton.data.plyr.credits;// + "\nQuests: 0";

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}
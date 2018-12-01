using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterHandler : MonoBehaviour
{
    public TextMesh ship1, ship2, etxt, mtxt;

    string eship;
    public int speed, hull, hullmax, weapons;

    float fee, mul;

    bool battleon = true;

    public GameObject quit, resume, battle;

    public AudioSource fail;

	void Start ()
    {
        quit.SetActive(false);
        resume.SetActive(false);
        battle.SetActive(true);

        speed = Random.Range( 1, 7 );
        weapons = Random.Range( 5, 20);
        hullmax = Random.Range( 5, 50);

        hull = Random.Range( 2, hullmax );

        int r = Random.Range(1, 100);
        if( r < 25 )
        {
            mul = 2;
        }
        else if( r < 50 )
        {
            mul = 5;
        }
        else if( r < 75 )
        {
            mul = 10;
        }
        else
        {
            mul = 20;
        }

        fee = (speed + weapons + hull + hullmax + 1) * mul;

        if (Singleton.data.raid == 1 )
        {
            eship = "Space Force Ship";
            mtxt.text = "A " + eship + " has stopped you.\nThey are threatening to raid your vessel.\n\nThey will accept a " + fee + " credit bribe.\n\nPlease choose an action to the left.";
        }
        else
        {
            eship = "Pirate Ship";
            mtxt.text = "You have encountered a " + eship + ".\n\n" + fee + " credit protection fee.\n\nPlease choose an action to the left.";

        }
    }

    void EnemyAttacks()
    {
        if (battleon)
        {
            Singleton.data.plyr.hull -= weapons;

            mtxt.text = mtxt.text + "\nThe enemy ship hit you for " + weapons + " damage.";

            if (Singleton.data.plyr.hull <= 0)
            {
                battleon = false;
                mtxt.text = mtxt.text + "\nYour ship was destoyed!";
                fail.Play();
            }
        }
        UpdateScreen();
    }

    void PlayerAttacks()
    {
        if( battleon )
        {
            hull -= Singleton.data.plyr.weapons;

            mtxt.text = mtxt.text + "\nYou hit the enemy ship for " + Singleton.data.plyr.weapons + " damage.";

            if (hull <= 0)
            {
                battleon = false;
                Singleton.data.plyr.aicore++;
                mtxt.text = mtxt.text + "\nYou destroyed the enemy ship!";
            }
        }
        UpdateScreen();
    }

    void UpdateScreen()
    {
        if( !battleon )
        {
            battle.SetActive(false);

            if (Singleton.data.plyr.hull > 0)
            {
                resume.SetActive(true);
            }
            else
            {
                quit.SetActive(true);
            }
        }
    }

    public void Action( int a )
    {
        if (a == 1) // Attack
        {
            mtxt.text = "";

            if (Singleton.data.plyr.speed < speed)
            {
                EnemyAttacks();
                PlayerAttacks();
            }
            else
            {
                EnemyAttacks();
                PlayerAttacks();
            }
        }
        else if (a == 2) // Flee
        {
            mtxt.text = "";

            int attempt = Random.Range(1, 10) - 5 + Singleton.data.plyr.speed;
            if (attempt < speed)
            {
                mtxt.text = "Your ship was not fast enough to get away.";
                EnemyAttacks();
            }
            else
            {
                battleon = false;
                mtxt.text = "You get away safely.";
                UpdateScreen();//SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
            }
        }
        else if (a == 3) // Pay
        {
            mtxt.text = "";

            if (Singleton.data.plyr.credits < fee)
            {
                mtxt.text = "You cannot afford the fee!";
            }
            else
            {
                Singleton.data.plyr.credits -= fee;
                battleon = false;
                mtxt.text = "You pay the fee and they depart.";
                UpdateScreen();
            }
        }
        else if (a == 4) // Quit
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
        else if (a == 5) // Play
        {
            SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
        }
    }

    void Update()
    {
        int cap = Singleton.data.getCapacityUse();

        etxt.text = eship + "\nHull: " + hull + " / " + hullmax + "\nWeapons: " + weapons + "\nSpeed: " + speed + "\nFee: " + fee;

        ship1.text = Singleton.data.plyr.shipname + "\nHull: " + Singleton.data.plyr.hull + " / " + Singleton.data.plyr.hullmax + "\nWeapons: " + Singleton.data.plyr.weapons + "\nSpeed: " + Singleton.data.plyr.speed;
        ship2.text = "Capacity: " + cap + " / " + Singleton.data.plyr.capmax + "\nFuel: " + Singleton.data.plyr.goods[3] + "\nCredits: " + Singleton.data.plyr.credits;// + "\nQuests: 0";
    }
}

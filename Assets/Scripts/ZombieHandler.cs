using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandler : MonoBehaviour
{
    public TextBubble tb;
    public OptionBubble ob;

    //public GameObject[] options;
    public List<OptionBubble> options;// { get; set; }

    public int OptionSet = 1;
    float NextY = 6.25f;

    // Player variables
    int Prof = 0;
    int Gender = 0;
    int Location = 0;
    string Name = "";

	// Use this for initialization
	void Start ()
    {
        Prof = Random.Range(1, 11);
        Location = Random.Range(0, 1);
        Gender = Random.Range(0, 2);

        if( Location == 0 )
        {
            //
        }

        if( Gender > 0 )
        {
            Name = "John";
        }
        else
        {
            Name = "Jane";
        }

        SpawnText("[ New Signal Aquired ]");
        SpawnText("Hi. My name is " + Name + " and I am a " + Prof + " here in Some City.");
        SpawnText("I was at home when the Zombie attack started!");
        SpawnText("It hasn't even been that long, and there are already several of them pounding on the windows.");
        SpawnText("What should I do?");

        SpawnOption(1, 1);
        SpawnOption(2, 2);
        SpawnOption(3, 3);
        NextY -= (float)0.75;
    }

    void SpawnQuit( )
    {
        Vector3 nv = new Vector3(0, NextY, 0);
        OptionBubble b = Instantiate(ob, nv, Quaternion.identity) as OptionBubble;
        b.SetEngine(this, OptionSet, 0);
        b.SetText("Back to menu.");
    }

    void SpawnText(string t)
    {
        // TODO : Sound on spawn
        // TODO : Fade in and float up into space

        Vector3 nv = new Vector3(-1, NextY, 0);
        TextBubble b = Instantiate(tb, nv, Quaternion.identity) as TextBubble;
        b.SetText(t);

        NextY -= (float)0.75;
    }

    void SpawnOption(int place, int option)
    {
        // TODO : Sound on spawn
        // TODO : Fade in and float up into space

        int newp = 0;
        if (place == 1)
            newp = -7;
        if (place == 2)
            newp = 0;
        if (place == 3)
            newp = 7;

        Vector3 nv = new Vector3(newp, NextY, 0);
        OptionBubble b = Instantiate(ob, nv, Quaternion.identity) as OptionBubble;
        b.SetEngine(this, OptionSet, place);

        switch( option )
        {
            case 1:
                b.SetText("Just stay quiet.");
                break;
            case 2:
                b.SetText("Get out of there fast!");
                break;
            case 3:
                b.SetText("You got to fight them, do you have a weapon?");
                break;
        }

        //NextY -= (float)0.75;

        //options.Add(b);
    }

    public void SelectOption( int o )
    {
        switch( o )
        {
            case 1:
                {
                    SpawnText("[ 30 minutes later ]");
                    SpawnText("They busted through!");
                    SpawnText("Oh my god! What do I do?");
                    SpawnText("Aghhhhhhhh!");
                    SpawnText("[ Signal Lost ]");

                    SpawnQuit();

                    OptionSet++;
                    //NextY -= (float)0.75;
                    break;
                }
            case 2:
                {
                    SpawnText("[ 5 minutes later ]");
                    SpawnText("They busted through!");
                    SpawnText("Oh my god! What do I do?");
                    SpawnText("Aghhhhhhhh!");
                    SpawnText("[ Signal Lost ]");

                    SpawnQuit();

                    OptionSet++;
                    //NextY -= (float)0.75;
                    break;
                }
            case 3:
                {
                    SpawnText("Yeah, I have a baseball bat. Let me see if I can do this.");
                    SpawnText("[ 10 minutes later ]");
                    SpawnText("Oh my god!");
                    SpawnText("I was able to take down a few of them. But it just drew more attention.");
                    SpawnText("One of them was able to get me in my side.");
                    SpawnText("It hurts so bad.");
                    SpawnText("Now it sounds like there are even more pounding on my door!");
                    SpawnText("If I wasn't so tired now, I would be so nervous.");
                    SpawnText("[ Signal Lost ]");

                    SpawnQuit();

                    OptionSet++;
                    //NextY -= (float)0.75;
                    break;
                }
        }
    }
}

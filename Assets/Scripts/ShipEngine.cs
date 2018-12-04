using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    public TextMesh main1, main2, main3, main4, main5, main6;
    public TextMesh month1, month2;
    public TextMesh pop1, pop2, pop3;
    public TextMesh job1, job2, job3, job4, job5, job6;

    float population, deaths;
    float crime, integrity, FoodStored, FoodMovement;
    int babies, children, working;
    float agr, civ, eng, med, mil, sci;

    int MonthsPassed, MonthsTogo;

    float MoraleMod;

    int[] babiesArr = new int[216];

	void Start ()
    {
        MoraleMod = Random.Range( 85, 95 );

        MonthsPassed = 0;
        MonthsTogo = Random.Range(360, 1200);

        //population = Random.Range( 950, 1050 );
        deaths = 0;
        crime = 0;
        integrity = 100;
        FoodStored = Random.Range(50, 200) * MonthsTogo / 100;
        //FoodMovement = 0;

        babies = 0;
        int x, c = 0;
        for (x = 0; x < babiesArr.Length; x++)
        {
            int r = Random.Range(0, 3);
            babiesArr[x] = r;
            c += r;
        }
        children = c;//Random.Range(50, 150);
        working = 0;

        agr = Random.Range(50, 150);
        civ = Random.Range(50, 150);
        eng = Random.Range(50, 150);
        med = Random.Range(50, 150);
        mil = Random.Range(50, 150);
        sci = Random.Range(50, 150);
	}

    public void NextMonth( )
    {
        // Increment 1 Month
        MonthsPassed++;
        MonthsTogo--;
        //MoraleMod++;

        // Make Babies ;)
        int x, lb = 0;
        //babies = (int)Mathf.Floor(Random.Range(0, (population / 24 * MoraleMod)));
        babies = Random.Range(0, (int)(population / 24 * (MoraleMod/500)));
        working = babiesArr[215];
        children += babies - working;

        for( x = 0; x < babiesArr.Length; x++ )
        {
            if (x == 0)
            {
                lb = babiesArr[x];
                babiesArr[x] = babies;
            }
            else
            {
                int bn = babiesArr[x];
                babiesArr[x] = lb;
                lb = bn;
            }
        }

        // TODO : Distribute workers accross fields
        civ += working;
        //MoraleMod += working;

        // Random Deaths
        int r;
        r = Random.Range(0, (int)MoraleMod);
        if (agr > r && r < 10) { Death(1); }
        /*
        r = Random.Range(0, (int)MoraleMod);
        if (civ > r && r < 10) { civ -= 1; deaths += 1; }
        r = Random.Range(0, (int)MoraleMod);
        if (eng > r && r < 10) { eng -= 1; deaths += 1; }
        r = Random.Range(0, (int)MoraleMod);
        if (med > r && r < 10) { med -= 1; deaths += 1; }
        r = Random.Range(0, (int)MoraleMod);
        if (mil > r && r < 10) { mil -= 1; deaths += 1; }
        r = Random.Range(0, (int)MoraleMod);
        if (sci > r && r < 10) { sci -= 1; deaths += 1; }
        */
        // TODO : Crime Based Events
        crime = Mathf.Floor(mil / (population + civ) * 100);
        if (float.IsNaN(crime))
            crime = 0;

        if (MoraleMod < 10)
        {
            crime += 25;
        }
        else if (MoraleMod < 50)
        {
            crime += 10;
        }
        else if (MoraleMod > 80)
        {
            crime -= 5;
        }
        else if (MoraleMod > 90)
        {
            crime -= 10;
        }


        // TODO : Integrity Based Events
        float IntChange = Mathf.Floor((sci + eng + eng) / (population) * MoraleMod ) - crime;
        if( float.IsNaN(IntChange) )
            IntChange = 0;
        
        //Debug.Log("IntRep: " + IntChange);

        if (IntChange > 0)
        {
            if (integrity < 100)
                integrity += IntChange;
            else if (integrity < 125)
                integrity += (IntChange / 2);
            else if (integrity < 175)
                integrity += (IntChange / 5);
            else if (integrity < 200)
                integrity += (IntChange / 10);
            else if (integrity < 250)
                integrity += (IntChange / 20);
            else if (integrity < 300)
                integrity += (IntChange / 40);
            else if (integrity < 400)
                integrity += (IntChange / 100);
            else if (integrity < 500)
                integrity += (IntChange / 1000);
        }
        else
            integrity += IntChange;

        integrity = Mathf.Round(integrity);

        if (integrity > 500)
            integrity = 500;
        else if (integrity < 1)
            integrity = 0;

        if (integrity < 5)
        {
            Death((int)(population*2));
            MoraleMod -= population;
        }
        else if (integrity < 15)
        {
            Death((int)(population/integrity));
            MoraleMod -= 3;
        }
        else if (integrity < 25)
        {
            Death((int)(population / integrity));
            MoraleMod -= 2;
        }
        else if (integrity < 50)
        {
            MoraleMod -= 1;
        }

        // Farm Based Events
        FoodStored += FoodMovement;
        if( FoodStored < 0 )
        {
            crime++;
            MoraleMod--;
            int death = Random.Range( Mathf.CeilToInt((float)(FoodStored * -1 * .75)), Mathf.CeilToInt(FoodStored * -1) );

            Death(death);

            MoraleMod -= death;
            FoodStored = 0;
        }

        if (FoodMovement < 0)
        {
            crime++;
            MoraleMod -= 1;
        }
        else if (FoodMovement > 0)
        {
            crime--;
            MoraleMod += 1;
        }


        if (crime < 0)
            crime = 0;
        else if (crime > 100)
            crime = 100;
        
        if (crime <= 0)
        {
            MoraleMod += 2;
        }
        else if (crime <= 20)
        {
            MoraleMod++;

            if (Random.Range(0, 2) == 1)
            {
                Death(1);
            }
        }
        else if (crime > 20)
        {
            MoraleMod--;

            r = Random.Range(0, (int)(crime / 5));
            Death(r);
            MoraleMod -= r;
        }

        // TODO : Military Based Events

        // TODO : Random Events

        // Set Morale Bounds
        if (MoraleMod < 0)
            MoraleMod = 0;
        else if(MoraleMod > 100)
            MoraleMod = 100;
    }

    void Death( int d )
    {
        int x, y;
        for (y = 0; y < d; y++)
        {
            if (civ > 0)
            {
                civ--;
                deaths++;
            }
            else if (sci > 0)
            {
                sci--;
                deaths++;
            }
            else if (mil > 0)
            {
                mil--;
                deaths++;
            }
            else if (eng > 0)
            {
                eng--;
                deaths++;
            }
            else if (med > 0)
            {
                med--;
                deaths++;
            }
            else if (agr > 0)
            {
                agr--;
                deaths++;
            }
            else
            {
                for (x = 0; x < babiesArr.Length; x++)
                {
                    if (babiesArr[x] > 0)
                    {
                        babiesArr[x]--;
                        children--;
                        deaths++;
                    }
                }
            }
        }
    }

    void Update ()
    {
        population = agr + civ + eng + med + mil + sci + children;
        FoodMovement = (agr * 8) - (population);

        main1.text = "Population: " + population;
        main2.text = "Death Toll: " + deaths;
        main3.text = "Crime: " + crime + "%";
        main4.text = "Food: " + FoodStored + " (" + FoodMovement + ")";
        main5.text = "Ship Integrity: " + integrity + "%";
        main6.text = "Morale: " + MoraleMod + "%";

        month1.text = "Months Passed: " + MonthsPassed;
        month2.text = "Months To Go: " + MonthsTogo;

        pop1.text = "Children Born: " + babies;
        pop2.text = "Children: " + children;
        pop3.text = "Enter Workforce: " + working;

        job1.text = "Agriculture: " + agr;
        job2.text = "Civilian: " + civ;
        job3.text = "Engineering: " + eng;
        job4.text = "Medical: " + med;
        job5.text = "Military: " + mil;
        job6.text = "Science: " + sci;
	}
}

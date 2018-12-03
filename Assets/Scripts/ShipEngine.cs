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
        MonthsPassed = 0;
        MonthsTogo = Random.Range(50, 100);

        //population = Random.Range( 950, 1050 );
        deaths = 0;
        crime = 0;
        integrity = 0;
        FoodStored = Random.Range(500, 1000) * MonthsTogo / 2;
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
        MonthsPassed++;
        MonthsTogo--;

        // TODO : Determine moral algo
        MoraleMod = .1F;

        babies = (int)Mathf.Floor(Random.Range(0, (population / 24 * MoraleMod)));
        working = babiesArr[215];
        children += babies - working;

        int x, lb = 0;
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

        crime = Mathf.Floor( (mil / population)+(mil / civ) * (-1*MoraleMod) * 10 );
        if (crime < 0)
            crime = 0;
        else if (crime > 100)
            crime = 100;

        float IntChange = Mathf.Floor((sci + eng) / (population) * MoraleMod * 100);
        integrity += IntChange;
        //Debug.Log(IntChange);

        FoodStored += FoodMovement;

        // TODO : Trade Based Events
        // TODO : Random Events
    }

    void Update ()
    {
        population = agr + civ + eng + med + mil + sci + children;
        FoodMovement = (agr * 200) - (population * 30);

        main1.text = "Population: " + population;
        main2.text = "Death Toll: " + deaths;
        main3.text = "Crime: " + crime + "%";
        main4.text = "Food: " + FoodStored + " (" + FoodMovement + ")";
        main5.text = "Ship Integrity: " + integrity;
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

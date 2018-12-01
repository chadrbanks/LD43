using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public enum ReleasePlatform
{
	mac, windows
}
public enum ReleaseStatus
{
	development, production
}

[DisallowMultipleComponent]
public class Singleton : MonoBehaviour
{
	public static Singleton data;

	// CHANGE THESE IN UNITY!
	public string version = "0.0"; // CHANGE IN UNITY
	public ReleaseStatus status;
	public ReleasePlatform platform;
	public FloatText gft;

    public List<int> prices = new List<int>();

    public PlayerData plyr;

    public int raid = 0, startfuel, startcredit;

    public AudioSource click, shipsound;

	void Awake()
	{
		if (data == null)
		{
			DontDestroyOnLoad(gameObject);
            data = this;
            Singleton.data.restartGame();
		}
		else if (data != this)
		{
			Destroy(gameObject);
		}
    }

    public int getCapacityUse()
    {
        return Singleton.data.plyr.goods[1] + Singleton.data.plyr.goods[2] + Singleton.data.plyr.goods[3] + Singleton.data.plyr.goods[4] + Singleton.data.plyr.goods[5];
    }

    public bool UseFuel()
    {
        if (Singleton.data.plyr.neofuel > 0)
        {
            Singleton.data.plyr.neofuel--;
            return true;
        }
        else if (Singleton.data.plyr.goods[3] > 0)
        {
            Singleton.data.plyr.goods[3]--;
            return true;
        }

        return false;
    }

    public int GetFuel()
    {
        return (Singleton.data.plyr.goods[3] + Singleton.data.plyr.neofuel);
    }

    public void restartGame()
    {
        Singleton.data.plyr = new PlayerData();

        Singleton.data.plyr.ship = 0;
        Singleton.data.plyr.aicore = 0;
        Singleton.data.plyr.aicomp = 0;
        Singleton.data.plyr.planet = 1;
        Singleton.data.plyr.neofuel = 0;
        Singleton.data.plyr.explored = 0;
        Singleton.data.plyr.credits = startcredit;

        Singleton.data.plyr.goods = new List<int>();
        Singleton.data.plyr.goods.Add(0);
        Singleton.data.plyr.goods.Add(0);
        Singleton.data.plyr.goods.Add(0);
        Singleton.data.plyr.goods.Add(startfuel);
        Singleton.data.plyr.goods.Add(0);
        Singleton.data.plyr.goods.Add(0);

        Singleton.data.prices = new List<int>();
        Singleton.data.prices.Add(0);
        Singleton.data.prices.Add(UnityEngine.Random.Range(1, 200));
        Singleton.data.prices.Add(UnityEngine.Random.Range(1, 200));
        Singleton.data.prices.Add(UnityEngine.Random.Range(1, 200));
        Singleton.data.prices.Add(UnityEngine.Random.Range(1, 200));
        Singleton.data.prices.Add(UnityEngine.Random.Range(1, 200));
    }

    public void SaveGame()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, Singleton.data.plyr);
        file.Close();
    }

    public void LoadGame()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.Log("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        PlayerData d = (PlayerData)bf.Deserialize(file);
        file.Close();

        Singleton.data.plyr = d;
    }

    void OnDestroy()
    {
        SaveGame();
    }
}


[Serializable]
public class PlayerData
{
    public string shipname;

    public int ship = 0;
    public int planet = 0;
    public float credits = 0;
    public List<int> goods = new List<int>();
    public int speed, hull, hullmax, capmax, weapons, aicore, aicomp, explored, neofuel;
}
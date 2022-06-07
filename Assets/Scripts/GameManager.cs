using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();


        instance = this;

        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    //Contains resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<Sprite> weaponPrices;
    public List<Sprite> xpTable;

    //References (player script, weapon script ...)
    public Player player;

    //Logic
    public int pesos;
    public int experience;


    //Handle state
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";  //здесь двойные кавычки
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');  //здесь одинарные кавычки
        
        //TODO: Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //TODO: Change weapon level

        Debug.Log("LoadState");

    }





}

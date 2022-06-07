using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    private void Awake()
    {
        instance = this; //equals to the first game manager that found on the scene. (If I create an instance of this in another script).
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

    }

    public void LoadState()
    {

    }





}

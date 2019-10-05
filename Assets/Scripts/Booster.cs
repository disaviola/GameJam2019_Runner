using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    private bool rail1;
    private bool rail2;
    private GameObject player;
    private PlayerMovement playerMovement;
   
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        rail1 = false;
        rail2 = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(rail1 == true && rail2 == true)
        {
            playerMovement.SetBoost(true);
        }
        else
        {
            playerMovement.SetBoost(false);

        }
    }

    public void setRail1(bool boolean)
    {
        rail1 = boolean;
    }

    public void setRail2(bool boolean)
    {
        rail2 = boolean;
    }
}

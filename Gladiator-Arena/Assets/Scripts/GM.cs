using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GM
{
    public static int Lives1 = 3;
    public static int Lives2 = 3;
    public static void RemoveLife()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");


        if (players[0].name == "Player")
        {
            Debug.Log("okok");
            Stats stats = players[0].GetComponentInChildren<Stats>();

            if(stats.currenthealth == 0 && Lives1 > 0)
            {
                Lives1--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (players[0].name == "Player2")
        {
            Stats stats = players[0].GetComponentInChildren<Stats>();

            if (stats.currenthealth == 0 && Lives2 > 0)
            {
                Lives2--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(players[1].name == "Player")
        {
            Debug.Log("okok1");
            Stats stats = players[1].GetComponentInChildren<Stats>();

            if (stats.currenthealth == 0 && Lives1 > 0)
            {
                Lives1--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (players[1].name == "Player2")
        {

            Stats stats = players[1].GetComponentInChildren<Stats>();


            if (stats.currenthealth == 0 && Lives2 > 0)
            {
                Lives2--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (Lives1 == 0)
        {
            Lives1 = 3;
            Lives2 = 3;
            SceneManager.LoadScene("Player2Wins");
        }
        else if(Lives2 == 0)
        {
            Lives1 = 3;
            Lives2 = 3;
            SceneManager.LoadScene("Player1Wins");
        }
    }
}

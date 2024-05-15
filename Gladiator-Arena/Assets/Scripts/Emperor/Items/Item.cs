using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;

    public int type;

    private Player player;

    private int playerWeapon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();

            changeWeapon();
        }
    }

    private int changeWeapon()
    {
        playerWeapon = player.weaponID;
        player.setWeapon(id);

        return playerWeapon;
    }
}

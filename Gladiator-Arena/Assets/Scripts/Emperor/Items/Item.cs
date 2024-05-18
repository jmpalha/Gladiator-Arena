using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] float despawnTime;
    public int id;

    public BoxCollider2D collider;
    private Rigidbody2D itemRb;
    public int type;

    private Player player;

    private int playerWeapon;

    void Start(){
        collider = GetComponent<BoxCollider2D>();
        itemRb = GetComponent<Rigidbody2D>();

    }

    private void Awake() {


        // player = GameManager.instance.player.transform;

    }

    private void Update(){
        // despawnTime -= Time.deltaTime;

        // if(despawnTime < 0 ){
        //     Destroy(gameObject);
        // }
        if(transform.position.y < 2 ){
            collider.isTrigger = true;
            Destroy(itemRb);
            // Destroy(gameObject);
        }

        // float distance = Vector3.Distance(transform.position.y,player);

        // if(distance > pickUpDistance){
        //     return;
        // }
        // transform.position = Vector3.MoveTowards(transform.position, player.position);

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();

            changeWeapon();
            Destroy(gameObject);
        }
    }

    private int changeWeapon()
    {
        playerWeapon = player.weaponID;
        player.setWeapon(id);

        return playerWeapon;
    }
}

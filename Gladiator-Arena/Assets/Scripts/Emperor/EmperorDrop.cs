using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmperorDrop : MonoBehaviour
{
    [SerializeField] float spawnTime;

    public GameObject[] emperorItems;
    private float saveSpawnTime;
    public int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        saveSpawnTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(i < emperorItems.Length){
            spawnTime -= Time.deltaTime;

            if(spawnTime < 0 ){
                emperorItemDrop();
                spawnTime = saveSpawnTime;
            }
        }
    }

    private void emperorItemDrop()
    {
        if (i < emperorItems.Length){
            int randomNumber;
            randomNumber = Random.Range(-25, 25);
            Instantiate(emperorItems[i], transform.position + new Vector3(randomNumber, 0, 0), Quaternion.identity);
            i++;
        }

        

    }


}

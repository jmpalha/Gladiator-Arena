using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmperorDrop : MonoBehaviour
{
    [SerializeField] float spawnTime;

    public GameObject[] emperorItems;
    private float saveSpawnTime;
    private float thumbsTime;
    private bool thumbsActive;

    public int i = 0;
    public GameObject thumbs;



    // Start is called before the first frame update
    void Start()
    {
        saveSpawnTime = spawnTime;
        thumbsTime = spawnTime/2;
        thumbsActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;

        if(spawnTime < 0 ){
            thumbs.SetActive(true);
            thumbsActive = true;
            int randomNumber = Random.Range(0,emperorItems.Length);
            emperorItemDrop(randomNumber);
            spawnTime = saveSpawnTime;
        }

        if(thumbsActive){
            thumbsTime -= Time.deltaTime;
            if(thumbsTime < 0 ){
                thumbs.SetActive(false);
                thumbsActive = false;
                thumbsTime = saveSpawnTime/2;
            }
        }
        
    }

    private void emperorItemDrop(int i)
    {
        int randomNumber;
        randomNumber = Random.Range(-25, 25);
        Instantiate(emperorItems[i], transform.position + new Vector3(randomNumber, 0, 0), Quaternion.identity);   

    }


}

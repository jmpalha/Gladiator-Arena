using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmperorDrop : MonoBehaviour
{
    public GameObject[] emperorItems;

    // Start is called before the first frame update
    void Start()
    {
        emperorItemDrop(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void emperorItemDrop()
    {
        int randomNumber;
        for(int i = 0; i < emperorItems.Length; i++){
            randomNumber = Random.Range(-25, 25);
            Instantiate(emperorItems[i], transform.position + new Vector3(randomNumber, 0, 0), Quaternion.identity);
        }   

    }


}

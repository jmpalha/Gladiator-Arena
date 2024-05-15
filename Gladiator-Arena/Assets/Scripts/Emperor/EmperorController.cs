using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmperorController : MonoBehaviour
{
    public List<Item> items;


    private void Awake()
    {
        foreach (Item item in items)
        {
            Instantiate(item);
        }
    }
}

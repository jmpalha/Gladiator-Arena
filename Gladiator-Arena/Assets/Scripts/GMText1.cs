using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMText1 : MonoBehaviour
{
    Text text2;

    private void Awake()
    {
        text2 = GetComponent<Text>();
    }

    private void Start()
    {
        text2.text = ((int)GM.Lives2).ToString();
    }
}

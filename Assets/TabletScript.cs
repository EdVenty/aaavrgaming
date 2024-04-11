using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] screens;
    [SerializeField]
    public int length;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchTo(int screenIndex)
    {
        for(int i = 0; i < length; i++)
        {
            if (i == screenIndex)
            {
                screens[i].SetActive(true);
            }
            else
            {
                screens[i].SetActive(false);
            }
        }
    }

    void SwitchToMain()
    {
        SwitchTo(0);
    }

    void SwitchToMiniGame()
    {
        SwitchTo(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strelar : MonoBehaviour
{
    public Strela script1;
    public float er = 0;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube (4)")
        {
            if (script1 != null) { 
                er = script1.speed2;
                script1.speed2 = 0;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube (4)")
        {
            if (script1 != null)
            {
                script1.speed2 = er;
            }
        }

    }
}

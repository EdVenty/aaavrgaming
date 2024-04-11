using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyb6 : MonoBehaviour
{
    public Cyb5 cyb5;
    private float time;
    private float o = 2;
    private GameObject platforma;
    Material material1;
    private float r = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; 
        if (time > o + 0.7)
        {
            Material material = this.GetComponent<Renderer>().material;
            material1 = platforma.GetComponent<Renderer>().material;
            var color = Random.Range(0, cyb5.cyb4.cyb3.cyb2.cube1.colors.Count);
            material.color = cyb5.cyb4.cyb3.cyb2.cube1.colors[color];
            cyb5.cyb4.cyb3.cyb2.cube1.colors.RemoveAt(color);
            o += 120;
            r = 0;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        platforma = other.gameObject;
    }
}

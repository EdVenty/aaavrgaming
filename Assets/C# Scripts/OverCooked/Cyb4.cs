using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyb4 : MonoBehaviour
{
    public Cyb3 cyb3;
    private float time;
    private float o = 2;
    private GameObject platforma;
    Material material1;
    private float r = 0;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > o + 0.4)
        {
            Material material = this.GetComponent<Renderer>().material;
            material1 = platforma.GetComponent<Renderer>().material;
            var color = Random.Range(0, cyb3.cyb2.cube1.colors.Count);
            material.color = cyb3.cyb2.cube1.colors[color];
            cyb3.cyb2.cube1.colors.RemoveAt(color);
            o += 120;
            r = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        platforma = other.gameObject;
    }
}

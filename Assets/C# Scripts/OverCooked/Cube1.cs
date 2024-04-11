using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube1 : MonoBehaviour
{
    public List<Color> colors;
    private float time;
    private float o = 2;
    public GameObject platforma;
    Material material1;
    private float r = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > o+ 0.1)
        {
            Material material = this.GetComponent<Renderer>().material;
            material1 = platforma.GetComponent<Renderer>().material;
            var color = Random.Range(0, colors.Count);
            material.color = colors[color];
            colors.RemoveAt(color);
            o += 120;
            r = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        platforma = other.gameObject;
    }
}

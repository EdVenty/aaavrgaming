using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Cube1 colorer;
    private float time;
    private float o = 2;
    public GameObject platforma;
    Material material1;
    public StartPlay startplay;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Material material = this.GetComponent<Renderer>().material;
        var color = Random.Range(0,3);
        if(color == 0 && time > o)
        {
            material = this.GetComponent<Renderer>().material;
            if (platforma != null)
            {
                material1 = platforma.GetComponent<Renderer>().material;
                if ((Vector4)material.color == (Vector4)material1.color && o > 2)
                {
                    Debug.Log("1: ++");
                    startplay.money += 1;
                }
            }
            material.color =  new Color(35, 27, 122, 255);
            colorer.colors.Add(new Color(35, 27, 122, 255));
            if(colorer.colors.Count > 6)
            {
                colorer.colors.Clear();
                colorer.colors.Add(new Color(35, 27, 122, 255));
            }
            o = o + 120;
        }
        else if(color == 1 && time > o)
        {
            material = this.GetComponent<Renderer>().material;
            if (platforma != null)
            {
                material1 = platforma.GetComponent<Renderer>().material;
                if ((Vector4)material.color == (Vector4)material1.color && o > 2)
                {
                    Debug.Log("1: ++");
                    startplay.money += 1;
                }
            }
            material.color = new Color(45, 122, 45, 255);
            colorer.colors.Add(new Color(45, 122, 45, 255));
            if (colorer.colors.Count > 6)
            {
                colorer.colors.Clear();
                colorer.colors.Add(new Color(45, 122, 45, 255));
            }
            o = o + 120;
        }
        else if(color == 2 && time > o )
        {
            material = this.GetComponent<Renderer>().material;
            if (platforma != null)
            {
                material1 = platforma.GetComponent<Renderer>().material;
                if ((Vector4)material.color == (Vector4)material1.color && o > 2)
                {
                    Debug.Log("1: ++");
                    startplay.money += 1;
                }
            }
            material.color = new Color(122, 9, 20, 255);
            colorer.colors.Add(new Color(255, 0, 0, 255));
            if (colorer.colors.Count > 6)
            {
                colorer.colors.Clear();
                colorer.colors.Add(new Color(122, 9, 20, 255));
            }
            o = o + 120;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        platforma = other.gameObject;
    }
}

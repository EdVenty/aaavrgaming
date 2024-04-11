using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public Vector3 beginposition;
    public Quaternion beginrotation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ixample());
    }

    IEnumerator Ixample()
    {
        beginposition = Vector3.zero;
        beginrotation = Quaternion.identity;
        yield return new WaitForSeconds(3);
        beginposition = this.transform.position;
        beginrotation = this.transform.rotation;
    }
    IEnumerator Example()
    {
        this.transform.position = this.transform.position;
        this.transform.rotation = this.transform.rotation;
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
        this.transform.position = beginposition;
        this.transform.rotation = beginrotation;
    }
    // Update is called once per frame
    void Update()
    {
        if(Mathf.Sqrt(Mathf.Pow(this.transform.position.x - beginposition.x, 2) + Mathf.Pow(this.transform.position.y - beginposition.y, 2) + Mathf.Pow(this.transform.position.z - beginposition.z, 2)) > 0.5)
        {
            StartCoroutine(Example());
        }
    }
}

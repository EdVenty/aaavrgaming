using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidReturn : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        
    }
}

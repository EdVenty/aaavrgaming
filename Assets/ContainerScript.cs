using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerScript : MonoBehaviour
{
    [SerializeField] public UnityEvent OnBumped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision info)
    {
        Debug.Log(info.gameObject.name);
        if (info.relativeVelocity.magnitude > 2.0f)
        {
            OnBumped.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] public GameObject Container;
    [SerializeField] public UnityEvent OnTriggered;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Container)
        {
            OnTriggered.Invoke();
        }
    }
}

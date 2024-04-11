using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Strela : MonoBehaviour
{
    public GameObject zachita;
    public GameObject strela;
    public GameObject kran;
    public GameObject magnit;

    [SerializeField] GameObject joystickBase;

    private JoystickScript joystickScript;

    public float speed = 0;

    private float er = 1;
    public float speed2 = 0.0000001f;
    void Start()
    {
        joystickScript = joystickBase.GetComponent<JoystickScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (joystickScript.normAngles.x > 20)
        {
            strela.transform.Translate(0, speed * Time.fixedDeltaTime * 0.5f, 0, Space.Self);
        }

        if (joystickScript.normAngles.x < -20)
        {
            strela.transform.Translate(0, -speed2 * Time.fixedDeltaTime * 0.5f, 0, Space.Self);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Cube (4)")
        {
            er = speed;
            speed = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Cube (4)")
        {
            speed = er;
        }
        
    }

}

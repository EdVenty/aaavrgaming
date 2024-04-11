using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] 
    public float speed = 0;

    public GameObject magnit;

    [SerializeField]
    public GameObject joystick;
    private JoystickScript joystickScript;
    private bool isRotating = false;
    private AudioSource audioSource;

    void Start()
    {
        joystickScript = joystick.GetComponent<JoystickScript>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool rotated = false;
        if (joystickScript.normAngles.y > 20) {
            transform.rotation *= Quaternion.Euler(0f, 50f * Time.deltaTime * 0.2f, 0f);
            rotated = true;
        }
        if (joystickScript.normAngles.y < -20)
        {
            transform.rotation *= Quaternion.Euler(0f, -50f * Time.deltaTime * 0.2f, 0f);
            rotated = true;
        }
        if(!isRotating)
        {
            if(rotated)
            {
                isRotating = true;
                audioSource.Play();
            }
        }
        else if (!rotated)
        {
            isRotating = false;
            audioSource.Stop();
        }
    }
}

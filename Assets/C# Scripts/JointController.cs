using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JointController : MonoBehaviour 
{
    JointMotor motor;
    private AudioSource m_AudioSource;
    private bool isMoving;

    [SerializeField] KeyCode keyDir1;
    [SerializeField] KeyCode keyDir2;

    [Header("JointMotor")]
    [SerializeField] HingeJoint joint;
    [SerializeField] Rigidbody rb;
    [SerializeField] RigidbodyConstraints freezeOnStopAxis;
    [SerializeField] float velocity;
    [SerializeField] float force;
    [SerializeField] GameObject joystickBase;

    private JoystickScript joystickScript;

    void Start()
    {
        joystickScript = joystickBase.GetComponent<JoystickScript>();
        m_AudioSource = GetComponent<AudioSource>();

        motor = new JointMotor();
        motor.force = force;
        MoveJoint(0);
    }

    void FixedUpdate()
    {
        bool moved = false;
        if (joystickScript.normAngles.x > 20)
        {
            MoveJoint(1);
            moved = true;
        }
        else if (joystickScript.normAngles.x < -20)
        {
            MoveJoint(-1);
            moved = true;
        }
        else
        {
            MoveJoint(0);
        }

        if (!isMoving)
        {
            if (moved)
            {
                isMoving = true;
                m_AudioSource.Play();
            }
        }
        else if (!moved)
        {
            isMoving = false;
            m_AudioSource.Stop();
        }
    }
    public void MoveJoint(float direction)
    {
        if (direction == 0f)
        {
            rb.constraints = freezeOnStopAxis;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        motor.targetVelocity = direction * velocity;
        joint.motor = motor;
    }
}

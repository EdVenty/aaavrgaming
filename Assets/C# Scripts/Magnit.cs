using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Magnit : MonoBehaviour
{
    public float speed = 0.5f;
    public float speed2 = 0.5f;
    SoftJointLimit rope;
    public float maxlimit;
    public float limitspeed;
    public ConfigurableJoint Joint;
    private float er = 0;
    public GameObject magnit;
    private GameObject contayner;
    private float currentSpeed = 0;
    private float ty = 0;
    public Rigidbody rb;
    public Rigidbody rB;
    public KeyCode keyUp;
    public KeyCode keyDown;
    private int qw = 0;
    private bool hvatted = false;
    private float timeButtonPressed;

    [SerializeField] GameObject joystickBase;
    [SerializeField] public float activeDelay;
    [SerializeField] public UnityEvent onHvat;
    [SerializeField] public UnityEvent onUnhvat;
    [SerializeField] public UnityEvent onMovingEnter;
    [SerializeField] public UnityEvent onMovingExit;

    public bool isReturnable = false;

    private JoystickScript joystickScript;
    private AudioSource magnetAudioSource;
    private bool isMoving;

    public KidReturn kidreturn;
    public GameObject kid;
    void Start()
    {
        joystickScript = joystickBase.GetComponent<JoystickScript>();

        rope = new SoftJointLimit();
        magnetAudioSource = GetComponent<AudioSource>();

        SetLimit(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool moved = false;
        if (joystickScript.normAngles.x > 20)
        {
            SetLimit(1);
            moved = true;
        }
        else if (joystickScript.normAngles.x < -20)
        {
            SetLimit(-1);
            moved = true;
        }
        else
        {
            SetLimit(0);
            moved = false;
        }
        if (!isMoving)
        {
            if (moved)
            {
                isMoving = true;
                onMovingEnter.Invoke();
            }
        }
        else if (!moved)
        {
            isMoving = false;
            onMovingExit.Invoke();
        }
        /*if (Input.GetKey(KeyCode.LeftShift) && speed2 == 0)
        {
            Debug.Log("1");
            if(qw == 0)
            {
                var joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = contayner.GetComponent<Rigidbody>();
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            qw = 0;
            Debug.Log(speed2);
            Release();
        }*/
        var movement = rope.limit + Time.deltaTime * currentSpeed;
        if(currentSpeed != 0 && movement < maxlimit && movement > 0)
        {
            rope.limit += Time.deltaTime * currentSpeed;
            Joint.linearLimit = rope;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Container")
        {
            magnetAudioSource.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Container")
        {
            er = speed2;
            speed2 = 0;
        }
        contayner = other.gameObject;
        ty = 1;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Container")
        {
            speed2 = er;
        }
        ty = 0;

    }

    IEnumerator Example()
    {
        Physics.gravity = new Vector3(0, -3.8f, 0);
        yield return new WaitForSeconds(3);
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    IEnumerator Axample()
    {
        kid.transform.position = kid.transform.position;
        kid.transform.rotation = kid.transform.rotation;
        yield return new WaitForSeconds(10);
        kid.transform.position = kidreturn.beginposition;
        kid.transform.rotation = kidreturn.beginrotation;
    }

    void Release()
    {
        if(contayner == null)
        {
            return;
        }

        Destroy(GetComponent<FixedJoint>());

        if (isReturnable)
        {
            StartCoroutine(Example());
            StartCoroutine(Axample());
        }
    }

    public void SetParent(GameObject newParent)
    {
        contayner.transform.parent = newParent.transform;
    }

    public void SetLimit(float direction)
    {
        currentSpeed = direction * limitspeed;
    }

    public void hvathandler()
    {
        if(Time.realtimeSinceStartup < timeButtonPressed + activeDelay)
        {
            return;
        }
        if (!hvatted)
        {
            hvat();
        }
        else
        {
            hvatted = false;
            othat();
        }
    }

    public void hvat()
    {
        if (ty == 1)
        {

            qw = 0;
            if (qw == 0)
            {
                var joint = gameObject.AddComponent<FixedJoint>();
                joint.connectedBody = contayner.GetComponent<Rigidbody>();
                hvatted = true;
                timeButtonPressed = Time.realtimeSinceStartup;
                onHvat.Invoke();
            }
        }
    }
    public  void othat()
    {
        qw = 1;
        Release();
        onUnhvat.Invoke();
    }

    public void SetReturnable()
    {
        isReturnable = true;
    }

    public void SetUnreturnable()
    {
        isReturnable = false;
    }
}

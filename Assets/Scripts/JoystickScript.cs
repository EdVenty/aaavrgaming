using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class JoystickScript : MonoBehaviour
{
    [SerializeField]
    private GameObject stick;

    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private UnityEvent OnHandAttached;

    public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

    private Vector3 oldPosition;
    private Quaternion oldRotation;

    protected Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

    private Interactable interactable;

    public Vector3 angles;
    public Vector3 normAngles;

    // Start is called before the first frame update
    void Awake()
    {
        interactable = this.GetComponent<Interactable>();
    }

    private void HandAttachedUpdate(Hand hand)
    {
        /*var vec = hand.transform.position - oldPosition;
        vec = new Vector3(vec.x, vec.y, Mathf.Abs(vec.z));
        vec = vec.normalized;

        angles = new Vector3(Mathf.Acos(vec.x) * Mathf.Rad2Deg - oldRotation.x, 0, Mathf.Asin(vec.z) * Mathf.Rad2Deg);*/
        
       // Debug.Log(angles);

        stick.transform.LookAt(new Vector3(hand.transform.position.x, Mathf.Clamp(hand.transform.position.y, oldPosition.y, 1000000000f), hand.transform.position.z));

        angles = stick.transform.localRotation.eulerAngles;
        normAngles = new Vector3(angles.x > 180 ? angles.x - 360 : angles.x, angles.y > 180 ? angles.y - 360 : angles.y, angles.z > 180 ? angles.z - 360 : angles.z);

        if(jumpAction != null)
        {
            if (jumpAction[hand.handType].state)
            {
                Debug.Log("SUS");
            }
        }

        //stick.transform.rotation = Quaternion.Euler(newAngles.x, 0, newAngles.z);
    }

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Save our position/rotation so that we can restore it when we detach
            oldPosition = stick.transform.position;
            oldRotation = stick.transform.localRotation;

            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);

            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
            OnHandAttached.Invoke();
            Debug.Log("Attached");
            
        }
        else if (isGrabEnding)
        {
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);

            // Restore position/rotation
            //stick.transform.position = oldPosition;
            stick.transform.localRotation = oldRotation;
            angles = Vector3.zero;
            normAngles = Vector3.zero;


            Debug.Log("Ended");
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public static float speed = 0.1f;

    public GameObject Flyer;

    float normalSpeed = 3.0f;
    float goFast = 10.0f;

    public GameObject CenterEyeAnchor;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch));
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f)
        {
            Flyer.transform.Translate(primaryAxis.y * transform.forward * goFast * Time.deltaTime);
        }
        else
        {
            Flyer.transform.Translate(primaryAxis.y * transform.forward * normalSpeed * Time.deltaTime);
        }
        
        Flyer.transform.Translate(secondaryAxis.x * transform.right * normalSpeed * Time.deltaTime);
        Flyer.transform.Translate(secondaryAxis.y * transform.up * normalSpeed * Time.deltaTime);

    }
}

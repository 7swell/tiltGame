using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMovement : MonoBehaviour
{
    Vector3 dir;
    Rigidbody rb;
    public int speed = 5;
    public bool debug = true;
    public Transform arrowIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.z = Input.acceleration.y;

        if(debug)
        {
            Debug.DrawRay(this.transform.position, dir * 5, Color.red, 0.5f);
        }
        
    }
    void FixedUpdate()
    {
        rb.AddForce(dir * speed);
       
    }
    void LateUpdate()
    {
        arrowIndicator.rotation = Quaternion.LookRotation(dir, Vector3.up);
        Vector3 scale = Vector3.one;
        scale.z = dir.magnitude;
        arrowIndicator.localScale = scale;

    }
}

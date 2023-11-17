using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowUserControl : MonoBehaviour
{
    public float speed = 4.0f;
    private Animator ani;
    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float high = Input.GetAxis("Vertical") * speed;
        rig.AddForce(Vector3.up * (high + 7), ForceMode.Force);
        float right = Input.GetAxis("Horizontal") * speed;
        rig.AddForce(Vector3.right * right, ForceMode.Force);

        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetTrigger("fly_attack1_trigger");
        }
    }
}

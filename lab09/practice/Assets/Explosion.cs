using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        // if the collision object is a small sphere falling from above, explode it
        if (col.transform.name == "Sphere")
        {
            // define explosion radius
            float radius = 3.0f;
            // define explosion position is bomb's position
            Vector3 explosionPos = transform.position;
            // get all colliders within the radius of sphere(including the radius)
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            // traverse colliders, if it's a rigidbody, add force
            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(600, explosionPos, radius);
                }
                // destroy bomb and small sphere
/*                Destroy(col.gameObject);
                Destroy(gameObject);*/
            }
        }
    }
}
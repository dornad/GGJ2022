using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject explode;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(explode, transform.position, transform.rotation);
            // destroy the projectile
            Destroy(collision.gameObject);

            // destroy self
            Destroy(gameObject);
        }
    }

}

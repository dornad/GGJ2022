using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTut : MonoBehaviour {

    public GameObject impactVFX;

    private bool collided;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);

            Destroy(gameObject);

        }
    }
}

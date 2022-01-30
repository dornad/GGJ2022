
using UnityEngine;

namespace Assets.Scripts
{

public sealed class ProjectileTut : MonoBehaviour, IAbility 
    {
    // --- Properties:

    public Abilities Type { get { return(Abilities.Fire); } }

    public GameObject impactVFX;

    private bool collided;

    // --- External Behaviours:

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

}

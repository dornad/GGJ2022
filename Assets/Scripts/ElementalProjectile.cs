
using UnityEngine;

namespace Assets.Scripts
{

public sealed class ElementalProjectile : MonoBehaviour, IAbility 
    {
    // --- Properties:

    private static Abilities chosenAbility = Abilities.Undefined;

    public Abilities Type { get { return(chosenAbility); } }

    public GameObject impactVFX;

    private bool collided;

    // --- External Behaviours:

    public static void ChooseElement(Abilities abilityType)
        {

        chosenAbility = abilityType;
        }

    public void OnCollisionEnter(Collision collision)
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

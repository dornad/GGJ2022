using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class Reactor_IcePortal : MonoBehaviour
    {
    // --- Properties:

    private readonly Abilities portalAbility = Abilities.Ice;

    // --- External Behaviours:

    public void OnTriggerEnter(Collider colliderParameters)
        {
        // if collides with player, set player ability to fire

        ElementalProjectile.ChooseElement(portalAbility);   // on any collision
        }


    }


}

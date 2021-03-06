using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class Reactor_FirePortal : MonoBehaviour
    {
    // --- Properties:

    private readonly Abilities portalAbility = Abilities.Fire;

    // --- External Behaviours:

    public void OnTriggerEnter(Collider colliderParameters)
        {
        // if collides with player, set player ability to fire
        
        ElementalProjectile.ChooseElement(portalAbility);   // on any collision
        }


    }


}

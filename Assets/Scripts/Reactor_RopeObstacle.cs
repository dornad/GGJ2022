using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class Reactor_RopeObstacle : MonoBehaviour, ITarget
    {
    // --- Properties:

    public Targets Type { get { return(Targets.Rope); } }

    // --- External Behaviours:

    public void OnCollisionEnter(Collision collisionParameters)
        {
        IAbility abilityComponent = collisionParameters.gameObject.GetComponent<IAbility>();

        MasterController.Commands.ApplyAbility(abilityComponent,this);
        }


    }


}

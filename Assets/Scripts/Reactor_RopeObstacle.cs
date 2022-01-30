using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class Reactor_RopeObstacle : MonoBehaviour, ITarget
    {
    // --- Properties:

    public Targets Type { get { return(Targets.Rope); } }

    public bool Solved { get; private set; }

    // --- Initialization:

    public void Awake()
        {

        Solved = false;
        }

    // --- External Behaviours:

    public void OnCollisionEnter(Collision collisionParameters)
        {
        if (!Solved)
           {
           IAbility abilityComponent = collisionParameters.gameObject.GetComponent<IAbility>();

           Solved = MasterController.Commands.ApplyAbility(abilityComponent,this);
           }
        }


    }


}

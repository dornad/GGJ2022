using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{

public sealed class InitialScene_Controller : MonoBehaviour
    {

    public void Start()
        {
        // point of entry for game-state code

        MasterController.Commands.ChangeScene(Scenes.Menu);
        }

    }

}


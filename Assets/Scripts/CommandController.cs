using System;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

public sealed class CommandController : MonoBehaviour
    {
    // Start is called before the first frame update
    void Start()
        {
        
        }


    // --- External Behaviours:

    public void ChangeScene(Scenes targetScene)
        {

        loadScene(targetScene);
        }

    public void TriggerEffect(Abilities ability, Targets target)
        {

        // TODO
        }


    // --- Internal Procedures:

    public void loadScene(Scenes targetScene)
        {

        SceneManager.LoadScene((int)targetScene);
        }


    }

}


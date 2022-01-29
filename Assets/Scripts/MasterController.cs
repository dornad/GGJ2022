using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class MasterController : MonoBehaviour
    {
    // --- Inner Definitions:

    /// <summary>
    /// Enumeration of lifecycle states.
    /// </summary>
    private enum InitState : byte
        {
        locked,
        empty,
        ready
        }

    // --- Fields:

    private static MasterController instance = null;
    private static InitState state = InitState.empty;

    private CommandController commandController; 

    // --- Properties:
    
    /// <summary>
    /// Controller of gameplay states.
    /// </summary>
    public static CommandController Commands { get { return(instance.commandController); } }

    // --- Lifecycle:

    /// <summary>
    /// Internal state constructor - after awakening stage.
    /// </summary>
    private void initialize()
        {
        // setup singleton & enable access flag

        instance = this;

        state = InitState.ready;  

        // setup persistent hierarchy

        DontDestroyOnLoad(gameObject);

        // setup manager instances

        commandController = gameObject.AddComponent<CommandController>();
        }
    
    /// <summary>
    /// Ensures singleton initialization.
    /// </summary>
    public void Awake()                                                       
        {
        switch(state)
            {
            case InitState.empty: initialize(); break;

            case InitState.ready: if (instance != this) { Destroy(gameObject); } break;
            }
        }

    /// <summary>
    /// Ensures singleton lifecycle.
    /// </summary>
    public void OnDestroy()                                                        
        {

        state = InitState.locked;
        }

    }


}

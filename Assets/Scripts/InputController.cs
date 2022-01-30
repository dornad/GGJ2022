using System;

using UnityEngine;

namespace Assets.Scripts
{

public sealed class InputController : MonoBehaviour
    {
    // --- Properties:

    

    // --- Initialization:

    void Awake()
        {
        
        }

    // --- Polling:

    public void Update()
        {
        switch (MasterController.Commands.CurrentScene)
            {
            case(Scenes.Menu): menuReactions(); break;
            case(Scenes.Level): levelReactions(); break;
            
            default: break;
            }
        }

    // --- Internal Procedures:

    #region Polling Contexts

    private void menuReactions()
        {

        if (Input.GetKeyDown(KeyCode.Escape)) { escapeOnMenu(); }

        }

    private void levelReactions()
        {

        if (Input.GetKeyDown(KeyCode.Escape)) { escapeOnLevel(); }

        }

    #endregion

    #region Menu Reactions

    private void escapeOnMenu()
        {

        MasterController.Commands.CloseApplication();
        }

    #endregion

    #region Level Reactions

    private void escapeOnLevel()
        {

        MasterController.Commands.ChangeScene(Scenes.Menu);
        }

    #endregion

    }

}


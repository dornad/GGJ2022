using UnityEngine;

namespace Assets.Scripts
{

public sealed class MenuScene_Controller : MonoBehaviour
    {

    


    public void Click_StartButton()
        {

        MasterController.Commands.ChangeScene(Scenes.Level);
        }

    public void Click_QuitButton()
        {

        MasterController.Commands.CloseApplication();
        }

    }

}


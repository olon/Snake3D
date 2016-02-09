using UnityEngine;
using System.Collections;

public class PanelMenu : AnimationMenu
{

    public void StartGameButton()
    {
        Application.LoadLevel("StartGame");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}

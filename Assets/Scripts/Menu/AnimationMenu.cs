using UnityEngine;
using System.Collections;

public class AnimationMenu : MonoBehaviour {

    public void Hide()
    {
        GetComponent<Animator>().SetTrigger("MenuHide");
    }

    public void Show()
    {
        GetComponent<Animator>().SetTrigger("MenuShow");
    }
}

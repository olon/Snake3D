using UnityEngine;
using System.Collections;

public class ChooseControlOptions : MonoBehaviour {

    public GameObject[] Panel;

    public void TwoButton()
    {
        Panel[0].SetActive(true);
        Panel[1].SetActive(false);
        Panel[2].SetActive(false);
    }

    public void Swap()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(true);
        Panel[2].SetActive(false);
    }

    public void Relative()
    {
        Panel[0].SetActive(false);
        Panel[1].SetActive(false);
        Panel[2].SetActive(true);
    }
}

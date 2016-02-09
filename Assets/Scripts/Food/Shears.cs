using UnityEngine;
using System.Collections;

public class Shears : TextLeftTimeToDestroyObject
{

    private int _cutCount = 10;

	void Start () {
        CreatAndDestroyText(gameObject);
        Destroy(gameObject, Game.Instance._currentTimeForDestroy);
        StartCoroutine(CutDownForSecond());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            TextDestroy();
            var Player = FindObjectOfType<Player>();
            if (Player)
                Player.DeleteFourCubeAfterEatShears(_cutCount);
        }
    }

    public IEnumerator CutDownForSecond()
    {
        for (int i = Game.Instance._currentTimeForDestroy; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            _cutCount = i/4;
        }
    }

}

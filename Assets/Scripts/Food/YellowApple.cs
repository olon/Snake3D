using UnityEngine;
using System.Collections;

public class YellowApple : TextLeftTimeToDestroyObject {

    public int points;

    void Start () {
        CreatAndDestroyText(gameObject);
        points = 100;
        Destroy(gameObject, Game.Instance._currentTimeForDestroy);
        StartCoroutine(PointDown());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            TextDestroy();
            Game.points += points;
        }
    }

    public IEnumerator PointDown()
    {
        for (int i = 0; i < Game.Instance._currentTimeForDestroy; i++)
        {
            yield return new WaitForSeconds(1);
            points -= 5;
        }
    }
}

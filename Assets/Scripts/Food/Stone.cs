using UnityEngine;
using System.Collections;

public class Stone : TextLeftTimeToDestroyObject
{
	void Start () {
        CreatAndDestroyText(gameObject);
        Destroy(gameObject, Game.Instance._currentTimeForDestroy);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            TextDestroy();
            Game.Instance._currentSpeed *= 0.85f;
        }
    }
}

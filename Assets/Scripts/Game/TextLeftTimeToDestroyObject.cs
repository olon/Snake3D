using UnityEngine;
using System.Collections;

public class TextLeftTimeToDestroyObject : MonoBehaviour {

    private GameObject LeftTimeToDestroy;

    public void CreatAndDestroyText(GameObject food)
    {
        LeftTimeToDestroy = (GameObject)Instantiate(Resources.Load("Prefabs/TextLeftTimeToDestroyObject"),
        new Vector3(food.transform.position.x - 0.65f, food.transform.position.y + 1.5f, food.transform.position.z + 0.75f),
        Quaternion.Euler(90, 0, 0));
        Destroy(LeftTimeToDestroy, Game.Instance._currentTimeForDestroy);
        StartCoroutine(CoLeftTime());
    }

    public void TextDestroy()
    {
        Destroy(LeftTimeToDestroy);
    }

    private IEnumerator CoLeftTime()
    {
        for (int i = Game.Instance._currentTimeForDestroy; i > 0; i--)
        {
            if (i < 4)
                LeftTimeToDestroy.GetComponent<MeshRenderer>().material.color = Color.red;

            LeftTimeToDestroy.GetComponent<TextMesh>().text = "" + i;
            yield return new WaitForSeconds(1);
        }
    }

}

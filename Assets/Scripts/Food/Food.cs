using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    public void GenerateNewFood(string foodItem)
    {
        var Player = FindObjectOfType<Player>();

        int randomHelp = Random.Range(0, 100);
        int r = Random.Range(0, 7);
        if (randomHelp < 60 && r < 3)
        {
            StartCoroutine(CoGenerateNewFood("YellowApple"));
        }
        if (randomHelp >= 60 && randomHelp < 80 && r == 4)
        {
            StartCoroutine(CoGenerateNewFood("Rock"));
        }
        if (randomHelp >= 80 && randomHelp < 100 && r == 5 && Player.BodySnake.Count > 5)
        {
            StartCoroutine(CoGenerateNewFood("Chest"));
        }
        StartCoroutine(CoGenerateNewFood(foodItem));
    }

    public IEnumerator CoGenerateNewFood(string foodItem)
    {
        // создаем экземпляр еды, предварительно загружая префаб из ресурсов
        GameObject food = (GameObject)Instantiate(Resources.Load("Prefabs/" + foodItem, typeof(GameObject)));

        Vector3 randomV = new Vector3(Random.Range(-40, 41), -1, Random.Range(-40, 41));

        Collider[] mas = Physics.OverlapSphere(randomV, 2);//2

        if (mas.Length != 0)
        {
            foreach (var item in mas)
            {
                if (item.GetComponent<CheckColliderHelper>() || item.GetComponent<Player>() || item.GetComponent<RedApple>())
                {
                    StartCoroutine(CoGenerateNewFood(foodItem));
                }

            }
        }
        else
        {
            food.transform.position = randomV;
            if (food.GetComponent<YellowApple>() || food.GetComponent<Shears>() || 
                food.GetComponent<Stone>() || food.GetComponent<Coin>())
            {

            }
            yield return null;
        }
    }
}

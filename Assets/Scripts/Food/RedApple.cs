using UnityEngine;
using System.Collections;

public class RedApple : MonoBehaviour {

    public int points = 10;
    private static bool _currentRedApple = false;

    void Start()
    {
        if (_currentRedApple)
            Destroy(gameObject);
        _currentRedApple = true;
    }

    public void Update()
    {
        transform.Rotate(Vector3.up, 60 * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _currentRedApple = false;
            Destroy(gameObject);

            var Player = FindObjectOfType<Player>();
            var Food = FindObjectOfType<Food>();
            if (Food && Player)
            {
                Game.points += points;
                Food.GenerateNewFood("RedApple");
                Player.AddNewCubeAfterEat();
            }
        }
    }
}

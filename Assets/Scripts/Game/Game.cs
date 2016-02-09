using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public static Game Instance;

    public Text PointsText;
    public Text ResultText;

    public static int points;
 
    private int _lastPoints = -1;

    public float _currentSpeed = 16;
    public int _currentTimeForDestroy = 20;
 
    public void Awake()
    {
        Instance = this;

        points = 0;

        Instantiate(Resources.Load("Prefabs/RedApple"),
                    new Vector3(Random.Range(-40, -5), -1, Random.Range(-40, 5)),
                    Quaternion.identity);
    }

    public void Update()
    {
        // обновление отображаемого текста очков только при их изменении
        if (_lastPoints == points) return;

        _lastPoints = points;

        PointsText.text = "Score: " + points.ToString("0000");

        _currentSpeed = _currentSpeed + points / 50;
    }
}

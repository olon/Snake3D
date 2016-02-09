using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

// скрипту игрока необходим на объекте компонент CharacterController
// с помощью этого компонента будет выполняться движение
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public List<GameObject> BodySnake;
    public GameObject PanelPlayerName;
    public GameObject InputFieldPlayerName;
    public AnimationClip CutCubeAfterDestroy;

    public GameObject[] ButtonAll;

    // аналогично скорость вращения 60 градусов в секунду по умолчанию
    public float rotationSpeed = 600;

    // локальная переменная для хранения ссылки на компонент CharacterController
    private CharacterController _controller;

    private bool _testing = false;
    private static bool _snake = true;

    private static int countSphereBodySnake = 0;

    private GameObject current;


    public void Start()
    {
        _controller = GetComponent<CharacterController>();

        BodySnake = new List<GameObject>();

        current = MadeNewCubeInTail(gameObject);

        _snake = true;
    }

    public void Update()
    {

        _testing = true; // маленкий хинт, для того, чтобы не обрабатывать несколько коллизий за кадр
        // двигаем змею постоянно
        if (_snake)
        {
            _controller.Move(transform.forward * Game.Instance._currentSpeed * Time.deltaTime);
        }
    }


    public void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (_testing)
        {
            _testing = false;
            if (other.gameObject.tag == "Wall" || other.gameObject.GetComponent<Tail>())
            {
                PanelPlayerName.SetActive(true);
                InputFieldPlayerName = GameObject.Find("InputFieldPlayerName");
                _snake = false;

                for (int i = 0; i < ButtonAll.Length; i++)
                {
                    ButtonAll[i].active = false;
                }
            }
        }
    }

   public void AddNewCubeAfterEat()
    {
        StartCoroutine(CoAddNewCubeAfterEat());
    }

    private IEnumerator CoAddNewCubeAfterEat()
    {
        GameObject tranHelp = null;
        for(int i = 0; i < BodySnake.Count; i++)
        {
            if (!_snake)
                break;

            if (tranHelp)
                tranHelp.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

            BodySnake[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

            tranHelp = BodySnake[i];


            yield return new WaitForSeconds(1);
        }

        if (_snake)
        {
            tranHelp.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                current = MadeNewCubeInTail(current);
        }
    }

    public void DeleteFourCubeAfterEatShears(int cutCount)
    {
        StartCoroutine(CoDeleteFourCubeAfterEatShears(cutCount));
    }

    private IEnumerator CoDeleteFourCubeAfterEatShears(int cutCount)
    {
        for (int i = 0; i < cutCount; i++)
        {
            BodySnake[BodySnake.Count - 1].GetComponent<Animation>().Play("CutCubeAfterDestroy");
            yield return new WaitForSeconds(1);
            Destroy(BodySnake[BodySnake.Count - 1].transform.gameObject);
            BodySnake.RemoveAt(BodySnake.Count - 1);
            current = BodySnake[BodySnake.Count - 1];
        }
    }

    private GameObject MadeNewCubeInTail(GameObject current)
    {
        GameObject BodySnake = Instantiate(Resources.Load("Prefabs/BodySnake"),
            current.transform.position - current.transform.forward * 2,
            transform.rotation) as GameObject;
        BodySnake.transform.name = "BodySnake " + countSphereBodySnake++;
        BodySnake.GetComponent<Tail>().target = current.transform;

        this.BodySnake.Add(BodySnake);

        return BodySnake;
    }

    public void NamePlayer()
    {
        string s = InputFieldPlayerName.GetComponent<InputField>().text;
        HightScoreHelper.WriteToXml(s);
        Application.LoadLevel("MainMenu");
    }

    public void MoveLeftButton()
    {

        transform.Rotate(0, -30.0f, 0);
    }

    public void MoveRightButton()
    {
        transform.Rotate(0, 30.0f, 0);
    }


    }


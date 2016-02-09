using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    // цель, на которую должен смотреть объект
    public Transform target;

    public void Update()
    {
        if (target != null)
        {
            // Смотрим всегда на цель
            transform.LookAt(target);
        }
    }
}

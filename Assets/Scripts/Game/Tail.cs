using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour {

    public Transform target;
    public float targetDistance;

    public void Update()
    {
        // направление на цель
        Vector3 direction = target.position - transform.position;

        // дистанция до цели
        float distance = direction.magnitude;

        // если расстояние до цели хвоста больше заданного
        if (distance > targetDistance)
        {
            // двигаем хвост
            transform.position += direction.normalized * (distance - targetDistance);
            // смотрим на цель
            transform.LookAt(target);
        }
    }
}

using UnityEngine;
using System.Collections;

public class LoadLevelByTimer : MonoBehaviour {

    // время до загрузки уровня
    public float delay = 3;

    // имя загружаемого уровня
    public string levelName;

    // функция старт имеет типа IEnumerator из пространства имен System.Collections. 
    // данный тип необходим для поддержки функцией Start механизма сопрограмм
    // подробнее о сопрограммах читайте в статье "Сопрограммы"
    public IEnumerator Start()
    {
        // задержка на заданное число секунд
        yield return new WaitForSeconds(delay);

        // загрузка уровня с указанным именем
        Application.LoadLevel(levelName);

    }
}

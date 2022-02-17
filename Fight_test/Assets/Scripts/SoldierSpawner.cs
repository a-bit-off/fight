using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] soldier;
    [SerializeField] private Vector3 soldierPosition, soldierRotation;
    private List<Vector3> allSoldiersPositions = new List<Vector3> { }; //динамический список занятых позиций


    private void Start()
    {
        SpawnSoldiers(0); //спавн красного, затем синего солдата
        SpawnSoldiers(1);
    }

    private void SpawnSoldiers(int index)
    {
        int num = 0;

        while(num < 3)
        {
            if (index == 0)
            {
                soldierPosition.x = (int)Random.RandomRange(-3, 4);
                soldierPosition.z = (int)Random.RandomRange(-6, -3);
                soldierRotation = new Vector3(0, 0, 0);
            }
            else if (index == 1)
            {
                soldierPosition.x = (int)Random.RandomRange(-3, 4);
                soldierPosition.z = (int)Random.RandomRange(4, 7);
                soldierRotation = new Vector3(0, 180, 0);
            }

            if (IsPositionEmpty(soldierPosition))
            {
                allSoldiersPositions.Add(soldierPosition);
                num += 1;

                //функция спавна
                Instantiate(soldier[index], soldierPosition, Quaternion.Euler(soldierRotation));
            }

        }

    }


    private bool IsPositionEmpty(Vector3 targetPos) //функция будет возвращать false или true в зависимости свободно мсето для расположение КУБА или нет
    {
        foreach (Vector3 pos in allSoldiersPositions)//перебирает все доступные позиции, если обнаружено совапдение то возвращает FALSE
        {
            if (pos.x == targetPos.x && pos.z == targetPos.y)
                return false;
        }
        return true;
    }
}

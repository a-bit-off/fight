using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] solider;
    [SerializeField] private Vector3 soliderPosition;
    private List<Vector3> allSolidersPositions = new List<Vector3> { }; //динамический список занятых позиций


    private void Start()
    {
        SpawnSoliders(0); //спавн красного, затем синего солдата
        SpawnSoliders(1);

    }

    private void SpawnSoliders(int index)
    {
        int num = 0;

        while(num < 4)
        {
            if (index == 0)
            {
                soliderPosition.x = (int)Random.RandomRange(-3, 4);
                soliderPosition.z = (int)Random.RandomRange(-6, -3);
            }
            else if (index == 1)
            {
                soliderPosition.x = (int)Random.RandomRange(-3, 4);
                soliderPosition.z = (int)Random.RandomRange(4, 7);
            }

            if (IsPositionEmpty(soliderPosition))
            {
                allSolidersPositions.Add(soliderPosition);
                num += 1;

                //функция спавна
                Instantiate(solider[index], soliderPosition, transform.rotation);
            }

        }

    }


    private bool IsPositionEmpty(Vector3 targetPos) //функция будет возвращать false или true в зависимости свободно мсето для расположение КУБА или нет
    {
        foreach (Vector3 pos in allSolidersPositions)//перебирает все доступные позиции, если обнаружено совапдение то возвращает FALSE
        {
            if (pos.x == targetPos.x && pos.z == targetPos.y)
                return false;
        }
        return true;
    }
}

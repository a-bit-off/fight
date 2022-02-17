using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] solider;
    [SerializeField] private Vector3 soliderPosition, soliderRotation;
    private List<Vector3> allSolidersPositions = new List<Vector3> { }; //динамический список занятых позиций


    private void Start()
    {
        SpawnSoliders(0); //спавн красного, затем синего солдата
        SpawnSoliders(1);
    }

    private void SpawnSoliders(int index)
    {
        int num = 0;

        while(num < 3)
        {
            if (index == 0)
            {
                soliderPosition.x = (int)Random.RandomRange(-3, 4);
                soliderPosition.z = (int)Random.RandomRange(-6, -3);
                soliderRotation = new Vector3(0, 0, 0);
            }
            else if (index == 1)
            {
                soliderPosition.x = (int)Random.RandomRange(-3, 4);
                soliderPosition.z = (int)Random.RandomRange(4, 7);
                soliderRotation = new Vector3(0, 180, 0);
            }

            if (IsPositionEmpty(soliderPosition))
            {
                allSolidersPositions.Add(soliderPosition);
                num += 1;

                //функция спавна
                Instantiate(solider[index], soliderPosition, Quaternion.Euler(soliderRotation));
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

/*
    //RED
public class SoliderOptions : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] int live = 10;

    [SerializeField] int layer = 10; //For BLUE
    [SerializeField] RaycastHit hit;
    [SerializeField] Ray ray;
    bool flag = true;


    private void Start()
    {
        damage = (int)Random.Range(1, 3);
        radius = (int)Random.Range(5, 11);
        speed = (int)Random.Range(1, 4);
    }

    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * radius, Color.yellow);
  
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == layer)
            {
                if (flag)
                {
                    InvokeRepeating("DPS", 1f, 1f);
                    flag = false;
                }                
            }
            else
            {
                CancelInvoke();
                flag = true;
            }
        }
        else
        {
            CancelInvoke();
            flag = true;
        }
    }
    void DPS()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<SoliderOptions>().live <= 0)
            {
                Destroy(hit.collider.gameObject);
            }
            else
                hit.collider.gameObject.GetComponent<SoliderOptions>().live -= damage;
        }
    }
}

    */
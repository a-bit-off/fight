using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RED
public class SoldierOptions : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] int live = 12;

    [SerializeField] private int layer = 10; //For BLUE
    [SerializeField] private RaycastHit hit;
    [SerializeField] private Ray ray;
    [SerializeField] private bool flag = true;
    [SerializeField] private string enemyTag;


    ScenesManager SM = new ScenesManager();

    //Find
    GameObject[] enemy;
    GameObject closest;

    //Movement
    public float Speed = 10f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        damage = (int)Random.Range(3, 5);
        radius = (int)Random.Range(5, 11);
        BlueOrRed();
    }

    private void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag(enemyTag);

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
                CancelInvoke("DPS");
                flag = true;
            }
        }
        else
        {
            CancelInvoke("DPS");
            flag = true;
        }


        if (enemy.Length > 0)
        {
            FindClosestEnemy();
            MovementLogic();
        }
        else
        {
            SM.Restart();
        }
    }




    void DPS()
    {
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<SoldierOptions>().live <= 0)
            {
                Destroy(hit.collider.gameObject);
            }
            else
                hit.collider.gameObject.GetComponent<SoldierOptions>().live -= damage;
        }
    }

    GameObject FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject go in enemy)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    private void MovementLogic()
    {
        if(FindClosestEnemy().gameObject.transform != null)
        {
            Vector3 movement = new Vector3(0f, 0.0f, 1f);
            
            transform.LookAt(FindClosestEnemy().gameObject.transform);

            transform.Translate(movement * Speed * Time.deltaTime);
        }
    }

    private void BlueOrRed()
    {
        if (gameObject.layer == 9)
        {
            layer = 10;
            enemyTag = "SoldierBlue";
        }
        else
        {
            layer = 9;
            enemyTag = "SoldierRed";
        }
    }
}

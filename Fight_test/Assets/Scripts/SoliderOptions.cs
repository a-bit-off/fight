using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoliderOptions : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] int live = 10;


    //Raycast
    private void Start()
    {
        damage = (int)Random.Range(1, 4);
        radius = (int)Random.Range(5, 11);
        speed = (int)Random.Range(1, 4);
    }


    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        //RED
        if (gameObject.layer == 9)
        {
            Debug.DrawRay(transform.position, transform.forward * radius, Color.yellow);
            RaycastHIT(10, ray);
        }

        //BLUE
        else if (gameObject.layer == 10)
        {
            Debug.DrawRay(transform.position, -transform.forward * radius, Color.yellow);
            RaycastHIT(9, ray);
        }
    }

    private void RaycastHIT(int layer, Ray ray)
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == layer)
            {
                hit.collider.gameObject.GetComponent<SoliderOptions>().live -= damage;
                Debug.Log("live_" + hit.collider.gameObject.name + " = " + hit.collider.gameObject.GetComponent<SoliderOptions>().live);
            }
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{

    public Rigidbody rb;

    private float myG = 6.67f;

    public static List<Attraction> planetAttractions;

    private void FixedUpdate()
    {

        foreach (var pAttraction in planetAttractions) 
        {
            //ไม่ดูดตัวเอง
            if (pAttraction != this) 
            {
                Attract(pAttraction); 
            }
        }

    }//FixUpdate

    void Attract(Attraction other)
    {
        //F = G*(m1*m2)/d^2
        Rigidbody rbOther = other.rb;

        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;
        float forceMegitude = myG * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMegitude;

        rbOther.AddForce(force);
    }

    private void OnEnable()
    {
        if (planetAttractions == null)
        {
            planetAttractions = new List<Attraction>();

            planetAttractions.Add(this);
        }
    }

}

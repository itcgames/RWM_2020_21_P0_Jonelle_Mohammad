using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public bool shieldActive;

    public void Start()
    {
        shieldActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ShipModel")
        {
           shieldActive = true;
        }
    }

    public bool getShieldActive()
    {
        return shieldActive;
    }
  
}

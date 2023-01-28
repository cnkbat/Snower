using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Rb2d;
    [SerializeField] float TurnRate;

    SurfaceEffector2D[] SurfaceEffector;

    [SerializeField] float BoostSpeed= 30;

    [SerializeField] float BaseSpeed = 20;

    public bool CanMove= true;
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();

        SurfaceEffector = FindObjectsOfType<SurfaceEffector2D>();
    }
 
    void Update()
    {
        if(CanMove)
        {
            RotateCharacter();
        }
        RespondToBoost();
    }
    public void DisableController()
    {
        CanMove=false;
        BaseSpeed=0;
        BoostSpeed=0;
    }
    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            for(int i = 0; i < SurfaceEffector.Length; i++)
            {
                SurfaceEffector[i].speed= BoostSpeed;
            }
        }
        else
        {
            for(int i = 0; i < SurfaceEffector.Length; i++)
            {
                SurfaceEffector[i].speed= BaseSpeed;
            }
        }

    }
    private void RotateCharacter()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rb2d.AddTorque(TurnRate);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Rb2d.AddTorque(-TurnRate);
        }
    }
}

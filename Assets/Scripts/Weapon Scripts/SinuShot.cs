using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinuShot : Weapon
{
    
    public float speed = 15f;

    //good old trig
    //not using these yet, may do so for further control over the function.
    //This would use the function p(x) = Amp sin( freq (t + hShift)) + vShift, where x is position and t is time.

    public float amplitude = 5f; //amplitude;
    public float frequency = 4f; //Frequency
    public float horizontalShift = 0; //Horizontal Shift
    public float verticalShift = 0; //vertical shift;



    private float period;
    private Vector3 position;
    private Vector3 axis;

    public PlayerController player;

    protected override void Awake()
    {
        //period = Mathf.PI / frequency;
        bod = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        position = player.transform.position;
        axis = transform.up;
    }


    private void Update() {
        Oscillate();
    }

    private void Oscillate()
    {
        position += transform.up * Time.deltaTime * speed;
        transform.position = position + axis * Mathf.Sin(Time.time * frequency) * amplitude;
    }

    private void OnEnable()
    {
        Invoke("Disable", 4f);
    }


}

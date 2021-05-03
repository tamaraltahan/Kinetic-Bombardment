using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinuShot : Weapon
{
    
    public float speed = 15f;

    public float amplitude = 5f; //amplitude;
    public float frequency = 4f; //Frequency
    private Vector3 position;

    public PlayerController player;

    protected override void Awake()
    {
        //period = Mathf.PI / frequency;
        bod = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        position = player.spawnObject.transform.position;
    }


    private void Update() {
        Oscillate();
    }

    private void Oscillate()
    {
        position += transform.up * Time.deltaTime * speed;
        transform.position = position + transform.right * Mathf.Sin(Time.time * frequency) * amplitude;
    }

    private void OnEnable()
    {
        Invoke("Disable", 4f);
    }


}

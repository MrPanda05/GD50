using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;

    private BoxCollider2D box;

    [SerializeField]
    private float speed;

    private float Inputes { get; set; }

private void MovePlayer()
    {
        rig.velocity = new Vector2(Inputes, 0) * speed;
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        //this.enabled = false;
    }
    private void Update()
    {
        Inputes = Input.GetAxisRaw("Horizontal");
        
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

}

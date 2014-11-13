using UnityEngine;
using System.Collections;
[RequireComponent(typeof(playerphysics))]
public class Mapmovement : MonoBehaviour
{

    public float gravity = 0;
    public float speed = 0.4f;
    public float acceleration = 20;
    public float jumpheight = 8;

    private float currentspeed;
    private float targetspeed;
    private Vector2 move;

    private playerphysics pp;

    // Use this for initialization
    void Start()
    {
        pp = GetComponent<playerphysics>();

    }

    // Update is called once per frame
    void Update()
    {
        targetspeed =-20*Time.deltaTime;
        currentspeed = IncrementTowards(currentspeed, targetspeed, acceleration);
        if(Input.GetKey(KeyCode.D))
        {
            targetspeed += -speed*20;
            currentspeed = IncrementTowards(currentspeed, targetspeed, acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
			targetspeed += speed*2*Time.deltaTime;
			currentspeed = IncrementTowards(currentspeed, targetspeed, acceleration);
        }
        move.x = currentspeed;
        move.y -= gravity * Time.deltaTime;
        pp.Move(move * Time.deltaTime);
    }

    private float IncrementTowards(float n, float target, float a)
    {
        if (n == target)
        {
            return n;
        }
        else
        {
            float dir = Mathf.Sign(target - n);
            n += a * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;


        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "teleport")
        {
            Vector2 position = transform.position;
            position.x += 40f;
            transform.position = position;
        }
    }
}

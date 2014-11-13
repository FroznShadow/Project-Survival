using UnityEngine;
using System.Collections;
[RequireComponent(typeof(playerphysics))]
public class Playermovement1 : MonoBehaviour {
    public float gravity = 20;
    public float speed=5;
    public float acceleration=20;
    public float jumpheight=8;

    private float currentspeed;
    private float targetspeed;
    private Vector2 move;

    private playerphysics pp;

	// Use this for initialization
	void Start () {
        pp = GetComponent < playerphysics>();
	
	}
	
	// Update is called once per frame
	void Update () {
        targetspeed =0;
        currentspeed = IncrementTowards(currentspeed, targetspeed, acceleration);
        if(pp.grounded)
        {
            move.y = 0;
            if(Input.GetButtonDown("Jump"))
            {
                move.y = jumpheight;
            }
        }
        move.x = currentspeed;
        move.y -= gravity * Time.deltaTime;
        pp.Move(move*Time.deltaTime);
    }
        
            private float IncrementTowards(float n,float target, float a)
            {
                if(n==target){
                    return n;
                }
                else
                {
                    float dir = Mathf.Sign(target - n);
                    n += a * Time.deltaTime * dir;
                    return(dir == Mathf.Sign(target-n))? n : target;
                
            
        }
	}
}

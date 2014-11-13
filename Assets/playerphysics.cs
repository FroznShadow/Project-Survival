using UnityEngine;
using System.Collections;
[RequireComponent(typeof(BoxCollider))]
public class playerphysics : MonoBehaviour {
    public LayerMask collisionMask;
    private BoxCollider collider;
    private Vector3 s;
    private Vector3 c;
    private float skin=.005f;
    [HideInInspector]
    public bool grounded;

    Ray ray;
    RaycastHit hit;

    void Start() {
        collider = GetComponent<BoxCollider>();
        s = collider.size;
        c = collider.center;
    }

    public void Move(Vector2 move)
    {
        float deltaX=move.x;
        float deltaY = move.y;
        Vector2 p = transform.position;
        grounded = false;
        for(int i=0;i<3;i++)
        {
            float dir = Mathf.Sign(deltaY);
            float x=(p.x+c.x-s.x/2)+s.x/2*i;
            float y=p.y+c.y+s.y/2*dir;

            ray = new Ray(new Vector2(x, y), new Vector2(0, dir));
            if(Physics.Raycast(ray,out hit,Mathf.Abs(deltaY),collisionMask))
            {
                float dst = Vector3.Distance(ray.origin, hit.point);
                if(dst>skin)
                {
                    deltaY = -dst + skin;
                }
                else
                {
                    deltaY = 0;
                }
                grounded = true;
                break;
            }
        }
        Vector2 finaltransform=new Vector2(deltaX, deltaY);
        transform.Translate(finaltransform);
	}
}

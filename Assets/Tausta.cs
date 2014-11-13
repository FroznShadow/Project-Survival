using UnityEngine;
using System.Collections;
//Requires gameobject to have meshrenderer
[RequireComponent(typeof(MeshRenderer))]
public class Tausta : MonoBehaviour {

    public float ScrollSpeedHorizontal = 0; // TODO: set scrolling value on inspector
    public float ScrollSpeedVertical = 0;   // TODO: set scrolling value on inspector

    private Vector2 CurrentOffset = Vector2.zero;

	void Start () 
    {
        //Disable script if Meshrenderer's material doesn't have texture
        if (renderer.material.mainTexture == null)
        {
            this.enabled = false;
        }
	}
	
    void Update () 
    {
        //Calculate current offset
        CurrentOffset += new Vector2(ScrollSpeedHorizontal, ScrollSpeedVertical) * Time.deltaTime;
        //Set offset to maintexture property
        renderer.material.SetTextureOffset("_MainTex", CurrentOffset);
	}
}

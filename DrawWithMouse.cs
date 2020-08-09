using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//identitfy each responsibility
//move each into their own seperate function/class
//abstraction

//What i want being able to draw regardless of mouse, or any other way. So we need to rename this later also.
//alsop make the SetVector as loosley coupled as possible
//Create an interface to setup the shader variables, and specefic shader being used on the material.

//responsibilties:
// Get input where to draw
// Draw position: Shader, RenderTexture

//propose name, DrawOnRenderTexture


public class DrawWithMouse : MonoBehaviour
{
    public Camera _camera;

    private RaycastHit _hit;
    // Start is called before the first frame update
    
    void Start()
    {
        /*
        
        

        _snowMaterial = GetComponent<MeshRenderer>().material; //get material on the mesh render, this is the one we will put the texture on.
        _splatmap = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGBFloat); //create the map to draw on, later to be put on the whiteboard.
        _snowMaterial.SetTexture("_MainTex", _splatmap); //setting the texture on the whiteboard
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) //get mouse input.
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit))  //create a ray from the camera.
            {
                float x = _hit.textureCoord.x;
                float y = _hit.textureCoord.y;
             //   Draw(x, y);
            }
        }

    }

   

   

}

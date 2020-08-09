using UnityEngine;


public class PenController : MonoBehaviour
{
    public GameObject Whiteboard;
    private RaycastHit touch;
    private bool lastTouch;
    private Quaternion lastAngle;
    private DrawOnRenderTexture canvas;
    private DrawOnRenderTextureBrush _brush;


    private void Awake()
    {
        _brush = GetComponent<DrawOnRenderTextureBrush>();
    }

    void DrawOnCanvas(Collider collider)
    {
        
    }

    void Update()
    {
        float tipheight = transform.Find("tip").localScale.y / 2;
        Transform _tip = transform.Find("tip");
        Ray _ray = new Ray(_tip.position, _tip.up);
        
        if (Physics.Raycast(_ray, out touch, tipheight / 2))
        {
            if (!(touch.collider.tag == "Whiteboard")) return;

            canvas = touch.collider.GetComponent<DrawOnRenderTexture>(); //refactor, do not call it from here.
            canvas.Draw(touch.textureCoord.x, touch.textureCoord.y, _brush);

            if (!lastTouch) //lock rotation if first time tuching board since detected.
            {
                lastTouch = true;
                lastAngle = transform.rotation;
            }
        }
        else 
        {
            lastTouch = false;
        }
        if (lastTouch)
        {
            transform.rotation = lastAngle;
        }
    }
}

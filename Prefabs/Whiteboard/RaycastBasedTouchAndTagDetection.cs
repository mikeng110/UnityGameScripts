using UnityEngine;

//change name
public class RaycastBasedTouchAndTagDetection : MonoBehaviour, ITouchDetection 
{
    private TouchData _touchData;
    private RaycastHit touch;

    private void Awake()
    {
        _touchData = new TouchData();
    }
    public bool Touching()
    {
        //create ray
        float tipheight = transform.Find("tip").localScale.y / 2;
        Transform _tip = transform.Find("tip");
        Ray _ray = new Ray(_tip.position, _tip.up);
        bool touched = Physics.Raycast(_ray, out touch, tipheight / 2) && (touch.collider.tag == "Whiteboard");
        if (touched)
        {
            _touchData.TouchPoint = new Vector3(touch.textureCoord.x, touch.textureCoord.y, 0);
            _touchData.TouchedObject = touch.collider.gameObject;
        }

        return touched;
    }

    public TouchData GetTouchData()
    {
        return _touchData;
    }
     
}
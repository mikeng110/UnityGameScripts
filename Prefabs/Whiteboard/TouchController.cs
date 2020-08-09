using UnityEngine;


public partial class PenController : MonoBehaviour
{
    public GameObject Whiteboard;
    private RaycastHit touch;
    private Quaternion lastAngle;
    private DrawOnRenderTexture canvas;
    private ITouchResponse _touchResponse;

    private void Awake()
    {
        _touchResponse = GetComponent<ITouchResponse>();
    }

    void Update()
    {
        //create ray
        float tipheight = transform.Find("tip").localScale.y / 2;
        Transform _tip = transform.Find("tip");
        Ray _ray = new Ray(_tip.position, _tip.up);

        //check Collsion and tag
        bool touched = Physics.Raycast(_ray, out touch, tipheight / 2);

        if (touched)
        {
            if (!(touch.collider.tag == "Whiteboard")) return;

            _touchResponse.OnTouchEnter(new Vector3(touch.textureCoord.x, touch.textureCoord.y,0), touch.collider.gameObject);
        }

    }
}

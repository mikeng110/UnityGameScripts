using UnityEngine;


public class TouchController : MonoBehaviour
{
    
    private ITouchResponse _touchResponse;
    private ITouchDetection _touchDetection;

    private void Awake()
    {
        _touchResponse = GetComponent<ITouchResponse>();
        _touchDetection = GetComponent<ITouchDetection>();
    }

    void Update()
    {
        if (_touchDetection.Touching())
        {
            TouchData data = _touchDetection.GetTouchData();

            _touchResponse.OnTouchEnter(data.TouchPoint, data.TouchedObject);
        }
    }
}

using UnityEngine;


public class PenTouchCanvasResponse : MonoBehaviour, ITouchResponse
{
    private DrawOnRenderTextureBrush _brush;

    private void Awake()
    {
        _brush = GetComponent<DrawOnRenderTextureBrush>();

    }

    public void OnTouchEnter(Vector3 touchPoint, GameObject touchedObject)
    {
        DrawOnCanvas(touchPoint.x, touchPoint.y, touchedObject);
    }

    public void OnTouchExit(Vector3 touchPoint, GameObject touchedObject)
    {

    }

    private void DrawOnCanvas(float x, float y, GameObject obj)
    {
        DrawOnRenderTexture canvas = obj.GetComponent<DrawOnRenderTexture>();
        canvas.Draw(x, y, _brush);
    }
}
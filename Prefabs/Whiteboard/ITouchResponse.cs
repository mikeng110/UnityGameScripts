using UnityEngine;

public interface ITouchResponse
{
    void OnTouchEnter(Vector3 touchPoint, GameObject touchedObject);
    void OnTouchExit(Vector3 touchPoint, GameObject touchedObject);
}
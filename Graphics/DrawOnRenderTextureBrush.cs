using Assets.Scripts;
using UnityEngine;

public class DrawOnRenderTextureBrush : MonoBehaviour, IRenderTextureBrush  
{
    //does this need to be a gameobject?
    public Color _color;
    public float _size;
    public Shader _shader;
    private Material _material;

    private static readonly string shader_coord_label = "_Coordinate";
    private static readonly string shader_color_label = "_Color";

    private void Start()
    {
        _material = new Material(_shader);
    }

    private void Update()
    {
        UpdateMaterial();
    }

    public void SetPos(Vector4 coordinates)
    {
        _material.SetVector(shader_coord_label, coordinates);
    }

    private void UpdateMaterial()
    {
        _material.SetVector(shader_color_label, _color);
    }

    public Material GetMaterial()
    {
        return _material;
    }

    
}
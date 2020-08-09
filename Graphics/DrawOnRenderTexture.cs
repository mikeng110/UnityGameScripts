using Assets.Scripts;
using UnityEngine;

public class DrawOnRenderTexture : MonoBehaviour
{
    //make this into a c# class object
    public float x = 0.0f;
    public float y = 0.0f;
    public int _x_res = 1024;
    public int _y_res = 1024;
    public string target_shader_tex_label = "_MainTex";

    private  RenderTexture _renderTexture;
    private Material _targetMaterial;
    private static RenderTextureFormat _tex_format = RenderTextureFormat.ARGBFloat;
    private int depth = 0;

    private void Awake()
    {
        
    }


    private void Start()
    {
        _targetMaterial = GetComponent<MeshRenderer>().material;
        _renderTexture = new RenderTexture(_x_res, _y_res, depth, _tex_format);
        _targetMaterial.SetTexture(target_shader_tex_label, _renderTexture);
    }

    public void Draw(float x, float y, IRenderTextureBrush _brush)
    {
        _brush.SetPos(new Vector4(x, y, 0, 0));
        RenderTexture temp = RenderTexture.GetTemporary(_renderTexture.width, _renderTexture.height, depth, _renderTexture.format); 
        Graphics.Blit(_renderTexture, temp);
        Graphics.Blit(temp, _renderTexture, _brush.GetMaterial());
        RenderTexture.ReleaseTemporary(temp);
    }
}



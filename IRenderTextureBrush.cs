using UnityEngine;

namespace Assets.Scripts
{
    public interface IRenderTextureBrush
    {
        void SetPos(Vector4 coordinates);
        Material GetMaterial();
    }
}

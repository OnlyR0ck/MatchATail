using UnityEngine;
using UnityEngine.UI;

namespace Game.Animals
{
    public class OutlineEffectController
    {
        private readonly int outlineEnabled = Shader.PropertyToID("_OutlineEnabled");
        private readonly Image targetImage;

        public OutlineEffectController(Image targetImage)
        {
            this.targetImage = targetImage;
            targetImage.material = new Material(targetImage.material);
        }

        public void SetActiveSpriteOutline(bool isActive)
        {
            float value = isActive ? 1 : 0;
            targetImage.material.SetFloat(outlineEnabled, value);
        }
    }
}
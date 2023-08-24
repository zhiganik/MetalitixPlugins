using Metalitix.Core.Data.InEditor;
using Metalitix.Preview.Base;
using UnityEngine;

namespace Metalitix.Preview.Elements.Sliders
{
    public class PreviewSliderWithContainer : PreviewSliderBase
    {
        [SerializeField] private RectTransform container;
        [SerializeField] private float leftX;
        [SerializeField] private float rightX;

        public void SetTransformOnSlider(RectTransform rectTransform, float sliderValue)
        {
            rectTransform.SetParent(container, false);
            rectTransform.anchoredPosition = Vector3.zero;
            rectTransform.sizeDelta = new Vector2(30f, -20f);
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.Euler(Vector3.zero);
            rectTransform.localScale = Vector3.one;

            float positionX = Mathf.Lerp(leftX, rightX, (sliderValue - slider.minValue) / (slider.maxValue - slider.minValue));
            rectTransform.anchoredPosition = new Vector3(positionX, 0, 0);
        }

        public override void Interact(InteractableData interactableData)
        {
            var value = GetInteractedSliderValue(interactableData);
            slider.value = value;
            base.Interact(interactableData);
        }
    }
}
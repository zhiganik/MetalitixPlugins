using Metalitix.Core.Data.InEditor;
using Metalitix.Preview.Base;
using UnityEngine;

namespace Metalitix.Preview.Elements.Sliders
{
    [RequireComponent(typeof(RectTransform))]
    public class PreviewSlider : PreviewSliderBase
    {
        public override void Interact(InteractableData interactableData)
        {
            var value = GetInteractedSliderValue(interactableData);
            slider.value = value;
            base.Interact(interactableData);
        }
    }
}
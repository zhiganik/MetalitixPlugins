using Metalitix.Core.Data.InEditor;
using Metalitix.Preview.Base;
using Metalitix.Preview.Tools;
using UnityEngine;

namespace Metalitix.Preview.Elements.Sliders
{
    public class PreviewValueSlider : PreviewSliderBase
    {
        [SerializeField] private SliderValuesContainer valuesContainer;

        public override void Interact(InteractableData interactableData)
        {
            var value = GetInteractedSliderValue(interactableData);
            slider.value = valuesContainer.GetValidSliderValue(value);
            base.Interact(interactableData);
        }

        public void SetDefault()
        {
            slider.value = valuesContainer.DefaultValue;
        }
    }
}
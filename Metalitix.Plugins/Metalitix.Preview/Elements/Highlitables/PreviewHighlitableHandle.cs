using Metalitix.Preview.Base;
using Metalitix.Preview.Tools;
using UnityEngine;

namespace Metalitix.Preview.Elements.Highlitables
{
    public class PreviewHighlitableHandle : PreviewHighlitable
    {
        [SerializeField] private FloatText floatText;
        [SerializeField] private PreviewSliderBase previewSliderBase;

        public override void PointerEnter()
        {
            floatText.SetText(previewSliderBase.Value);
            floatText.SetVisible(true);
        }

        public override void PointerExit()
        {
            floatText.SetVisible(false);
        }
    }
}
using Metalitix.Core.Enums.Runtime;
using UnityEngine;

namespace Metalitix.Core.Settings.Runtime
{
    [CreateAssetMenu(fileName = "Metalitix/Theme", menuName = "Metalitix/Theme", order = 0)]
    public class ColorTheme : ScriptableObject
    {
        [SerializeField] private MetalitixThemeType themeType;
        [SerializeField] private Color mainColor;
        [SerializeField] private Color inverseColor;

        public Color MainColor => mainColor;
        public MetalitixThemeType ThemeType => themeType;
        public Color InverseColor => inverseColor;
    }
}
﻿using Metalitix.Core.EditorAttributes;
using UnityEngine;

namespace Metalitix.Core.Settings.Runtime
{
    [CreateAssetMenu(fileName = "Metalitix/SurveySettings", menuName = "Metalitix/SurveySettings", order = 3)]
    public class SurveySettings : ScriptableObject
    {
        [MinMaxSlider(0.5f, 100)]
        [SerializeField] private Vector2 rangeOfTime = new Vector2(0.5f, 5);
        [HideInInspector, SerializeField, Space(2f)] private ColorTheme currentColorTheme;
        [HideInInspector, SerializeField, Space(2f)] private Object surveyPopUp;
        [HideInInspector, SerializeField, Space(2f)] private bool wasInvoked;

        public ColorTheme CurrentTheme
        {
            get => currentColorTheme;
            set => currentColorTheme = value;
        }

        public Object SurveyPopUp
        {
            get => surveyPopUp;
            set => surveyPopUp = value;
        }

        public Vector2 RangeOfTimePopUpShowing => rangeOfTime;

        public bool WasInvoked
        {
            get => wasInvoked;
            set => wasInvoked = value;
        }
    }
}
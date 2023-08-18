using System;
using Metalitix.Preview.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Metalitix.Preview.Base
{
    [RequireComponent(typeof(Toggle))]
    public abstract class PreviewToggleBase : PreviewInteractable, IScenePreviewInteractable
    {
        [SerializeField] protected Toggle toggle;

        public Toggle Toggle => toggle;

        public event Action<bool> OnToggleValueChanged;

        public virtual void Initialize() { }

        public virtual void Interact()
        {
            if (!toggle.interactable) return;

            ExecuteEvents.Execute(toggle.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
            OnToggleValueChanged?.Invoke(toggle.isOn);
        }
    }
}
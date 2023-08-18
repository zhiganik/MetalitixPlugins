using Metalitix.Preview.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Metalitix.Preview.Base
{
    [RequireComponent(typeof(Button))]
    public class PreviewButton : PreviewInteractable, IScenePreviewInteractable
    {
        [SerializeField] private Button button;

        public Button Button => button;

        public void Interact()
        {
            if (!button.interactable) return;

            ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
        }

        public void SetInteractable(bool interactable)
        {
            button.interactable = interactable;
        }
    }
}
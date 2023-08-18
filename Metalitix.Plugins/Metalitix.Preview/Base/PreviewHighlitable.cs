using Metalitix.Preview.Interfaces;
using UnityEngine;

namespace Metalitix.Preview.Base
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(BoxCollider))]
    public abstract class PreviewHighlitable : MonoBehaviour, IScenePreviewPointerMove
    {
        public virtual void PointerEnter()
        {

        }

        public virtual void PointerExit()
        {

        }
    }
}
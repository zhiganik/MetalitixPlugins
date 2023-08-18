using Metalitix.Core.Data.Converters;
using UnityEngine;

namespace Metalitix.Core.Tools
{
    public static class PositionsConverter
    {
        /// <summary>
        /// Convert coordinates From Unity Vector3 to JS 3D Space coordinates
        /// </summary>
        /// <param name="unityCoordinates"></param>
        /// <returns></returns>
        public static Vector3 MetalitixPosition(this Vector3 unityCoordinates)
        {
            return new Vector3(-unityCoordinates.x, unityCoordinates.y, unityCoordinates.z);
        }

        /// <summary>
        /// Convert From JS coordinates to Unity Vector3
        /// </summary>
        /// <param name="unityCoordinates"></param>
        /// <returns></returns>
        public static Vector3 MetalitixPosition(this Vector3Wrapper unityCoordinates)
        {
            return new Vector3(-unityCoordinates.x, unityCoordinates.y, unityCoordinates.z);
        }


        /// <summary>
        /// Convert Unity`s Quaternion to JS rotation based on formula
        /// https://stackoverflow.com/a/53016486   https://stackoverflow.com/questions/18066581/convert-unity-transforms-to-three-js-rotations
        /// </summary>
        /// <param name="unityQuaternion"></param>
        /// <returns></returns>
        public static Vector3 MetalitixDirection(this Quaternion unityQuaternion)
        {
            var euler = unityQuaternion.eulerAngles;

            var convertedEuler = new Vector3(
                euler.x * Mathf.Deg2Rad,
                euler.y * Mathf.Deg2Rad,
                euler.z * Mathf.Deg2Rad);

            convertedEuler.y += Mathf.PI / 2;
            return convertedEuler;
        }

        /// <summary>
        /// Convert JS rotation to Unity`s euler angles
        /// https://stackoverflow.com/a/53016486  https://stackoverflow.com/questions/18066581/convert-unity-transforms-to-three-js-rotations
        /// </summary>
        /// <param name="jsEuler"></param>
        /// <returns></returns>
        public static Vector3 ConvertToUnityDirection(this Vector3Wrapper jsEuler)
        {
            var jsEulerVector = jsEuler.ConvertToVector3();
            jsEulerVector.y -= Mathf.PI / 2;

            var convertedEuler = new Vector3(
                jsEulerVector.x * Mathf.Rad2Deg,
                jsEulerVector.y * Mathf.Rad2Deg,
                jsEulerVector.z * Mathf.Rad2Deg);

            return convertedEuler;
        }
    }
}
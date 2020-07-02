using UnityEngine;

namespace ExtensionsMethods {
    public static class ExtensionMethods {
        /// <summary>
        /// Rounds Vector3.
        /// </summary>
        public static Vector3 Round(this Vector3 vector3, int decimalPlaces = 2) {

            float multiplier = 1;

            for (int i = 0; i < decimalPlaces; i++) {
                multiplier *= 10f;
            }

            return new Vector3(
                Mathf.Round(vector3.x * multiplier) / multiplier,
                Mathf.Round(vector3.y * multiplier) / multiplier,
                Mathf.Round(vector3.z * multiplier) / multiplier);
        }

        /// <summary>
        /// Rounds Vector2.
        /// </summary>
        public static Vector2 Round(this Vector2 vector, int decimalPlaces = 2) {

            float multiplier = 1;

            for (int i = 0; i < decimalPlaces; i++) {
                multiplier *= 10f;
            }

            return new Vector2(
                Mathf.Round(vector.x * multiplier) / multiplier,
                Mathf.Round(vector.y * multiplier) / multiplier);
        }
    }
}
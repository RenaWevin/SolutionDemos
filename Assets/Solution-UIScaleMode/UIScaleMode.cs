
using UnityEngine;
using UnityEngine.UI;

namespace Solution.UIScaleMode {
    public class UIScaleMode : MonoBehaviour {

        public CanvasScaler canvasScaler;

        void Update() {

            if (Input.GetKeyDown(KeyCode.Q)) {
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            }

        }
    }
}
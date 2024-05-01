
using UnityEngine;

namespace Common {
    public class CubeMoveAnimation : MonoBehaviour {

        [SerializeField] private Transform transformToMove;
        [SerializeField] private Vector3 moveStartPosition;
        [SerializeField] private Vector3 moveEndPosition;
        [SerializeField, Min(0.1f)] private float moveDuration = 1f;

        private float timeline = 0f;

        void FixedUpdate() {
            timeline += Time.fixedDeltaTime;
            if (timeline > moveDuration) {
                timeline %= moveDuration;
            }
            if (transformToMove != null) {
                Vector3 pos = Vector3.Lerp(moveStartPosition, moveEndPosition, timeline / moveDuration);
                transformToMove.position = pos;
            }
        }
    }
}
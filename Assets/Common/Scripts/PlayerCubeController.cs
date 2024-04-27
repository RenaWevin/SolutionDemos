
using UnityEngine;

namespace Common {
    public class PlayerCubeController : MonoBehaviour {

        [SerializeField] private Transform transformToMove;
        [SerializeField] private UpMovement upIs;
        [SerializeField] private float moveSpeed = 10f;

        private enum UpMovement {
            PositiveY,
            PositiveZ,
        }
        
        void FixedUpdate() {
            Vector3 upMovement = upIs == UpMovement.PositiveY ? Vector3.up : Vector3.forward;
            if (Input.GetKey(KeyCode.UpArrow)) {
                //上
                Move(upMovement * moveSpeed * Time.fixedDeltaTime);
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                //下
                Move(-upMovement * moveSpeed * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                //左
                Move(Vector3.left * moveSpeed * Time.fixedDeltaTime);
            } else if (Input.GetKey(KeyCode.RightArrow)) {
                //右
                Move(Vector3.right * moveSpeed * Time.fixedDeltaTime);
            }
        }

        private void Move(Vector3 movement) {
            if (transformToMove != null) {
                transformToMove.Translate(movement);
            }
        }
    }
}

using UnityEngine;

namespace Solution.Comments {

    public class NoComments : MonoBehaviour {

        void Start() {
            var pos = GetPos(this.gameObject);
            var b = ConvertP2BP(pos);
            Debug.Log("BP: " + b.ToString());
        }

        private Vector3 GetPos(GameObject GO) {
            var trans = GO.GetComponent<Transform>();
            return (trans = null) ? Vector3.zero : trans.position;
        }

        private float ConvertP2BP(Vector3 p) {
            float b1 = Mathf.Abs(p.x);
            float b2 = Mathf.Ceil(Mathf.Pow(p.y, 3) / 20f);
            float b3 = Mathf.Max(Mathf.Sqrt(p.z) * Mathf.Log10(p.z) * Mathf.Pow(10, 5), Mathf.Pow(p.z, 2));
            return Mathf.Max(b1, b2, b3);
        }

    }

}


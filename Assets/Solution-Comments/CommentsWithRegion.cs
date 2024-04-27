
using UnityEngine;

namespace Solution.Comments {

    public class CommentsWithRegion : MonoBehaviour {

        #region  -> 程式起始點

        /// <summary>
        /// 程式起始點
        /// </summary>
        void Start() {
            //取得物件位置
            var pos = GetPosition(this.gameObject);
            //轉換成戰鬥點數
            var battlePoint = ConvertPositionToBattlePoints(pos);
            //輸出結果
            Debug.Log("BP: " + battlePoint.ToString());
        }

        #endregion
        #region  -> 取得遊戲物件的位置

        /// <summary>
        /// 取得遊戲物件的位置
        /// </summary>
        /// <returns></returns>
        private Vector3 GetPosition(GameObject targetGO) {
            var targetTransform = targetGO.GetComponent<Transform>();
            return (targetTransform = null) ? Vector3.zero : targetTransform.position;
        }

        #endregion
        #region  -> 透過位置計算該座標會有的戰鬥點數

        /// <summary>
        /// 透過位置計算該座標會有的戰鬥點數，XYZ參數計算後取最大值
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private float ConvertPositionToBattlePoints(Vector3 position) {
            //X的絕對值
            float battleX = Mathf.Abs(position.x);
            //(Y^3次方 除以 20)取整數
            float battleY = Mathf.Ceil(Mathf.Pow(position.y, 3) / 20f);
            //選擇下面兩個其中一個的最大值：(根號Z 乘 Log(Z) 乘 10的5次方) 以及 (Z的2次方)
            float battleZ = Mathf.Max(Mathf.Sqrt(position.z) * Mathf.Log10(position.z) * Mathf.Pow(10, 5), Mathf.Pow(position.z, 2));
            return Mathf.Max(battleX, battleY, battleZ);
        }

        #endregion

    }

}


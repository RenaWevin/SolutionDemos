
using System.Collections.Generic;
using UnityEngine;

namespace SolutionMenu {
    public class NameObjectListView : MonoBehaviour {

        [SerializeField]
        public List<NameObjectPair> list = new List<NameObjectPair>();
        [SerializeField]
        public bool enableEdit = false;

    }
}
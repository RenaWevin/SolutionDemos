using System;

namespace SolutionMenu {
    [Serializable]
    public struct NameObjectPair {

        public string name;
        public UnityEngine.Object value;

        public NameObjectPair(string name, UnityEngine.Object value) {
            this.name = name;
            this.value = value;
        }

    }
}
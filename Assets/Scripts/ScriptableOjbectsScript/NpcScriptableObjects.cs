using UnityEngine;

    [CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
    public class NpcScriptableObjects : ScriptableObject
    {
        [SerializeField] private GameObject body;

        public GameObject Body => body;
    }


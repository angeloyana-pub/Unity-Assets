using Unityengine;

class Inventory : MonoBehaviour {
    public List<ChronoInventorySlot> chronos = new List<ChronoInventorySlot>();
    public int activeChronoIndex = -1;
    
    void Start() {
        // TODO: display UI for chronos.
        
        foreach (ChronoInventorySlot chrono in chronos) {
            if (chrono.isActive) {
                Instantiate(
                    chrono.chrono.data.prefab,
                    // transform.position - transform.right * 0.7f,
                    transform.position,
                    Quaternion.identity
                ).GetComponent<FollowPlayer>().SetPlayer(transform);
            }
        }
    }
}
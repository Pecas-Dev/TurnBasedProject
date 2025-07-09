using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    static MouseWorld instance;

    [SerializeField] LayerMask mousePlaneLayerMask;

    void Awake()
    {
        instance = this;   
    }

    void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(cameraRay, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneLayerMask);

        return raycastHit.point;
    }
}

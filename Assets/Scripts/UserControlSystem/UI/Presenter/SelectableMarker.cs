using UserControlSystem;
using UnityEngine;
using System.Linq;
using Abstractions;


public sealed class SelectableMarker : MonoBehaviour
{
    [SerializeField] private GameObject _selectableMarker;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private Camera _camera;
    private Transform _selectableTransform;
    private GameObject _marker;
    

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0))
        {
            return;
        }
        var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
        if (hits.Length == 0)
        {
            
            return;
        }

        Destroy(_marker);
        var selectable = hits
            .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
            .FirstOrDefault(c => c != null);
        HighlightObject(selectable);
    }

    private void HighlightObject(ISelectable selectable)
    {
        if (selectable != null)
        {
            _selectableTransform = (selectable as Component).transform;
            _marker = Instantiate(_selectableMarker, _selectableTransform.position, Quaternion.identity);
        }
    }
}

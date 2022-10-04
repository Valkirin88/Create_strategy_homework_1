using UserControlSystem;
using UnityEngine;
using Abstractions;


public sealed class SelectableMarkerCreator : MonoBehaviour
{
    
    [SerializeField] private SelectableValue _selectedObject;
    private Transform _selectableTransform;
    private GameObject _marker;
    private GameObject _selectableMarker;


    private void Start()
    {
        _selectableMarker = Resources.Load<GameObject>("Marker");
        _selectedObject.OnSelected += HighlightObject;
        HighlightObject(_selectedObject.CurrentValue);
    }

    private void HighlightObject(ISelectable selectable)
    {
        Destroy(_marker);
        if (selectable != null)
        {
            _selectableTransform = (selectable as Component).transform;
            _marker = Instantiate(_selectableMarker, _selectableTransform.position, Quaternion.identity);
        }
    }
}

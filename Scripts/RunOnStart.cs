using UnityEngine;
using UnityEngine.Events;

public class RunOnStart : MonoBehaviour
{
    public UnityEvent myEvent;
    bool _done = false;

    private void Update()
    {
        if (!_done)
        {
            myEvent.Invoke();
            _done = true;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

public class EventInvoker : MonoBehaviour
{
    // Define a public UnityEvent
    public UnityEvent OnFunctionCalled;

    // Create a public function that invokes the UnityEvent
    public void CallFunction()
    {
        OnFunctionCalled.Invoke();
    }
}
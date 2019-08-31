using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageManagerEvents<T>
{
    private static Dictionary<Type, Dictionary<Type, List<Delegate>>> _listeners;
    private static MessageManagerEvents<T> _instance;

    public static MessageManagerEvents<T> Instance
    {
        get { return _instance ?? (_instance = new MessageManagerEvents<T>()); }
    }

    private MessageManagerEvents()
    {
        _listeners = new Dictionary<Type, Dictionary<Type, List<Delegate>>>();
    }

    public void DynamicInvokeAll<T2>(object message)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(message.GetType(), out messages))
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    messages[i].DynamicInvoke(message);
                }
            }
        }
    }

    public void DynamicInvoke<T2>(object message, string eventName)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(message.GetType(), out messages))
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Method.Name.Equals(eventName))
                    {
                        messages[i].DynamicInvoke(message);
                    }
                }
            }
        }
    }

    public void AddListener<T2,T3>(Action<T3> message)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(typeof(T3), out messages))
            {   
                messages.Add(message);
            }
            else
            {
                messages = new List<Delegate> { message };
                delegates.Add(typeof(T3), messages);
            }
        }
        else
        {
            delegates = new Dictionary<Type, List<Delegate>>();
            messages = new List<Delegate> { message };
            delegates.Add(typeof(T3), messages);
            _listeners.Add(typeof(T2), delegates);
        }
    }

    public void RemoveListener<T2,T3>(Action<T3> message)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(typeof(T3), out messages))
            {
                messages.Remove(message);
            }
        }
    }
}
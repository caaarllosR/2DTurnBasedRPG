using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager<T>
{
    private Dictionary<Type, Dictionary<Type, List<Delegate>>> _listeners;
    private static MessageManager<T> _instance;

    public static MessageManager<T> Instance
    {
        get { return _instance ?? (_instance = new MessageManager<T>()); }
    }

    private MessageManager()
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

    public void DynamicInvoke<T2>(string eventName)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(typeof(T2), out messages))
            {
                foreach (Delegate message in messages)
                { 
                    if (message.Method.Name.Equals(eventName))
                    {
                        message.DynamicInvoke();
                    }
                }
            }
        }
    }

    public void DynamicInvoke<T2>(object objMessage, string eventName)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(objMessage.GetType(), out messages))
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Method.Name.Equals(eventName))
                    {
                        messages[i].DynamicInvoke(objMessage);
                    }
                }
            }
        }
    }

    public void AddListener<T2>(Action message)
    {
        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(typeof(T2), out messages))
            {
                messages.Add(message);
            }
            else
            {
                messages = new List<Delegate> { message };
                delegates.Add(typeof(T2), messages);
            }
        }
        else
        {
            delegates = new Dictionary<Type, List<Delegate>>();
            messages = new List<Delegate> { message };
            delegates.Add(typeof(T2), messages);
            _listeners.Add(typeof(T2), delegates);
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


    public void RemoveListenerAll()
    {
        _listeners.Clear();    
    }


    public void RemoveListener<T2,T3>(Action<T3> message)
    {
        string eventName = message.Method.Name;

        Dictionary<Type, List<Delegate>> delegates = null;
        List<Delegate> messages = null;

        if (_listeners.TryGetValue(typeof(T2), out delegates))
        {
            if (delegates.TryGetValue(typeof(T3), out messages))
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].Method.Name.Equals(eventName))
                    {
                        messages.RemoveAt(i);
                    }
                }
            }
        }
    }
}
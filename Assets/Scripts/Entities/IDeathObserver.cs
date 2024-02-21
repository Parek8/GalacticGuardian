using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDeathObserver
{
    public List<ISubscriber> subscribers { get; protected set; }

    internal void Subscribe(ISubscriber subscriber);
    internal void Unsubscribe(ISubscriber subscriber);
    internal void Alert();
}

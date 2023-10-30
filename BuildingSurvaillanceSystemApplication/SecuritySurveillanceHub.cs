using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSurvaillanceSystemApplication
{
    public class SecuritySurveillanceHub : IObservable<ExternalVisitor>
    {
        private List<ExternalVisitor> _externalVisitors = new();
        private List<IObserver<ExternalVisitor>> _observers = new();

        public IDisposable Subscribe(IObserver<ExternalVisitor> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            foreach(var externalVisitor in _externalVisitors)
            { 
                observer.OnNext(externalVisitor);
            }
            // UnSubscriber class implements IDisposable
            return new UnSubscriber<ExternalVisitor>(_observers, observer);
        }

        public void ConfirmExternalVisitorEntersBuilding(ExternalVisitor externalVisitor)
        {
            externalVisitor.InBuilding = true;
            _externalVisitors.Add(externalVisitor);
            NotifyObservers(externalVisitor);
        }

        public void ConfirmExternalVisitorExitsBuilding(int externalVisitorId, DateTime exitDateTime)
        {
            var externalVisitor = _externalVisitors.FirstOrDefault(ev => ev.Id == externalVisitorId);
            if (externalVisitor != null)
            {
                externalVisitor.ExitDateTime = exitDateTime;
                externalVisitor.InBuilding = false;
                NotifyObservers(externalVisitor);
            }
        }

        protected void NotifyObservers(ExternalVisitor externalVisitor)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(externalVisitor);
            }
        }

        public void BuildingEntryCutOffTimeReached()
        {
            foreach(var observer in _observers)
            {
                observer.OnCompleted();
            }
        }

    }
}

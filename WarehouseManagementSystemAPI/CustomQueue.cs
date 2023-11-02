using System;
using System.Collections.Generic;

namespace WarehouseManagementSystemAPI
{
    public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);

    public class CustomQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        private readonly Queue<T> _queue = null;    // FIFO queue
        public event QueueEventHandler<CustomQueue<T>, QueueEventArgs> CustomQueueEvent;
        public int QueueLength
        {
            get
            {
                return _queue.Count;
            }
        }

        public CustomQueue()
        {
            _queue = new();
        }

        public void AddItem(T item)
        {
            _queue.Enqueue(item);
            QueueEventArgs queueEventArgs = new QueueEventArgs
            {
                Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, " +
                $"Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, " +
                $"Quantity: {item.Quantity} has been added to the queue."
            };
            OnQueueChanged(queueEventArgs);
        }

        public T GetItem()
        {
            T item = _queue.Dequeue();
            QueueEventArgs queueEventArgs = new QueueEventArgs
            {
                Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, " +
                $"Id: {item.Id}, Name: {item.Name}, Type: {item.Type}, " +
                $"Quantity: {item.Quantity} has been stored in the designated location."
            };
            OnQueueChanged(queueEventArgs);
            return item;
        }

        protected virtual void OnQueueChanged(QueueEventArgs eventArgs)
        {
            CustomQueueEvent(this, eventArgs);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }
    }
}

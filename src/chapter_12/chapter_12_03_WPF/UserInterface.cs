using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace chapter_12_03_WPF
{
    public class UserInterface : INotifyCompletion
    {
        private Exception _error;
        private Action _continuation;
        private SynchronizationContext _uiContext;
        public UserInterface()
        {
            _uiContext = SynchronizationContext.Current;
        }

        public UserInterface GetAwaiter() => this;
        public UserInterface Task => this;
        public bool IsCompleted => _uiContext == SynchronizationContext.Current;

        void INotifyCompletion.OnCompleted(Action continuation)
        {
            _uiContext.Post(s => ((Action)s)(), continuation);
            //_uiContext.Post(_ => continuation(), null);
        }

        public void GetResult()
        {
        }

        public bool TrySetException(Exception exception)
        {
            if (IsCompleted) return false;
            _error = exception;
            _continuation?.Invoke();
            return true;
        }

        public void Reset()
        {
            _error = null;
            _continuation = null;
        }

        public UserInterface FromException(Exception exception)
        {
            Reset();
            TrySetException(exception);
            return this;
        }

    }

}

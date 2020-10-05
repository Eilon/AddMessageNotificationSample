using System;
using System.Collections.Generic;
using System.Text;

namespace AddMessageNotificationSample
{
    public class AppState
    {
        private readonly List<string> _messages = new List<string>();
        public IReadOnlyList<string> Messages => _messages;

        public void AddMessage(string message)
        {
            // do AddMessage logic here
            _messages.Add(message);

            RaiseOnChange();
        }

        public Action OnChange;

        private void RaiseOnChange()
        {
            OnChange?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShell.Controls
{
    public delegate void RiseMessage(object sender, object args);

    public class SnapManagerMessageQueue : ISnapManagerMessageQueue
    {
        Dictionary<string, List<RiseMessage>> _consumers;

        public SnapManagerMessageQueue()
        {
            _consumers = new Dictionary<string, List<RiseMessage>>();
        }

        public void Publish(string messageName, object args)
        {
            if (_consumers.ContainsKey(messageName))
            {
                foreach (var consumer in _consumers[messageName])
                {
                    consumer(this, args);
                }
            }
        }

        public void Register(string messageName, RiseMessage consumer)
        {
            if (!_consumers.ContainsKey(messageName))
            {
                _consumers.Add(messageName, new List<RiseMessage>());
            }
            _consumers[messageName].Add(consumer);
        }
    }
}

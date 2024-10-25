namespace Ovotan.Shell.RabbitMQ.Controls.Configurations
{
    public class EndPointObjectBrowserTreeItemConfiguration
    {
        public string Header { get; set; }

        public object Data { get; set; }

        public List<EndPointObjectBrowserTreeItemConfiguration> Childen { get; set; }

        public EndPointObjectBrowserTreeItemConfiguration()
        {
            Childen = new List<EndPointObjectBrowserTreeItemConfiguration>();
        }

    }
}

//namespace AppShell.Controls
//{
//    public class SnapPanelManagerTest
//    {
//        ISnapManagerMessageQueue _messageQueue;

//        public SnapPanelManagerTest()
//        {
//            _messageQueue = new SnapManagerMessageQueue();
//        }

//        [Fact]
//        public void Create()
//        {
//            //arrange
//            var snapPanelManager = new SnapPanelManager(_messageQueue);

//            //Assert
//            Assert.NotNull(snapPanelManager.SnapPanel);
//            Assert.NotNull(snapPanelManager.SnapPanel.FirstChild);
//            Assert.Null(snapPanelManager.SnapPanel.SecondChild);
//            Assert.Equal(SnapChildType.Base, snapPanelManager.SnapPanel.FirstChild.ContentType);
//            Assert.Equal(SnapGridType.Default, snapPanelManager.SnapPanel.Type);
//        }
//    }
//}
using AppShell.Controls.Exceptions;
using Moq;

namespace AppShell.Controls.Test
{
    public class SnapPanelChildTest
    {
        readonly Mock<ISnapPanel> _snapPanel;
        readonly Mock<ISnapManagerMessageQueue> _messageQueue;

        public SnapPanelChildTest()
        {
            _snapPanel= new Mock<ISnapPanel>();
            _messageQueue= new Mock<ISnapManagerMessageQueue>();
        }

        [Fact]
        public void Create_With_Null_Parent()
        {
            //Assert
            var arg = Assert.Throws<ArgumentNullException>(() => new SnapPanelChild(null, null));
            Assert.Equal("parent", arg.ParamName);
        }

        [Fact]
        public void Create_With_Null_MessageQueue()
        {
            //Assert
            var arg = Assert.Throws<ArgumentNullException>(() => new SnapPanelChild(_snapPanel.Object, null));
            Assert.Equal("messageQueue", arg.ParamName);
        }

        [Fact]
        public void Create_Success()
        {
            //Action
            var child = new SnapPanelChild(_snapPanel.Object, _messageQueue.Object);

            //Assert
            Assert.Null(child.Child);
            Assert.NotNull(child.Controls);
            Assert.Empty(child.Controls);
            Assert.Equal(SnapSize.Stratch, child.SnapSize);
            Assert.Equal(_snapPanel.Object, child.Parent);
            Assert.Equal(SnapChildType.Base, child.Type);
        }

        [Theory]
        [InlineData(SnapPanelType.Top)]
        [InlineData(SnapPanelType.Left)]
        public void InsertSnapPanel_SecondChild_Base(SnapPanelType type) 
        {
            //Arrange
            var child = new SnapPanelChild(_snapPanel.Object, _messageQueue.Object);

            //Action
            child.AddPanel(type, null);

            //Assert
            Assert.NotNull(child.Child);
        }

        [Theory]
        [InlineData(SnapPanelType.Bottom)]
        [InlineData(SnapPanelType.Right)]
        public void InsertSnapPanel_FirstChild_Base(SnapPanelType type)
        {
            //Arrange
            var child = new SnapPanelChild(_snapPanel.Object, _messageQueue.Object);

            //Action
            child.AddPanel(type, null);

            //Assert
            Assert.NotNull(child.Child);
        }


        //exception when type defauly
    }
}

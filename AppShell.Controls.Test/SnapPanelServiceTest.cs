using AppShell.Controls.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShell.Controls.Test
{
    public class SnapPanelServiceTest
    {
        readonly Mock<ISnapPanel> _snapPanel;
        readonly Mock<ISnapManagerMessageQueue> _messageQueue;
        readonly ISnapPanelService _snapPanelService;

        public SnapPanelServiceTest()
        {
            _snapPanel = new Mock<ISnapPanel>();
            _messageQueue = new Mock<ISnapManagerMessageQueue>();
            _snapPanelService = new SnapPanelService();
        }

        [Fact]
        public void Create_Default()
        {
            //Arrange
            var snapPanel = _snapPanelService.Create(SnapPanelType.Default, _messageQueue.Object, null);

            //Assert
            Assert.NotNull(snapPanel.FirstChild);
            Assert.Null(snapPanel.SecondChild);
            Assert.Equal(SnapChildType.Base, snapPanel.FirstChild.Type);
            Assert.Equal(SnapSize.Stratch, snapPanel.FirstChild.SnapSize);
            Assert.Equal(SnapPanelType.Default, snapPanel.Type);
        }

        [Theory]
        [InlineData(SnapPanelType.Top)]
        [InlineData(SnapPanelType.Left)]
        [InlineData(SnapPanelType.Right)]
        [InlineData(SnapPanelType.Bottom)]
        public void Create_Exception_SnapPanelCreateException(SnapPanelType type)
        {
            //Assert
            Assert.Throws<SnapPanelCreateException>(() => _snapPanelService.Create(type, _messageQueue.Object, null));
        }

        [Theory]
        [InlineData(SnapPanelType.Top)]
        [InlineData(SnapPanelType.Left)]
        public void Create_Top_Left(SnapPanelType type)
        {
            //Arrange
            var child = new SnapPanelChild(_snapPanel.Object, _messageQueue.Object);
            var childType = child.Type;

            //Action
            child.AddPanel(type, null);

            //Assert
            Assert.NotNull(child.Child);
            Assert.NotNull(child.Child.FirstChild);
            Assert.NotNull(child.Child.SecondChild);
            Assert.Equal(child, child.Child.Parent);
            Assert.Equal(childType, child.Child.SecondChild.Type);
            Assert.Equal(SnapChildType.Content, child.Child.FirstChild.Type);
            Assert.Equal(SnapChildType.SnapPanel, child.Type);
            Assert.Equal(SnapSize.Stratch, child.Child.SecondChild.SnapSize);
            Assert.Equal(SnapSize.Percent, child.Child.FirstChild.SnapSize);
        }

        [Theory]
        [InlineData(SnapPanelType.Bottom)]
        [InlineData(SnapPanelType.Right)]
        public void Create_Bottom_Right(SnapPanelType type)
        {
            //Arrange
            var child = new SnapPanelChild(_snapPanel.Object, _messageQueue.Object);
            var childType = child.Type;

            //Action
            child.AddPanel(type, null);

            //Assert
            Assert.NotNull(child.Child);
            Assert.NotNull(child.Child.FirstChild);
            Assert.NotNull(child.Child.SecondChild);
            Assert.Equal(child, child.Child.Parent);
            Assert.Equal(childType, child.Child.FirstChild.Type);
            Assert.Equal(SnapChildType.Content, child.Child.SecondChild.Type);
            Assert.Equal(SnapChildType.SnapPanel, child.Type);
            Assert.Equal(SnapSize.Stratch, child.Child.FirstChild.SnapSize);
            Assert.Equal(SnapSize.Percent, child.Child.SecondChild.SnapSize);
        }

    }
}

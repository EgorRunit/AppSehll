using AppShell.Controls.Exceptions;
using Moq;
using System.Windows.Controls;

namespace AppShell.Controls.Test
{

    public class SnapPanelTest
    {
        Mock<ISnapManagerMessageQueue> _messageQueue;
        Mock<ISnapPanelChild> _child;

        public SnapPanelTest()
        {
            _messageQueue = new Mock<ISnapManagerMessageQueue>();
            _child = new Mock<ISnapPanelChild>();
        }




        [Theory]
        [InlineData(SnapPanelType.Left)]
        [InlineData(SnapPanelType.Top)]
        [InlineData(SnapPanelType.Right)]
        [InlineData(SnapPanelType.Bottom)]
        [InlineData(SnapPanelType.Default)]
        public void Create_Left_Top_Right_Bottom_Default(SnapPanelType type)
        {
            //Arrange
            var snapPanel = new SnapPanel(type, _messageQueue.Object, null);

            //Assert
            Assert.Equal(type, snapPanel.Type);
            Assert.Null(snapPanel.Parent);
        }


        [Theory]
        [InlineData(SnapPanelType.Left)]
        [InlineData(SnapPanelType.Top)]
        [InlineData(SnapPanelType.Right)]
        [InlineData(SnapPanelType.Bottom)]
        public void Create_Left_Top_Right_Bottom_Default_With_Parent(SnapPanelType type)
        {
            //Arrange
            var snapPanel = new SnapPanel(type, _messageQueue.Object, _child.Object);

            //Assert
            Assert.Equal(type, snapPanel.Type);
            Assert.NotNull(snapPanel.Parent);
        }



        //[Theory]
        //[InlineData(SnapPanelType.Left)]
        //[InlineData(SnapPanelType.Right)]
        //[InlineData(SnapPanelType.Top)]
        //[InlineData(SnapPanelType.Bottom)]
        //public void CreateException(SnapPanelType snapGridType)
        //{
        //    //Assert
        //    Assert.Throws<SnapPanelCreateException>(() => SnapPanel.Create(_messageQueue, SnapPanelType.Left, null));
        //}


    }
}

   M S B A M L   `   `   `  ���� H  DDoThingsRight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:DoThingsRight.controls.InfoTextDoThingsRight.controls.InfoText  -clr-namespace:DoThingsRightDoThingsRight  K*clr-namespace:DoThingsRight.controls.CloseDoThingsRight.controls.Close  O,clr-namespace:DoThingsRight.controls.DataOutDoThingsRight.controls.DataOut  Q-clr-namespace:DoThingsRight.controls.ShowDataDoThingsRight.controls.ShowData  I)clr-namespace:DoThingsRight.controls.ExitDoThingsRight.controls.Exit  M+clr-namespace:DoThingsRight.controls.DeleteDoThingsRight.controls.Delete  O,clr-namespace:DoThingsRight.controls.ShuffleDoThingsRight.controls.Shuffle      DoThingsRight.MainWindow   :InfoText-clr-namespace:DoThingsRight.controls.InfoText  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:DoThingsRight     <Close*clr-namespace:DoThingsRight.controls.Close     @DataOut,clr-namespace:DoThingsRight.controls.DataOut     BShowData-clr-namespace:DoThingsRight.controls.ShowData     :Exit)clr-namespace:DoThingsRight.controls.Exit     >Delete+clr-namespace:DoThingsRight.controls.Delete     @Shuffle,clr-namespace:DoThingsRight.controls.Shuffle     -     � Title$  DoThingsRight��$	��520��$	��330������  �� 
TargetType" �.���  �� Property �@�WindowStyle �� Value$
 None=���  �@�AllowsTransparency . ��  � ��
 ���� .��� -    �Name$ MyGrid��$��0q�}�. .+�.   (DoThingsRight.controls.Close.CloseButton  -     Name$ close��.   (DoThingsRight.controls.Close.CloseButton   Click$ close_Click��$��50��$��50�� K� ZIndex$ 2��$y�Hidden=� � Cursor$
 Hand������ 	 �� ImageSource$	 /pic/close.png��F� -   $��ExitPath��
�������
 J� Opacity$
 1Q�$ 1����@� -   ExitEllipse�� @� RadiusX$ 0Q� @� RadiusY ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ RadiusX��� -    ��Name$ 
DataScroll��$ 1��$	��280��$	��430��$
 0Q�$y�Hidden=�.���� -    ��Name$ AllData��$��0��$	��Top=� �� 
LineHeight$ 16������ 2   ,DoThingsRight.controls.DataOut.DataOutButton  -     Name$ 
ExportData��2   ,DoThingsRight.controls.DataOut.DataOutButton   Click$ ExportData_Click��$��Center=�$��Bottom=�$��30��$��30��$ 1��$��10q�
������ $y�Hidden=�$
 Hand������ $	 /pic/dataOut.png���� -	   $ tipText��$
��Tip:�� �� TextAlignment$ Center=�
�������$
 0Q�$��Center=�$��Center=�$	��180��$��17��$ 1������ $	 /pic/tipBlock.png�� j� Stretch$
 Fill=��� -
    ��Name$ 	baseplate�� �� CornerRadius$ 10��$��10q�����  �� 
StartPoint$ 0.5,0&� �� EndPoint$ 0.5,0.1&�.���  � Color$ 	#FFEAF4FF�� � Offset$ 0Q�� $ 	#FFF4F8F9��$ 1Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 0Q�   
BlurRadius$ 10Q�    Color$  #AAAAAA��._�� ! � RowDefinitions! �� $
��auto ��� �� $��20 �.+�� $��2��.+��� $��v1.0.0��$��Right=�$��Center=�$��2q�" � ToolTip$J" D有任何Bug或者提建议欢迎联系，邮箱：1144325768@qq.com��4   .DoThingsRight.controls.ShowData.ShowDataButton  -   #  Name$# showData��4   .DoThingsRight.controls.ShowData.ShowDataButton$   Click$$ showData_Click��$��20��$
��Left=�$��5,0,0,0q�
������ $
 Hand��$" 显示所有数据������ $	 /pic/showData.png��� $��0��.+��� -   $
 time��$��	空闲中��$��Center=�$��Center=��� -   $ myline��$Q" K你不能肯定你做的所有事是Right Things，但是请Do Things Right��$��DoThingsRight��$��Center=�$
��Left=�$��16��$
��auto��$��7q�,   &DoThingsRight.controls.Exit.ExitButton  -   %  Name$
% exit��,	   &DoThingsRight.controls.Exit.ExitButton& 	  Click$& 
exit_Click��$
��Left=�$��	275,2,5,2q�$	��Top=�$��30��$��30��$
 Hand������ $	 /pic/exit.png��  -   $% minimize��$& minimize_Click��$
��Left=�$��
238,2,35,2q�$	��Top=�$��30��$��30��$
 Hand������ $	 /pic/minimize.png��� $��1��$ 0��' � ColumnDefinitions' �� �� $
��auto �.+�� $��0��! �� $
��auto ��� .+��� $��0��( �� Orientation$( 
Horizontal=�.+�  -   $% AddThing��$& AddThing_Click��$��30��$��30��
������ $
 Hand��$$" 添加一个待办，加油！��$��5q����� $	 /pic/add.png��  -   $% StartAndStop��$& StartAndStop_Click��$��30��$��30��
������ $
 Hand��$��5q�$0" *在选择了任务之后开始计时吧！������ $	 /pic/start.png��0
   *DoThingsRight.controls.Delete.DeleteButton
  -   ) 
 Name$) DeleteThing��0   *DoThingsRight.controls.Delete.DeleteButton*   PreviewMouseDoubleClick$)* #DeleteThing_PreviewMouseDoubleClick��$��30��$��30��
������ $
 Hand��$��	100,0,0,0q�$Q" K双击删除所选择的任务，如果没有选择默认删除最后一个������ $	 /pic/delete.png��� $��0��.+�2   ,DoThingsRight.controls.Shuffle.ShuffleButton  -   +  Name$+ RandomChoose��2   ,DoThingsRight.controls.Shuffle.ShuffleButton,   Click$, RandomChoose_Click��$��30��$��30��$��	220,0,0,0q�
������ $
 Hand��$E" ?如果你不确定现在想要做些什么，随机一下吧！������ $	 /pic/shuffle.png��� $��1��' �� $
��auto ��� .+��� -   - ��Name$- checkBoxColumn��$��0���� -   $- textBoxColumn��$��1���� -   $- labelColumn��$��1��.+��� -   . ��Name$. position��$��25��$��25��$��Right=�$��5,7,5,9q�$ 1��$
 Hand��$<" 6可以拖动，拖动至任意一个选项进行操作������ $	 pic/position.png��
   M S B A M L   `   `   `  ����H  DDoThingsRight, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:DoThingsRight.controls.ChooseList!DoThingsRight.controls.ChooseList  5   	   [2clr-namespace:DoThingsRight.controls.DesignedCheck$DoThingsRight.controls.DesignedCheck  6M   Q-clr-namespace:DoThingsRight.controls.InfoTextDoThingsRight.controls.InfoText  5   	   -clr-namespace:DoThingsRightDoThingsRight  5   	   K*clr-namespace:DoThingsRight.controls.CloseDoThingsRight.controls.Close  5	   	   O,clr-namespace:DoThingsRight.controls.DataOutDoThingsRight.controls.DataOut  5
   	   Q-clr-namespace:DoThingsRight.controls.ShowDataDoThingsRight.controls.ShowData  5   	   I)clr-namespace:DoThingsRight.controls.ExitDoThingsRight.controls.Exit  5   	   M+clr-namespace:DoThingsRight.controls.DeleteDoThingsRight.controls.Delete  6@   O,clr-namespace:DoThingsRight.controls.ShuffleDoThingsRight.controls.Shuffle  5   	   O,clr-namespace:DoThingsRight.controls.TipShowDoThingsRight.controls.TipShow  6F       DoThingsRight.MainWindow   5   	   >
ChooseList/clr-namespace:DoThingsRight.controls.ChooseList  DDesignedCheck2clr-namespace:DoThingsRight.controls.DesignedCheck  6M   :InfoText-clr-namespace:DoThingsRight.controls.InfoText  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DoThingsRight     5   	   <Close*clr-namespace:DoThingsRight.controls.Close     5	   	   @DataOut,clr-namespace:DoThingsRight.controls.DataOut     5
   	   BShowData-clr-namespace:DoThingsRight.controls.ShowData     5   	   :Exit)clr-namespace:DoThingsRight.controls.Exit     5   	   >Delete+clr-namespace:DoThingsRight.controls.Delete     6@   @Shuffle,clr-namespace:DoThingsRight.controls.Shuffle     5   	   @tipshow,clr-namespace:DoThingsRight.controls.TipShow     6F   -   5          � Title$  DoThingsRight��5   	   $	��520��6   $	��330��6,   ��5      �� 5   
    �� 
TargetType" �6   .�5      ��  �� Property �@�WindowStyle �� Value$
 None=�6,   �� 5       �@�AllowsTransparency . 63   �� 5       � ��
 ���� 6+   5      .��5      � -   5         �Name$ MyGrid��5      $��0q�6   }�. .+�5   
   .   (DoThingsRight.controls.Close.CloseButton  -   5          Name$ close��5      .   (DoThingsRight.controls.Close.CloseButton   Click$ close_Click��6u   $��50��6+   $��50��66    K� ZIndex$ 2��6B   $y�Hidden=�6S    � Cursor$
 Hand��6g   ��5      �� 5      	 �� ImageSource$	 /pic/close.png��6   5      F� 5   
   -   5        $��ExitPath��5      
�������
 J� Opacity$
 1Q�6,   $ 1��68   ��5      @� 5      -   5        ExitEllipse�� @� RadiusX$ 0Q�5   7    @� RadiusY 6C   ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ RadiusX�5       5"      �� 5$   
   -   5         ��Name$ 
DataScroll��5$      $ 1��6+   $	��280��6<   $	��430��6H   $
 0Q�6U   $y�Hidden=�6a   .��5%      �� -   5         ��Name$ AllData��5%      $��0��6;   $	��Top=�6F    �� 
LineHeight$ 16��5&      ��5%   )   �� 5&      5'      2   ,DoThingsRight.controls.DataOut.DataOutButton  5(   
   -   5          Name$ 
ExportData��5(       2   ,DoThingsRight.controls.DataOut.DataOutButton   Click$ ExportData_Click��5)   j   $��Center=�5(   4   $��Bottom=�6Q   $��30��6l   $��30��6w   $ 1��5)      $��10q�6"   
������ $y�Hidden=�6H   $
 Hand��6\   ��5*      �� 5+      $	 /pic/dataOut.png��6   5-      1   +DoThingsRight.controls.TipShow.TipShowBlock  5/   
   -	   5          Name$ tipText��5/      $
 0Q�50      $y�Hidden=�6    $��Center=�51      $��Center=�6*   $	��190��53      $��18��6    $ 1��6,   54      �� 56   
   -
   5         ��Name$ 	baseplate��56       �� CornerRadius$ 10��6$   $��10q�66   ��57      �� 58       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,0.1&�69   .��59      �  � Color$ 	#FFEAF4FF��6#    � Offset$ 0Q�65   � 5:      $ 	#FFF4F8F9��6#   $ 1Q�65   5;       J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         ShadowDepth$ 0Q�6#      
BlurRadius$ 10Q�63      Color$ #AAAAAA��6C   ._�5B      �   � ShowGridLines  .  ! � RowDefinitions! 5D      �� 5E      $
��auto �6$   �� 5F      $
��auto �6$   �� 5G      �� 5H      $��20 �6$   .+�5K      � $��3��6   .+�5L      �� $��v1.0.0��6    $��Right=�6.   $��Center=�6J   $��2q�6e   " � ToolTip$J" D有任何Bug或者提建议欢迎联系，邮箱：1144325768@qq.com��6p   4   .DoThingsRight.controls.ShowData.ShowDataButton  5M      -   5        #  Name$# showData��5M   .   4   .DoThingsRight.controls.ShowData.ShowDataButton$   Click$$ showData_Click��5O   ?   $��20��5M   @   $
��Left=�6K   $��5,0,0,0q�5N      
������ $
 Hand��6H   $" 显示所有数据��5O   .   ��5P      �� 5Q      $	 /pic/showData.png��6)   5S      5T      � 5W      $��0��6   .+�5X      �� -   5        $ myline��5X       $Q" K你不能肯定你做的所有事是Right Things，但是请Do Things Right��60   $��DoThingsRight��5Y       $��Center=�65   $
��Left=�6P   $��16��6k   $
��auto��5Z       $��7q�6-   �� 5\      -   5        $
 time��5\       $��	空闲中��6.   $��Center=�69   $��Center=�6T   5^      �� 5`      $��0��6   % �� Orientation$% 
Horizontal=�6*   $��RightToLeft=�6C   .+�5a      ,	   &DoThingsRight.controls.Exit.ExitButton	  -   5        & 	 Name$
& exit��5a   &   ,
   &DoThingsRight.controls.Exit.ExitButton' 
  Click$' 
exit_Click��5b   =   $��2q�5a   4   $��30��5b   &   $��30��62   $
 Hand��5c   &   ��5d      �� 5e      $	 /pic/exit.png��6)   5g      	  5i      -   5        $& minimize��5i   &   $' minimize_Click��5j   K   $
��Left=�5i   8   $��2q�6S   $��30��5j   &   $��30��62   $
 Hand��6=   $?" 9隐藏窗口，隐藏后可以在任务栏处双击显示��6b   ��5k      �� 5l      $	 /pic/minimize.png��6)   5n      ;   5DoThingsRight.controls.DesignedCheck.DesignedCheckBox  5p      -   5        (  Name$( 
stayButton��5p   5   ;   5DoThingsRight.controls.DesignedCheck.DesignedCheckBox)   MouseLeftButtonDown$$) stayButton_MouseLeftButtonDown��5u   5   $��5q�5q   5   $��20��6@   $��20��6K   $
 Hand��5r   5   $��Center=�5s   5   $��Center=�5t   5   $" 保持窗口最前端��5v   5   5w      � 5{      $��1��6   .+�5|      �� $% 
Horizontal=�6!   .+�5}      	  -   5        $& AddThing��5}   *   $' AddThing_Click��6m   $��30��6<   $��30��6H   
������ $
 Hand��6�   $$" 添加一个待办，加油！��6�   $��5q�6�   ��5~      �� 5   "   $	 /pic/add.png��6-   5�      	  5�      -   5        $& StartAndStop��5�   *   $' StartAndStop_Click��6q   $��30��6@   $��30��6L   
������ $
 Hand��6�   $��5q�6�   $0" *在选择了任务之后开始计时吧！��6�   ��5�      �� 5�   "   $	 /pic/start.png��6-   5�      0   *DoThingsRight.controls.Delete.DeleteButton  5�      -   5        *  Name$* DeleteThing��5�   .   0   *DoThingsRight.controls.Delete.DeleteButton+   PreviewMouseDoubleClick$)+ #DeleteThing_PreviewMouseDoubleClick��5�   .   $��30��5�   C   $��30��6O   
������ $
 Hand��5�   .   $��	140,0,0,0q�6<   $Q" K双击删除所选择的任务，如果没有选择默认删除最后一个��6O   ��5�      �� 5�   "   $	 /pic/delete.png��6-   5�      5�      2   ,DoThingsRight.controls.Shuffle.ShuffleButton  5�      -   5        ,  Name$, RandomChoose��5�   ,   2   ,DoThingsRight.controls.Shuffle.ShuffleButton-   Click$- RandomChoose_Click��5�   ,   $��30��5�   B   $��30��6N   $��	250,0,0,0q�6Y   
������ $
 Hand��5�   G   $E" ?如果你不确定现在想要做些什么，随机一下吧！��6U   ��5�      �� 5�      $	 /pic/shuffle.png��6)   5�      5�      � 5�      $��2��6   . � ColumnDefinitions. 5�      �� 5�      $
��auto �6+   �� 5�      �� 5�      $
��auto �6+   .+�5�      �� -   5        / ��Name$/ checkBoxColumn��5�   !   $��0��69   5�      �� 5�      -   5        $/ textBoxColumn��5�   !   $��1��68   5�      �� 5�      -   5        $/ chooseButtonColumn��5�   !   $��2��6=   5�      5�      5�      5�      5�      5�      
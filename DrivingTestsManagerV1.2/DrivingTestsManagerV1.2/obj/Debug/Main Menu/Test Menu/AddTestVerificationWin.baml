   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  5   	   _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5   	   I    CDrivingTestsManagerV1._2.Main_Menu.Test_Menu.AddTestVerificationWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  5   	   -   5          � Title$  AddTestVerificationWin��5
   	   $	��400��6(   $	��400��65    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.    � WindowStyle$
 None=�6D   .��5      �� ���	#FF00AEFF$��2q�6%   ._�5   
   �  � RowDefinitions 5      �� 5      $	��10* �6    �� 5      $
��100* �6    .+�5      �� -   5        $��0��5      $��Login��6"   
�������$��14(�6E   
������ $��Center=�6m   $��Center=�6�   ���	#FF00AEFF6�   �� 5      -   5         ��Name$ loginCloseButton��5   "   $��0��6   $��	360,0,0,1q�6<   
������ ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value �	#FF00AEFF67   �� 5       � �� 5      �� 5   "   	 �� 
TargetType"	 ��62   .R�5   &   �� #��z��6-   ._�5   *   �� $��Center=�6;   $��Center=�6X   5   '   5   #   5       
 �� Triggers
 5!      P� 5"       P� Property �@J�IsMouseOver P� Value . . �5#   "   ��  � ��
 �  ��6?   5$      5&      .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	closeIcon��5(   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6=   $��20��6J   $��20��6V   $��Center=�6a   5)      � 5+      $��1��6   .+�5,      �� $��40��6   $!��Verify Details To Continue:��6(   $��18(�6K    �� TextAlignment$ Center=�6Y   $��
0,10,0,314q�6p   �� 5-      $��40��6   $��Trainee's Details:��6$   $��16(�6A   $
��Bold"�6O   $��Center=�6a   $��Bottom=�6�   $��
0,50,0,274q�6�   �� 5.      -   5         ��Name$ traineeDetailsTb��5.      $
��Wrap=�66   $��30��6J   $��58,90,0,244q�6V   �� 5/      $��40��6   $��Tester's Details:��6$   $��16(�6@   $
��Bold"�6N   $��Center=�6`   $��Bottom=�6�   $��0,125,0,199q�6�   �� 50      -   5        $ testerDetailsTb��50      $
��Wrap=�65   $��30��6I   $��58,165,0,169q�6U   �� 51      $��40��6   $��Test Details:��6$   $��16(�6<   $
��Bold"�6J   $��Center=�6\   $��Bottom=�6�   $��0,195,0,129q�6�   �� 52      -   5        $ testDetailsTb��52      $
��Wrap=�63   $��58,235,0,45q�6G   �� 53      -   5        $ addTestButton��53      $��Add Test��60   
��� � �$��40��6V   $��198,320,0,0q�6b   6w   �� 54      -	   5        $ cancelButton��54      $��40��6/   $��Cancel��6;   
���  ��$��0,320,198,0q�6]   6r   55      56      57      58      
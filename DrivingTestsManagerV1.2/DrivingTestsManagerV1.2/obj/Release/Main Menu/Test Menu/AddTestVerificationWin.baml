   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  I    CDrivingTestsManagerV1._2.Main_Menu.Test_Menu.AddTestVerificationWin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  -     � Title$  AddTestVerificationWin��$	��400��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.���� ���	#FF00AEFF$��2q�._��  � RowDefinitions �� $	��10* ��� $
��100* �.+��� -   $��0��$��Login��
�������$��14(�
������ $��Center=�$��Center=����	#FF00AEFF�� -    ��Name$ loginCloseButton��$��0��$��	360,0,0,1q�
������ ����  �� 
TargetType" ��.���  �� Property � �� �� Value �	#FF00AEFF��  � �� �� 	 �� 
TargetType"	 ��.R��� #��z��._��� $��Center=�$��Center=�
 �� Triggers
 P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �  ��.��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	closeIcon���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��20��$��20��$��Center=�� $��1��.+��� $��40��$!��Verify Details To Continue:��$��18(� �� TextAlignment$ Center=�$��
0,10,0,314q��� $��40��$��Trainee's Details:��$��16(�$
��Bold"�$��Center=�$��Bottom=�$��
0,50,0,274q��� -    ��Name$ traineeDetailsTb��$
��Wrap=�$��30��$��58,90,0,244q��� $��40��$��Tester's Details:��$��16(�$
��Bold"�$��Center=�$��Bottom=�$��0,125,0,199q��� -   $ testerDetailsTb��$
��Wrap=�$��30��$��58,165,0,169q��� $��40��$��Test Details:��$��16(�$
��Bold"�$��Center=�$��Bottom=�$��0,195,0,129q��� -   $ testDetailsTb��$
��Wrap=�$��58,235,0,45q��� -   $ addTestButton��$��Add Test��
��� � �$��40��$��198,320,0,0q��� -	   $ cancelButton��$��40��$��Cancel��
���  ��$��0,320,198,0q�
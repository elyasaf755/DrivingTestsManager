   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Home_Menu,DrivingTestsManagerV1._2.Main_Menu.Home_Menu  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  ;    5DrivingTestsManagerV1._2.Main_Menu.Home_Menu.LoginWin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Home_Menu     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  -     �Name$  loginWin�� � Title$ LoginWin��$	��400��$	��400�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.���� ���	#FF00AEFF$��2q�._��  � RowDefinitions �� $	��10* ��� $
��100* �.+��� -   $��0��$��Login��
�������$��14(�
������ $��Center=�$��Center=����	#FF00AEFF�� -    ��Name$ loginCloseButton��$��0��$��	360,0,0,1q�
������ ����  �� 
TargetType" ��.���  �� Property � ��	 �� Value	 �	#FF00AEFF��  � ��	 �� 
 �� 
TargetType"
 ��.R��� #��z��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
	 �  ��.��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	closeIcon���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��20��$��20��$��Center=�� $��1��.+��� $��40��$��Welcome!��$��18(� �� TextAlignment$ Center=�$��
0,20,0,304q�=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -     Name$
 idTb��   Hint$ Id��$��30��   IsValidatorVisible .  $��120,60,85,260q��� -    ��Name$ passwordHintLabel��$��Password��
�������$��Center=�$��120,110,120,220q�G� -    G�Name$ 
passwordPb��$��120,105,120,215q�$��30���� -   $ loginButton��$��40��$��Login��$��120,162q��� $*��$Don't have an account? Register now!��$ Center=�$��30��$��
0,290,0,40q��� -	   $ registerButton��$��Register��
��� � �$��40��$��	0,320,0,0q�
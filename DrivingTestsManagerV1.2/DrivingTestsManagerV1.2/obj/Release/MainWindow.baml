   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DrivingTestsManagerV1._2DrivingTestsManagerV1._2  )    #DrivingTestsManagerV1._2.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:DrivingTestsManagerV1._2     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     �Name$  MyMainWindow�� � Title$ 
MainWindow��
������� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�$	��600��$
��1080�� � 	Resources    MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime	 O� Value  	MenuClose  HomeMenuOpen  HomeMenuClose  TesterMenuOpen  TesterMenuClose  TraineeMenuOpen  TraineeMenuClose  TestMenuOpen 	 TestMenuClose��%�  &	        &	 r     &	 �     &	 Y    &	 �    &	 E    &	 �    &	 4    &	 �    &		 !    �� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$	 60Q�  $ 0:0:0.25��$		 150Q��� .��U� $ (FrameworkElement.Width)�$ GridMenu��.\�  $ 0��$		 150Q�  $ 0:0:0.25��$	 60Q��� .��U� $ (FrameworkElement.Width)�$ GridHomeMenu��.\�  $ 0��$	 0Q�  $ 0:0:0.25��$		 180Q��� .��U� $ (FrameworkElement.Width)�$ GridHomeMenu��.\�  $ 0��$		 180Q�  $ 0:0:0.25��$	 0Q��� .��U� $ (FrameworkElement.Width)�$ GridTesterMenu��.\�  $ 0��$	 0Q�  $ 0:0:0.25��$		 180Q��� .��U� $ (FrameworkElement.Width)�$ GridTesterMenu��.\�  $ 0��$		 180Q�  $ 0:0:0.25��$	 0Q��� .��U� $ (FrameworkElement.Width)�$ GridTraineeMenu��.\�  $ 0��$	 0Q�  $ 0:0:0.25��$		 180Q��� .��U� $ (FrameworkElement.Width)�$ GridTraineeMenu��.\�  $ 0��$		 180Q�  $ 0:0:0.25��$	 0Q��� .��U� $ (FrameworkElement.Width)�$ GridTestMenu��.\�  $ 0��$	 0Q�  $ 0:0:0.25��$		 180Q��� .��U� $ (FrameworkElement.Width)�$ GridTestMenu��.\�  $ 0��$		 180Q�  $ 0:0:0.25��$	 0Q�
 � Triggers
 :�  :� RoutedEvent$ ButtonBase.Click�� :� 
SourceName$ ButtonOpenMenu��.[��� #��[  :� $ ButtonBase.Click��$ ButtonCloseMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonOpenHomeMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonCloseHomeMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonOpenTesterMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonCloseAddMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonOpenTraineeMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonCloseTraineeMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonOpenTestMenu��.[��� #��[ :� $ ButtonBase.Click��$ ButtonCloseTestMenu��.[��� #��[	 .���� ���	#FF00AEFF$��2q�._�� -    �Name$ MainGrid��
�������.+� � -     �Name$ 	MainFrame��$
��Left=�$	��536��$��	60,60,0,0q�$	��Top=�$
��1016��  � NavigationUIVisibility$ Hidden=�� $��60��$	��Top=����	#FF00AEFF.+��� -   $��Driving Tests Manager��
�������$��22(�$��60��$
��1080��$��Center=�$��Center=�$��Center=�$��Center=��� $��Center=� �� Orientation$ 
Horizontal=�$��Right=�.+��� -    ��Name$ Header��$��Elyasaf Elbaz��$��Center=�$��18(�'  !MaterialDesignThemes.Wpf.PopupBox  $��10q�   PlacementMode$ BottomAndAlignRightEdges=�   	StaysOpen .    PopupContent. �� $	��150��.+��� $��Account���� -    ��Name$ settingsButton��$��Settings���� $
��Help���� �� -   $ ButtonPopUpLogout��$��Logout���� -   $��CloseIconItem��$��60��$��60�����	#FF00AEFF.���� $ 
Horizontal=�.+�'  !MaterialDesignThemes.Wpf.PackIcon  -	   $��	CloseIcon���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�$��40��$��40��
���   �$��2q�� -
   $ GridMenu��$��60��$
��Left=����	#FF0068FF.+��� .+�� $��60��
�������.+��� -   $ ButtonCloseMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=���Z� ��Z� .��  ���	#FF0068FF$ 	ArrowLeft=�$��25��$��25���� -   $ ButtonOpenMenu��$��60��$��60��$	��Top=�$��Right=���Z� ��Z� .��  ���	#FF0068FF$
 Menu=�$��25��$��25���� $��Disabled=����	#FF0068FF.@��� $ 
Horizontal=�.+�� $��42��$��1q�.+��� -   $ ButtonOpenHomeMenu��$��60��$��60��$	��Top=�$��Stretch=�$��-10,-8,-3,0q���Z� ��Z� .��  
�������$
 Home=�$��25��$��25��$��Center=�$��Center=��� $
��Home��$��13(�$��Center=�
��������� $ 
Horizontal=�.+�� $��42��$��1q�.+��� -   $ ButtonOpenTesterMenu��$��60��$��60��$	��Top=�$��Stretch=�$��-10,-8,-3,0q���Z� ��Z� .��  
�������$ Teacher=�$��25��$��25��$��Center=�$��Center=��� $	��Add��$��13(�$��
8, 0, 0, 0q�$��Center=�$��Center=�
��������� $ 
Horizontal=�.+�� $��42��$��1q�.+��� -   $ ButtonOpenTraineeMenu��$��60��$��60��$	��Top=�$��Stretch=�$��-10,-8,-3,0q���Z� ��Z� .��  
�������$
 User=�$��25��$��25��$��Center=�$��Center=��� $
��Edit��$��13(�$��
8, 0, 0, 0q�$��Center=�$��Center=�
��������� $ 
Horizontal=�.+�� $��42��$��1q�.+��� -   $ ButtonOpenTestMenu��$��60��$��60��$	��Top=�$��Stretch=�$��-10,-8,-3,0q���Z� ��Z� .��  
�������$
 Note=�$��25��$��25��$��Center=�$��Center=��� $��Delete��$��13(�$��Center=�$��Center=�
�������� -   $ GridHomeMenu��$��0��$
��Left=����	#FF0068FF$��60 60 0 300q� � RowDefinitions �� $��5* ��� $	��19* �.+��� $��2��.+�� $��60�����	#FFB1E6FF �� $��9* ��� .+��� -   $ ButtonCloseHomeMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=�$��2����Z� ��Z� .��  ���	#FF0068FF$ 	ArrowLeft=�$��25��$��25���� $��Disabled=����	#FF0068FF.@��� -    ��Name$ ShowTestersItem��$��60��
�������.���� $ 
Horizontal=�.+�  $ Teacher=�$��10q�$��25��$��25��$��Center=��� $��Show All Testers��$��Center=�$��20 10q��� -   $ ShowTrainees��$��60��
�������.���� $ 
Horizontal=�.+�  $ Users=�$��10q�$��25��$��25��$��Center=��� $��Show All Trainees��$��Center=�$��20 10q��� -   $ 	ShowTests��$��60��
�������.���� $ 
Horizontal=�.+�  $ Events=�$��10q�$��25��$��25��$��Center=��� $��Show All Tests��$��Center=�$��20 10q��� $��60��
�������.���� $ 
Horizontal=�.+�  $ Delete=�$��10q�$��25��$��25��$��Center=��� $��Delete��$��Center=�$��20 10q�� -   $ GridTesterMenu��$��0��$
��Left=����	#FF0068FF$��60,120,0,296q� �� $��5* ��� $	��19* �.+��� $��2��.+�� $��60�����	#FFB1E6FF �� $��9* ��� .+��� -   $ ButtonCloseAddMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=�$��2����Z� ��Z� .��  ���	#FF0068FF$ 	ArrowLeft=�$��25��$��25���� $��Disabled=����	#FF0068FF.@��� -   $ ShowAllTestersItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Show=�$��10q�$��25��$��25��$��Center=��� $��Show All Testers��$��Center=�$��20 10q��� -   $ AddTesterItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Plus=�$��10q�$��25��$��25��$��Center=��� $��Add a Tester��$��Center=�$��20 10q�� -   $ GridTraineeMenu��$��0��$
��Left=����	#FF0068FF$��60,180,0,236q� �� $��5* ��� $	��19* �.+��� $��2��.+�� $��60�����	#FFB1E6FF �� $��9* ��� .+��� -   $ ButtonCloseTraineeMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=�$��2����Z� ��Z� .��  ���	#FF0068FF$ 	ArrowLeft=�$��25��$��25���� $��Disabled=����	#FF0068FF.@��� -   $ ShowAllTraineesItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Show=�$��10q�$��25��$��25��$��Center=��� $��Show All Trainees��$��Center=�$��20 10q��� -   $ AddTraineeItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Plus=�$��10q�$��25��$��25��$��Center=��� $��Add a Trainee��$��Center=�$��20 10q�� -   $ GridTestMenu��$��0��$
��Left=����	#FF0068FF$��60,240,0,176q� �� $��5* ��� $	��19* �.+��� $��2��.+�� $��60�����	#FFB1E6FF �� $��9* ��� .+��� -   $ ButtonCloseTestMenu��$��60��$��60��$	��Top=�$��Right=�$y�	Collapsed=�$��2����Z� ��Z� .��  ���	#FF0068FF$ 	ArrowLeft=�$��25��$��25���� $��Disabled=����	#FF0068FF.@��� -    $ ShowAllTestsItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Show=�$��10q�$��25��$��25��$��Center=��� $��Show All Tests��$��Center=�$��20 10q��� -!   $ AddTestItem��$��60��
�������.���� $ 
Horizontal=�.+�  $
 Plus=�$��10q�$��25��$��25��$��Center=��� $��
Add a Test��$��Center=�$��20 10q�
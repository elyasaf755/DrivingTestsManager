   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  5      = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5      G    ADrivingTestsManagerV1._2.Main_Menu.Test_Menu.PotentialTestersView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     5      +BEclr-namespace:BE;assembly=BE     5      NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
      Ixcad19http://schemas.microsoft.com/netfx/2009/xaml/presentation    5      Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5      -   5          N�Name$  MyPotentialTestersView��5       N� Title$ PotentialTestersView��5       � 	Resources 5         testerViewSource��%   &	        �� 5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��800* �6   �� 5      $
��220* �6   .+�5   
   � $��0��6   $��Stretch=�6b   $��Stretch=�6�    � DataContext 6   ��  �� ElementName$ MyPotentialTestersView�� �� Path$ .�.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ testerDataGrid��5         
IsReadOnly . $	��800��6A   	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6M   
   EnableRowVirtualization
 .    AutoGenerateColumns .  ��5      �� *TestersCollection+ �� 
GroupStyle 5       (  "System.Windows.Controls.GroupStyle  5!         HeaderTemplate 5"      �� 5#      .R�5$   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5%   &   �� ��60   �� $
 Name�5&   #   5'         ContainerStyle 5)      �� 5*       �� 
TargetType" ��6$   .�5+   "   ��  �� Property � �� �� Value 5,   &   �� 5-   *    �� 
TargetType" ��6:   .R�5.   .   9� ��5/   2   �� 50   6   $ 
Horizontal=�6A   .+�51   :   �� $ 
Horizontal=�6E   $��
0, 0, 0, 0q�6^   .+�52   >   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowDown=�6V   �� 53   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 54   >   $��(��6H   �� 55   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 56   >   $��	Trainees)��6H   57   ;   �� 58   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�59   >     $ 	ArrowDown=�6V   �� 5:   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5;   >   $��(��6H   �� 5<   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5=   >   $��	Trainees)��6H   5>   ;   �� 5?   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5@   >     $ 	ArrowDown=�6V   �� 5A   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5B   >   $��(��6H   �� 5C   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5D   >   $��	Trainees)��6H   5E   ;   �� 5F   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5G   >     $ 	ArrowDown=�6V   �� 5H   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5I   >   $��(��6H   �� 5J   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5K   >   $��	Trainees)��6H   5L   ;   �� 5M   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5N   >     $ 	ArrowDown=�6V   �� 5O   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5P   >   $��(��6H   �� 5Q   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5R   >   $��	Trainees)��6H   5S   ;   5T   7   .��5V   2   �� 5W   /   5X   +   5Z   #   5[      5]       � ContextMenu 5a      �� 5b      .@�5c      m� -   5         m�Name$ SelectTesterCmi��5c   #   $��Select This Tester��6<    m� Icon 5d        5e   "   $ Check=�6:   5g      5h         Columns 5k      0  *System.Windows.Controls.DataGridTextColumn  5l      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5l   ;      Header$ Id��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   �� *Id+  5m      -   5        firstNameColumn��$ SizeToHeader 5m   B   $ 
First Name��6W    6k   �� *	FirstName+  5n      -   5        lastNameColumn��$ SizeToHeader 5n   A   $ 	Last Name��6V    6i   �� *
LastName+  5o      -   5        genderColumn��$ SizeToHeader 5o   ?   $ Gender��6T    6d   �� *Gender+  5p      -   5        dateOfBirthColumn��$ SizeToHeader 5p   D   $ Date Of Birth��6Y      
IsReadOnly .  6p   �� *DateOfBirthStringFormat+6�     5q      -	   5        	ageColumn��$ SizeToHeader 5q   <   $	 Age��6Q    6^   �� *Age+  5r      -
   5        addressColumn��$ SizeToCells 5r   @   $ Address��6T    6e   �� *AddressStringFormat+  5s      -   5        phoneNumberColumn��$ SizeToHeader 5s   D   $ Phone Number��6Y    6o   �� *PhoneNumber+  5t      -   5        emailAddressColumn��$ SizeToCells 5t   E   $ Email Address��6Y    6p   �� *EmailAddress+  5u      -   5        carTypeColumn��$ SizeToHeader 5u   @   $ Car Type��6U    6g   �� *	CarType+  5v      -   5        maximalDistanceColumn��$ SizeToHeader 5v   H   $ 
Max. Dist.��6]    6q   �� *MaximalDistance+  5w      -   5        weeklyTestsCountColumn��$ SizeToHeader 5w   I   $ Weekly Tests��6^    6t   �� *WeeklyTestsCount+  5x      -   5        maximalWeeklyTestsColumn��$ SizeToHeader 5x   K   $ Max. Weekly Tests��6`    6{   �� *MaximalWeeklyTests+  5y      -   5        yearsOfExperienceColumn��$ SizeToHeader 5y   J   $ Exp. (Years)��6_    6u   �� *YearsOfExperience+5{      5|      �� 5~   
   
���   �$��1q�6%   $��1��69   ._�5      � -   5         �Name$ 
FilterGrid��5      $��1��6'   
�������$��Stretch=�6J   $��Stretch=�6h   .+�5�      �� $��Find Potential Testers��6   $��14(�69   $
��Bold"�6G   $��30��6Y   $	��218��6e   $��	0,0,0,508q�6q   $��Center=�6�   $��Center=�6�   �� 5�      $��Trainee Details:��6   $��12(�63   $
��Bold"�6A   $��30��6S   $	��218��6_   $��
0,30,0,478q�6k   $��Center=�6   $��Center=�6�   $��Bottom=�6�   =	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  5�      -   5         	 Name$ traineeIdTb��5�   1   =
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox 
  TextChanged$ TraineeId_TextChanged��6�     	  Hint$  
Trainee Id��6F   ! 	  IsValidatorVisible! . $��10,65,118,444q�6r   6�   	  5�      -   5        $ traineeNameTb��5�   1   $  Trainee Full Name��6H   ! .  {�.  $��10,95,10,413q�6�   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5�      -   5        "  Name$" traineeCarTypeCb��5�   2   #   Hint$# Car Type��6L   $
��auto��6\   $   IsValidatorVisible$ .  {�.  $��10,130,118,378q�6�     5�      -   5        $" DMVCb��5�   2   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox%   SelectionChanged$% DMVCb_SelectionChanged��6d   $# D.M.V��6A   $��10,160,0,342q�6N   6d   �� 5�      $��Test Details:��6   $��12(�60   $
��Bold"�6>   $��30��6P   $	��218��6\   $��2,196,-2,312q�6h   $��Center=�6~   $��Center=�6�   $��Bottom=�6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5�      -   5        &  Name$& testDateTimeDtp��5�   &   ' � ToolTip$%' Choose a date and time for test��6?   $��Center=�6i   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase(   	Watermark$( Test Date And Time��6�   $��0,224,30,284q�6�   )   CalendarWidth$	) 250Q�6�   6o  <   6DrivingTestsManagerV1._2.User_Controls.CircleValidator  5�      -   5        *  Name$* testDateTimeValidator��5�   0   $��30��6O   $��188,224,0,284q�6Z     5�      -   5        $" 
testCityCb��5�   2   +   DropDownOpened$+ TestCity_DropDownOpened��6�   $% TestCity_SelectionChanged��6�   $# עיר��6F   $
��auto��6Q   $ .  $��10,259,107,249q�6z   6�     5�      -   5        $" testStreetCb��5�   2   $+ TestStreet_DropDownOpened��6�   $!% TestStreet_SelectionChanged��6�   $# רחוב��6H   $
��auto��6T   $ .  $��111,259,17,249q�6}   6�   �� 5�      -   5        , ��Name$, testersInRangeButton��5�      $��Find Testers In Range��67   $
��Auto��6W   {�.  $��0,291,0,212q�6w   6�   �� 5�      $��
Distances:��6   $��Center=�6-   $��Bottom=�6Q   $��30��6s   $��0,368,0,140q�6   	  5�      -   5        $ 
distanceTb��5�   1   $ DistanceTb_TextChanged��6�   - 	  IsHintVisible- . ! .  $  Distance From Trainee��6u   {�.  $��30��6�   $��0,398,0,110q�6�   6�   	  5�      -   5        $ testerDistanceTb��5�   1   $ DistanceTb_TextChanged��6�   - . ! .  $  Distance From Tester��6{   {�.  $��30��6�   $��
0,428,0,80q�6�   6�   "  FontAwesome.WPF.ImageAwesome  5�      -   5        .  Name$. distanceSpinner��5�   "   $��30��6;   $y�Hidden=�6G   /   
Foreground
/ � � �0   Icon$0 Spinner=�6n   1   Spin1 .  2   SpinDuration$2 2Q�6�   $��190,383,-2,125q�6�   �� 5�      -   5        $, findClosetTesterButton��5�      $
��Auto��69   $��Find Closest Tester��6G   {�.  
��� ���$��0,331,0,170q�6�   6�   �� 5�      -    5        $, selectTesterButton��5�      $��Select Tester��65   {�.  
��� � �$��40��6r   $��
0,458,0,40q�6~   6�   �� 5�      -!   5        $, ClearFieldsButton��5�      $��Clear Fields��64   
���  ��$��	0,498,0,0q�6\   $
��Auto��6o   6}   5�      5�      5�      5�      
   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  G    ADrivingTestsManagerV1._2.Main_Menu.Test_Menu.PotentialTestersView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     +BEclr-namespace:BE;assembly=BE     NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  Ixcad19http://schemas.microsoft.com/netfx/2009/xaml/presentation    Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  -     N�Name$  MyPotentialTestersView�� N� Title$ PotentialTestersView�� � 	Resources    testerViewSource��%   &	        �� .���  � ColumnDefinitions �� $
��800* ��� $
��220* �.+�� $��0��$��Stretch=�$��Stretch=� � DataContext ��  �� ElementName$ MyPotentialTestersView�� �� Path$ .�.+�&   System.Windows.Controls.DataGrid  -     Name$ testerDataGrid��   
IsReadOnly . $	��800��	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�
   EnableRowVirtualization
 .    AutoGenerateColumns .  ���� *TestersCollection+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� ���� $
 Name�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ���� $ 
Horizontal=�.+��� $ 
Horizontal=�$��
0, 0, 0, 0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)��.����  � ContextMenu �� .@�m� -    m�Name$ SelectTesterCmi��$��Select This Tester�� m� Icon   $ Check=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  -   firstNameColumn��$ SizeToHeader $ 
First Name�� �� *	FirstName+  -   lastNameColumn��$ SizeToHeader $ 	Last Name�� �� *
LastName+  -   genderColumn��$ SizeToHeader $ Gender�� �� *Gender+  -   dateOfBirthColumn��$ SizeToHeader $ Date Of Birth��   
IsReadOnly .  �� *DateOfBirthStringFormat+  -	   	ageColumn��$ SizeToHeader $	 Age�� �� *Age+  -
   addressColumn��$ SizeToCells $ Address�� �� *AddressStringFormat+  -   phoneNumberColumn��$ SizeToHeader $ Phone Number�� �� *PhoneNumber+  -   emailAddressColumn��$ SizeToCells $ Email Address�� �� *EmailAddress+  -   carTypeColumn��$ SizeToHeader $ Car Type�� �� *	CarType+  -   maximalDistanceColumn��$ SizeToHeader $ 
Max. Dist.�� �� *MaximalDistance+  -   weeklyTestsCountColumn��$ SizeToHeader $ Weekly Tests�� �� *WeeklyTestsCount+  -   maximalWeeklyTestsColumn��$ SizeToHeader $ Max. Weekly Tests�� �� *MaximalWeeklyTests+  -   yearsOfExperienceColumn��$ SizeToHeader $ Exp. (Years)�� �� *YearsOfExperience+�� 
���   �$��1q�$��1��._�� -    �Name$ 
FilterGrid��$��1��
�������$��Stretch=�$��Stretch=�.+��� $��Find Potential Testers��$��14(�$
��Bold"�$��30��$	��218��$��	0,0,0,508q�$��Center=�$��Center=��� $��Trainee Details:��$��12(�$
��Bold"�$��30��$	��218��$��
0,30,0,478q�$��Center=�$��Center=�$��Bottom=�=	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  -    	 Name$ traineeIdTb��=
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox 
  TextChanged$ TraineeId_TextChanged��  	  Hint$  
Trainee Id��! 	  IsValidatorVisible! . $��10,65,118,444q�	  -   $ traineeNameTb��$  Trainee Full Name��! .  {�.  $��10,95,10,413q�>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -   "  Name$" traineeCarTypeCb��#   Hint$# Car Type��$
��auto��$   IsValidatorVisible$ .  {�.  $��10,130,118,378q�  -   $" DMVCb��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox%   SelectionChanged$% DMVCb_SelectionChanged��$# D.M.V��$��10,160,0,342q��� $��Test Details:��$��12(�$
��Bold"�$��30��$	��218��$��2,196,-2,312q�$��Center=�$��Center=�$��Bottom=�&   Xceed.Wpf.Toolkit.DateTimePicker  -   &  Name$& testDateTimeDtp��' � ToolTip$%' Choose a date and time for test��$��Center=�,  &Xceed.Wpf.Toolkit.Primitives.InputBase(   	Watermark$( Test Date And Time��$��0,224,30,284q�)   CalendarWidth$	) 250Q�<   6DrivingTestsManagerV1._2.User_Controls.CircleValidator  -   *  Name$* testDateTimeValidator��$��30��$��188,224,0,284q�  -   $" 
testCityCb��+   DropDownOpened$+ TestCity_DropDownOpened��$% TestCity_SelectionChanged��$# עיר��$
��auto��$ .  $��10,259,107,249q�  -   $" testStreetCb��$+ TestStreet_DropDownOpened��$!% TestStreet_SelectionChanged��$# רחוב��$
��auto��$ .  $��111,259,17,249q��� -   , ��Name$, testersInRangeButton��$��Find Testers In Range��$
��Auto��{�.  $��0,291,0,212q��� $��
Distances:��$��Center=�$��Bottom=�$��30��$��0,368,0,140q�	  -   $ 
distanceTb��$ DistanceTb_TextChanged��- 	  IsHintVisible- . ! .  $  Distance From Trainee��{�.  $��30��$��0,398,0,110q�	  -   $ testerDistanceTb��$ DistanceTb_TextChanged��- . ! .  $  Distance From Tester��{�.  $��30��$��
0,428,0,80q�"  FontAwesome.WPF.ImageAwesome  -   .  Name$. distanceSpinner��$��30��$y�Hidden=�/   
Foreground
/ � � �0   Icon$0 Spinner=�1   Spin1 .  2   SpinDuration$2 2Q�$��190,383,-2,125q��� -   $, findClosetTesterButton��$
��Auto��$��Find Closest Tester��{�.  
��� ���$��0,331,0,170q��� -    $, selectTesterButton��$��Select Tester��{�.  
��� � �$��40��$��
0,458,0,40q��� -!   $, ClearFieldsButton��$��Clear Fields��
���  ��$��	0,498,0,0q�$
��Auto��
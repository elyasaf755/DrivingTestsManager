   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu.DrivingTestsManagerV1._2.Main_Menu.Tester_Menu  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE D    >DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TesterEditPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Nlocal<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu     NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     +BEclr-namespace:BE;assembly=BE     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  -     N�Name$  MyTesterEditPage�� N� Title$ TesterEditPage�� � 	Resources    testerViewSource��%   &	        �� .���  � ColumnDefinitions �� $
��800* ��� $
��220* �.+�� $��0��$��Stretch=�$��Stretch=� � DataContext ��  �� ElementName$ MyTesterEditPage�� �� Path$ .�.+�&   System.Windows.Controls.DataGrid  -     Name$ testerDataGrid��   
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
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)��.����  � ContextMenu �� .@�m� -    m�Name$ WorkTimeCmi��$��Show Work Time�� m� Icon   $
 Show=��� m� -   $ AddCmi��$��Add a New Tester��   $
 Plus=�m� -   $ EditCmi��$
��Edit��   $
 Edit=�m� -   $ 	RemoveCmi��$��Remove��   $ Trash=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  -   firstNameColumn��$ SizeToHeader $ 
First Name�� �� *	FirstName+  -	   lastNameColumn��$ SizeToHeader $ 	Last Name�� �� *
LastName+  -
   genderColumn��$ SizeToHeader $ Gender�� �� *Gender+  -   dateOfBirthColumn��$ SizeToHeader $ Date Of Birth��   
IsReadOnly .  �� *DateOfBirthStringFormat+  -   	ageColumn��$ SizeToHeader $	 Age�� �� *Age+  -   addressColumn��$ SizeToCells $ Address�� �� *AddressStringFormat+  -   phoneNumberColumn��$ SizeToHeader $ Phone Number�� �� *PhoneNumber+  -   emailAddressColumn��$ SizeToCells $ Email Address�� �� *EmailAddress+  -   carTypeColumn��$ SizeToHeader $ Car Type�� �� *	CarType+  -   maximalDistanceColumn��$ SizeToHeader $ 
Max. Dist.�� �� *MaximalDistance+  -   weeklyTestsCountColumn��$ SizeToHeader $ Weekly Tests�� �� *WeeklyTestsCount+  -   maximalWeeklyTestsColumn��$ SizeToHeader $ Max. Weekly Tests�� �� *MaximalWeeklyTests+  -   yearsOfExperienceColumn��$ SizeToHeader $ Exp. (Years)�� �� *YearsOfExperience+�� 
���   �$��1q�$��1��._�� -    �Name$ 
FilterGrid��$��1��
�������$��Stretch=�$��Stretch=�.+��� $��
Filter By:��$��14(�$
��Bold"�$��30��$	��140��$��36,10,42,498q�$��Center=�$��Center=�=	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  -    	 Name$ IdFilter��=
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox 
  TextChanged$ TextChanged��  	  Hint$  Id��! 	  IsValidatorVisible! .  $��10,45,118,464q�	  -   $ firstNameFilter��$ TextChanged��$  
First Name��! .  $��10,79,118,429q�	  -   $ lastNameFilter��$ TextChanged��$  	Last Name��$
��auto��! .  $��100,79,28,429q�>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -   "  Name$" genderFilter��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox#   SelectionChanged$# SelectionChanged��$   Hint$$ Gender��$
��auto��$��10,114,118,394q�%   IsValidatorVisible% .  	  -   $ 	ageFilter��$ TextChanged��$	  Age��$
��auto��! .  $��100,114,73,394q�	  -   $ 	dayFilter��$ TextChanged��$	  Day��& 	  
MaxLengeth$& 2��$
��auto��! .  $��10,149,158,359q��� $��/��$��30��$��52,149,151,359q�	  -   $ monthFilter��$ TextChanged��$  Month��$& 2��$
��auto��! .  $��66,149,97,359q��� $��/��$��30��$��113,150,90,358q�	  -   $ 
yearFilter��$ TextChanged��$
  Year��$& 4��$
��auto��! .  $��132,149,16,359q�	  -   $ 
cityFilter��$ TextChanged��$
  City��$
��auto��! .  $��10,184,118,324q�	  -   $ streetFilter��$ TextChanged��$  Street��$
��auto��! .  $��86,184,42,324q�	  -    $ buildingFilter��$ TextChanged��$  Building��$
��auto��! .  $��162,184,-10,324q�  -!   $" carTypeFilter��$# SelectionChanged��$$ Car Type��$
��auto��$��10,219,118,289q�% .  	  -"   $ emailAddressFilter��$ TextChanged��$  Email Address��$
��auto��$	��180��! .  $��10,254,28,254q�	  -#   $ phoneNumberFilter��$ TextChanged��$  Phone Number��$
��auto��$	��180��! .  $��10,289,28,219q�	  -$   $ maxDistFilter��$ TextChanged��$  Max. Distance��$
��auto��! .  $��10,324,103,184q�	  -%   $ experienceFilter��$ TextChanged��$  
Experience��$
��auto��! .  $��103,324,10,184q�	  -&   $ weeklyTestsCountFilter��$ TextChanged��$  # Weekly Tests��$
��auto��! .  $��10,359,98,149q�	  -'   $ maxWeeklyTestsFilter��$ TextChanged��$  Max. Weekly Tests��$
��auto��! .  $��103,359,-15,149q��� -(   ' ��Name$' IsGroupingEnabledCheckBox��$��Enable Groups��$��30��$��10,394,108,114q��� -)   ( ��Name$( ClearFiltersButton��$��Clear Filters��$��	0,498,0,0q�$
��Auto��
   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu/DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu  = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  E    ?DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TraineeEditPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Olocal=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu     +BEclr-namespace:BE;assembly=BE     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  -     N�Name$  MyTraineeEditPage�� N� Title$ TraineeEditPage�� � 	Resources    traineeViewSource��%   &	        �� .���  � ColumnDefinitions �� $
��800* ��� $
��220* �.+�� $��0��$��Stretch=�$��Stretch=� � DataContext ��  �� ElementName$ MyTraineeEditPage�� �� Path$ .�.+�&   System.Windows.Controls.DataGrid  -     Name$ traineeDataGrid��   
IsReadOnly . 	   CanUserSortColumns	 . 
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�   EnableRowVirtualization .    AutoGenerateColumns .  ���� *TraineesCollection+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate �� .R��� .+��� ���� $
 Name�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� $ 
Horizontal=�$��
0, 0, 0, 0q�.+�'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)���� $ 
Horizontal=�$��250, 0, 0, 0q�.+�  $ 	ArrowDown=��� $��0, 0, 10 , 0q����� $
 Name��� $��(���� $��0,0,3,0q����� $ 	ItemCount��� $��	Trainees)��.����  � ContextMenu �� .@�m� -    m�Name$ AddCmi��$��Add a New Trainee�� m� Icon   $
 Plus=�m� -   $ EditCmi��$
��Edit��   $
 Edit=�m� -   $ 	RemoveCmi��$��Remove��   $ Trash=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    Header$ Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  -   firstNameColumn��$ SizeToHeader $ 
First Name�� �� *	FirstName+  -   lastNameColumn��$ SizeToHeader $ 	Last Name�� �� *
LastName+  -	   genderColumn��$ SizeToHeader $ Gender�� �� *Gender+  -
   	ageColumn��$ SizeToHeader    
IsReadOnly . $	 Age�� �� *Age+  -   dateOfBirthColumn��$ SizeToHeader  . $ Date Of Birth�� �� *DateOfBirthStringFormat+  -   addressColumn��$ SizeToCells  . $ Address�� �� *AddressStringFormat+  -   phoneNumberColumn��$ SizeToHeader $ Phone Number�� �� *PhoneNumber+  -   emailAddressColumn��$ SizeToCells $ Email Address�� �� *EmailAddress+  -   carTypeColumn��$ SizeToHeader $ Car Type�� �� *	CarType+  -   gearTypeColumn��$ SizeToHeader $ 	Gear Type�� �� *
GearType+  -   dateOfLastTestTypeColumn��$ SizeToHeader $ Date Of Last Test�� �� *DateOfLastTestStringFormat+  -   !daysPassedSinceLastTestColumn��$ SizeToHeader  . $ Days Passed�� �� *DaysPassedSinceLastTest+  -   drivingLessonsCountColumn��$ SizeToHeader $ # of Lessons�� �� *DrivingLessonsCount+  -   drivingSchoolCityColumn��$ SizeToHeader $ D.School City�� �� *DrivingSchoolCity+  -   drivingSchoolNameColumn��$ SizeToHeader $ D.School Name�� �� *DrivingSchoolName+  -   drivingTeacherColumn��$ SizeToHeader $ Driving Teacher�� �� *DrivingSchoolTeacher+�� 
���   �$��1q�$��1��._�� -    �Name$ 
FilterGrid��$��1��
�������$��Stretch=�$��Stretch=�.+��� $��
Filter By:��$��14(�$
��Bold"�$��30��$	��140��$��36,10,42,498q�$��Center=�$��Center=�=	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  -    	 Name$ IdFilter��=
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  
  TextChanged$  TextChanged��! 	  Hint$! Id��" 	  IsValidatorVisible" .  $��10,45,118,463q�	  -   $ firstNameFilter��$  TextChanged��$! 
First Name��" .  $��10,80,118,428q�	  -   $ lastNameFilter��$  TextChanged��$! 	Last Name��$
��auto��" .  $��100,80,28,428q�>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -   #  Name$# genderFilter��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox$   SelectionChanged$$ SelectionChanged��%   Hint$% Gender��$
��auto��$��10,115,118,393q�&   IsValidatorVisible& .  	  -   $ 	ageFilter��$  TextChanged��$	! Age��$
��auto��" .  $��100,115,73,393q�	  -   $ 	dayFilter��$  TextChanged��$	! Day��' 	  
MaxLengeth$' 2��$
��auto��" .  $��10,150,158,358q��� $��/��$��30��$��52,150,152,358q�	  -   $ monthFilter��$  TextChanged��$! Month��$' 2��$
��auto��" .  $��66,150,97,358q��� $��/��$��30��$��113,150,91,358q�	  -   $ 
yearFilter��$  TextChanged��$
! Year��$' 4��$
��auto��" .  $��132,150,16,358q�	  -    $ 
cityFilter��$  TextChanged��$
! City��$
��auto��" .  $��10,185,118,323q�	  -!   $ streetFilter��$  TextChanged��$! Street��$
��auto��" .  $��86,185,42,323q�	  -"   $ buildingFilter��$  TextChanged��$! Building��$
��auto��" .  $��162,185,-10,323q�  -#   $# carTypeFilter��$$ SelectionChanged��$% Car Type��$
��auto��$��10,231,118,277q�& .    -$   $# gearTypeFilter��$$ SelectionChanged��$% 	Gear Type��$
��auto��$��100,231,28,277q�& .  	  -%   $ emailAddressFilter��$  TextChanged��$! Email Address��$
��auto��" .  $��10,266,0,242q�	  -&   $ phoneNumberFilter��$  TextChanged��$! Phone Number��" .  $��10,301,0,207q�	  -'   $ drivingTeacherFilter��$  TextChanged��$! Teacher��$
��auto��" .  $��10,336,118,172q�	  -(   $ drivingSchoolCityFilter��$  TextChanged��$! School City��$
��auto��" .  $��10,371,108,137q�	  -)   $ drivingSchoolNameFilter��$  TextChanged��$! School Name��$
��auto��" .  $��108,371,10,137q�	  -*   $ daysPassedFilter��$  TextChanged��$! Days Passed��$
��auto��" .  $��10,406,108,102q��� -+   ( ��Name$( IsGroupingEnabledCheckBox��$��Enable Groups��$��30��$��10,441,108,67q��� -,   ) ��Name$) ClearFiltersButton��$��Clear Filters��$��	0,498,0,0q�$
��Auto��
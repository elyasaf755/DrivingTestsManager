   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu/DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu  5      = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5	      E    ?DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TraineeEditPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu     5      +BEclr-namespace:BE;assembly=BE     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  5	      -   5          N�Name$  MyTraineeEditPage��5       N� Title$ TraineeEditPage��6    � 	Resources 5         traineeViewSource��%   &	        �� 5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��800* �6   �� 5      $
��220* �6   .+�5   
   � $��0��6   $��Stretch=�6]   $��Stretch=�6{    � DataContext 6   ��  �� ElementName$ MyTraineeEditPage�� �� Path$ .�.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ traineeDataGrid��5         
IsReadOnly . 	   CanUserSortColumns	 . 
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�6\      EnableRowVirtualization .    AutoGenerateColumns .  ��5      �� *TraineesCollection+ �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         HeaderTemplate 5      �� 5      .R�5    "   �� .+�5!   &   �� ��60   �� $
 Name�5"   #   5#         ContainerStyle 5%      �� 5&       �� 
TargetType" ��6$   .�5'   "   ��  �� Property � �� �� Value 5(   &   �� 5)   *    �� 
TargetType" ��6:   .R�5*   .   9� ��5+   2   �� 5,   6    �� Orientation$ 
Horizontal=�6A   .+�5-   :   �� $ 
Horizontal=�6E   $��
0, 0, 0, 0q�6^   .+�5.   >   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowDown=�6V   �� 5/   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 50   >   $��(��6H   �� 51   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 52   >   $��	Trainees)��6H   53   ;   �� 54   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�55   >     $ 	ArrowDown=�6V   �� 56   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 57   >   $��(��6H   �� 58   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 59   >   $��	Trainees)��6H   5:   ;   �� 5;   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5<   >     $ 	ArrowDown=�6V   �� 5=   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5>   >   $��(��6H   �� 5?   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5@   >   $��	Trainees)��6H   5A   ;   �� 5B   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5C   >     $ 	ArrowDown=�6V   �� 5D   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5E   >   $��(��6H   �� 5F   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5G   >   $��	Trainees)��6H   5H   ;   �� 5I   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5J   >     $ 	ArrowDown=�6V   �� 5K   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5L   >   $��(��6H   �� 5M   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5N   >   $��	Trainees)��6H   5O   ;   5P   7   .��5R   2   �� 5S   /   5T   +   5V   #   5W      5Y       � ContextMenu 5\      �� 5]      .@�5^      m� -   5         m�Name$ AddCmi��5^   #   $��Add a New Trainee��63    m� Icon 5_        5`   "   $
 Plus=�6:   5b      m� 5c      -   5        $ EditCmi��5c   #   $
��Edit��64    5d        5e   "   $
 Edit=�6:   5g      m� 5h      -   5        $ 	RemoveCmi��5h   #   $��Remove��66    5i        5j   "   $ Trash=�6:   5l      5m         Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5q   ;      Header$ Id��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   �� *Id+  5r      -   5        firstNameColumn��$ SizeToHeader 5r   B   $ 
First Name��6W    6k   �� *	FirstName+  5s      -   5        lastNameColumn��$ SizeToHeader 5s   A   $ 	Last Name��6V    6i   �� *
LastName+  5t      -	   5        genderColumn��$ SizeToHeader 5t   ?   $ Gender��6T    6d   �� *Gender+  5u      -
   5        	ageColumn��$ SizeToHeader 5u   <      
IsReadOnly . $	 Age��6c    6p   �� *Age+  5v      -   5        dateOfBirthColumn��$ SizeToHeader 5v   D    . $ Date Of Birth��6k    6�   �� *DateOfBirthStringFormat+  5w      -   5        addressColumn��$ SizeToCells 5w   @    . $ Address��6f    6w   �� *AddressStringFormat+  5x      -   5        phoneNumberColumn��$ SizeToHeader 5x   D   $ Phone Number��6Y    6o   �� *PhoneNumber+  5y      -   5        emailAddressColumn��$ SizeToCells 5y   E   $ Email Address��6Y    6p   �� *EmailAddress+  5z      -   5        carTypeColumn��$ SizeToHeader 5z   @   $ Car Type��6U    6g   �� *	CarType+  5{      -   5        gearTypeColumn��$ SizeToHeader 5{   A   $ 	Gear Type��6V    6i   �� *
GearType+  5|      -   5        dateOfLastTestTypeColumn��$ SizeToHeader 5|   K   $ Date Of Last Test��6`    6{   �� *DateOfLastTestStringFormat+  5}      -   5        !daysPassedSinceLastTestColumn��$ SizeToHeader 5}   P    . $ Days Passed��6w    6�   �� *DaysPassedSinceLastTest+  5~      -   5        drivingLessonsCountColumn��$ SizeToHeader 5~   L   $ # of Lessons��6a    6w   �� *DrivingLessonsCount+  5      -   5        drivingSchoolCityColumn��$ SizeToHeader 5   J   $ D.School City��6_    6v   �� *DrivingSchoolCity+  5�      -   5        drivingSchoolNameColumn��$ SizeToHeader 5�   J   $ D.School Name��6_    6v   �� *DrivingSchoolName+  5�      -   5        drivingTeacherColumn��$ SizeToHeader 5�   G   $ Driving Teacher��6\    6u   �� *DrivingSchoolTeacher+5�      5�      �� 5�   
   
���   �$��1q�6%   $��1��69   ._�5�      � -   5         �Name$ 
FilterGrid��5�      $��1��6'   
�������$��Stretch=�6J   $��Stretch=�6h   .+�5�      �� $��
Filter By:��6   $��14(�6-   $
��Bold"�6;   $��30��6M   $	��140��6Y   $��36,10,42,498q�6e   $��Center=�6{   $��Center=�6�   =	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  5�      -   5         	 Name$ IdFilter��5�   1   =
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  
  TextChanged$  TextChanged��6   ! 	  Hint$! Id��6C   " 	  IsValidatorVisible" .  $��10,45,118,463q�6h   6   	  5�      -   5        $ firstNameFilter��5�   1   $  TextChanged��6�   $! 
First Name��6J   " .  $��10,80,118,428q�6w   6�   	  5�      -   5        $ lastNameFilter��5�   1   $  TextChanged��6�   $! 	Last Name��6I   $
��auto��6Z   " .  $��100,80,28,428q�6�   6�   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5�      -   5        #  Name$# genderFilter��5�   2   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox$   SelectionChanged$$ SelectionChanged��6�   %   Hint$% Gender��6H   $
��auto��6V   $��10,115,118,393q�6d   &   IsValidatorVisible& .  6�   	  5�      -   5        $ 	ageFilter��5�   1   $  TextChanged��6�   $	! Age��6D   $
��auto��6O   " .  $��100,115,73,393q�6x   6�   	  5�      -   5        $ 	dayFilter��5�   1   $  TextChanged��6�   $	! Day��6D   ' 	  
MaxLengeth$' 2��6O   $
��auto��6^   " .  $��10,150,158,358q�6�   6�   �� 5�      $��/��6   $��30��6$   $��52,150,152,358q�60   	  5�      -   5        $ monthFilter��5�   1   $  TextChanged��6�   $! Month��6F   $' 2��6S   $
��auto��6b   " .  $��66,150,97,358q�6�   6�   �� 5�      $��/��6   $��30��6$   $��113,150,91,358q�60   	  5�      -   5        $ 
yearFilter��5�   1   $  TextChanged��6�   $
! Year��6E   $' 4��6Q   $
��auto��6`   " .  $��132,150,16,358q�6�   6�   	  5�      -    5        $ 
cityFilter��5�   1   $  TextChanged��6�   $
! City��6E   $
��auto��6Q   " .  $��10,185,118,323q�6z   6�   	  5�      -!   5        $ streetFilter��5�   1   $  TextChanged��6�   $! Street��6G   $
��auto��6U   " .  $��86,185,42,323q�6~   6�   	  5�      -"   5        $ buildingFilter��5�   1   $  TextChanged��6�   $! Building��6I   $
��auto��6Y   " .  $��162,185,-10,323q�6�   6�     5�      -#   5        $# carTypeFilter��5�   2   $$ SelectionChanged��6�   $% Car Type��6I   $
��auto��6Y   $��10,231,118,277q�6g   & .  6�     5�      -$   5        $# gearTypeFilter��5�   2   $$ SelectionChanged��6�   $% 	Gear Type��6J   $
��auto��6[   $��100,231,28,277q�6i   & .  6�   	  5�      -%   5        $ emailAddressFilter��5�   1   $  TextChanged��6�   $! Email Address��6M   $
��auto��6b   " .  $��10,266,0,242q�6�   6�   	  5�      -&   5        $ phoneNumberFilter��5�   1   $  TextChanged��6{   $! Phone Number��6L   " .  $��10,301,0,207q�6�   	  5�      -'   5        $ drivingTeacherFilter��5�   1   $  TextChanged��6�   $! Teacher��6O   $
��auto��6^   " .  $��10,336,118,172q�6�   6�   	  5�      -(   5        $ drivingSchoolCityFilter��5�   1   $  TextChanged��6�   $! School City��6R   $
��auto��6e   " .  $��10,371,108,137q�6�   6�   	  5�      -)   5        $ drivingSchoolNameFilter��5�   1   $  TextChanged��6�   $! School Name��6R   $
��auto��6e   " .  $��108,371,10,137q�6�   6�   	  5�      -*   5        $ daysPassedFilter��5�   1   $  TextChanged��6�   $! Days Passed��6K   $
��auto��6^   " .  $��10,406,108,102q�6�   6�   �� 5�      -+   5        ( ��Name$( IsGroupingEnabledCheckBox��5�      $��Enable Groups��6>   $��30��6V   $��10,441,108,67q�6b   6�   �� 5�      -,   5        ) ��Name$) ClearFiltersButton��5�      $��Clear Filters��65   $��	0,498,0,0q�6M   $
��Auto��6�   5�      5�      5�      5�      
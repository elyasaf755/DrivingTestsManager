   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu.DrivingTestsManagerV1._2.Main_Menu.Tester_Menu  5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5      = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 6R   D    >DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TesterEditPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu     5      NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5      +BEclr-namespace:BE;assembly=BE     6R   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N�Name$  MyTesterEditPage��5       N� Title$ TesterEditPage��6    � 	Resources 5         testerViewSource��%   &	        �� 5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��800* �6   �� 5      $
��220* �6   .+�5   
   � $��0��6   $��Stretch=�6\   $��Stretch=�6z    � DataContext 6   ��  �� ElementName$ MyTesterEditPage�� �� Path$ .�.+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ testerDataGrid��5         
IsReadOnly . $	��800��6A   	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6M   
   EnableRowVirtualization
 .    AutoGenerateColumns .  ��5      �� *TestersCollection+ �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         HeaderTemplate 5      �� 5      .R�5   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5    &   �� ��60   �� $
 Name�5!   #   5"         ContainerStyle 5$      �� 5%       �� 
TargetType" ��6$   .�5&   "   ��  �� Property � �� �� Value 5'   &   �� 5(   *    �� 
TargetType" ��6:   .R�5)   .   9� ��5*   2   �� 5+   6   $ 
Horizontal=�6A   .+�5,   :   �� $ 
Horizontal=�6E   $��
0, 0, 0, 0q�6^   .+�5-   >   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ 	ArrowDown=�6V   �� 5.   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5/   >   $��(��6H   �� 50   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 51   >   $��	Trainees)��6H   52   ;   �� 53   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�54   >     $ 	ArrowDown=�6V   �� 55   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 56   >   $��(��6H   �� 57   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 58   >   $��	Trainees)��6H   59   ;   �� 5:   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5;   >     $ 	ArrowDown=�6V   �� 5<   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5=   >   $��(��6H   �� 5>   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5?   >   $��	Trainees)��6H   5@   ;   �� 5A   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5B   >     $ 	ArrowDown=�6V   �� 5C   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5D   >   $��(��6H   �� 5E   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5F   >   $��	Trainees)��6H   5G   ;   �� 5H   :   $ 
Horizontal=�6E   $��250, 0, 0, 0q�6^   .+�5I   >     $ 	ArrowDown=�6V   �� 5J   >   $��0, 0, 10 , 0q�6c   ��6H   �� $
 Name�6c   �� 5K   >   $��(��6H   �� 5L   >   $��0,0,3,0q�6h   ��6H   �� $ 	ItemCount�6h   �� 5M   >   $��	Trainees)��6H   5N   ;   5O   7   .��5Q   2   �� 5R   /   5S   +   5U   #   5V      5X       � ContextMenu 5\      �� 5]      .@�5^      m� -   5         m�Name$ WorkTimeCmi��5^   #   $��Show Work Time��68    m� Icon 5_        5`   "   $
 Show=�6:   5b      �� 5c      m� 5d      -   5        $ AddCmi��5d   #   $��Add a New Tester��63    5e        5f   "   $
 Plus=�6:   5h      m� 5i      -   5        $ EditCmi��5i   #   $
��Edit��64    5j        5k   "   $
 Edit=�6:   5m      m� 5n      -   5        $ 	RemoveCmi��5n   #   $��Remove��66    5o        5p   "   $ Trash=�6:   5r      5s         Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5w      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5w   ;      Header$ Id��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   �� *Id+  5x      -   5        firstNameColumn��$ SizeToHeader 5x   B   $ 
First Name��6W    6k   �� *	FirstName+  5y      -	   5        lastNameColumn��$ SizeToHeader 5y   A   $ 	Last Name��6V    6i   �� *
LastName+  5z      -
   5        genderColumn��$ SizeToHeader 5z   ?   $ Gender��6T    6d   �� *Gender+  5{      -   5        dateOfBirthColumn��$ SizeToHeader 5{   D   $ Date Of Birth��6Y      
IsReadOnly .  6p   �� *DateOfBirthStringFormat+6�     5|      -   5        	ageColumn��$ SizeToHeader 5|   <   $	 Age��6Q    6^   �� *Age+  5}      -   5        addressColumn��$ SizeToCells 5}   @   $ Address��6T    6e   �� *AddressStringFormat+  5~      -   5        phoneNumberColumn��$ SizeToHeader 5~   D   $ Phone Number��6Y    6o   �� *PhoneNumber+  5      -   5        emailAddressColumn��$ SizeToCells 5   E   $ Email Address��6Y    6p   �� *EmailAddress+  5�      -   5        carTypeColumn��$ SizeToHeader 5�   @   $ Car Type��6U    6g   �� *	CarType+  5�      -   5        maximalDistanceColumn��$ SizeToHeader 5�   H   $ 
Max. Dist.��6]    6q   �� *MaximalDistance+  5�      -   5        weeklyTestsCountColumn��$ SizeToHeader 5�   I   $ Weekly Tests��6^    6t   �� *WeeklyTestsCount+  5�      -   5        maximalWeeklyTestsColumn��$ SizeToHeader 5�   K   $ Max. Weekly Tests��6`    6{   �� *MaximalWeeklyTests+  5�      -   5        yearsOfExperienceColumn��$ SizeToHeader 5�   J   $ Exp. (Years)��6_    6u   �� *YearsOfExperience+5�      5�      �� 5�   
   
���   �$��1q�6%   $��1��69   ._�5�      � -   5         �Name$ 
FilterGrid��5�      $��1��6'   
�������$��Stretch=�6J   $��Stretch=�6h   .+�5�      �� $��
Filter By:��6   $��14(�6-   $
��Bold"�6;   $��30��6M   $	��140��6Y   $��36,10,42,498q�6e   $��Center=�6{   $��Center=�6�   =	   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox	  5�      -   5         	 Name$ IdFilter��5�   1   =
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox 
  TextChanged$ TextChanged��6     	  Hint$  Id��6C   ! 	  IsValidatorVisible! .  $��10,45,118,464q�6h   6   	  5�      -   5        $ firstNameFilter��5�   1   $ TextChanged��6�   $  
First Name��6J   ! .  $��10,79,118,429q�6w   6�   	  5�      -   5        $ lastNameFilter��5�   1   $ TextChanged��6�   $  	Last Name��6I   $
��auto��6Z   ! .  $��100,79,28,429q�6�   6�   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5�      -   5        "  Name$" genderFilter��5�   2   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox#   SelectionChanged$# SelectionChanged��6�   $   Hint$$ Gender��6H   $
��auto��6V   $��10,114,118,394q�6d   %   IsValidatorVisible% .  6�   	  5�      -   5        $ 	ageFilter��5�   1   $ TextChanged��6�   $	  Age��6D   $
��auto��6O   ! .  $��100,114,73,394q�6x   6�   	  5�      -   5        $ 	dayFilter��5�   1   $ TextChanged��6�   $	  Day��6D   & 	  
MaxLengeth$& 2��6O   $
��auto��6^   ! .  $��10,149,158,359q�6�   6�   �� 5�      $��/��6   $��30��6$   $��52,149,151,359q�60   	  5�      -   5        $ monthFilter��5�   1   $ TextChanged��6�   $  Month��6F   $& 2��6S   $
��auto��6b   ! .  $��66,149,97,359q�6�   6�   �� 5�      $��/��6   $��30��6$   $��113,150,90,358q�60   	  5�      -   5        $ 
yearFilter��5�   1   $ TextChanged��6�   $
  Year��6E   $& 4��6Q   $
��auto��6`   ! .  $��132,149,16,359q�6�   6�   	  5�      -   5        $ 
cityFilter��5�   1   $ TextChanged��6�   $
  City��6E   $
��auto��6Q   ! .  $��10,184,118,324q�6z   6�   	  5�      -   5        $ streetFilter��5�   1   $ TextChanged��6�   $  Street��6G   $
��auto��6U   ! .  $��86,184,42,324q�6~   6�   	  5�      -    5        $ buildingFilter��5�   1   $ TextChanged��6�   $  Building��6I   $
��auto��6Y   ! .  $��162,184,-10,324q�6�   6�     5�      -!   5        $" carTypeFilter��5�   2   $# SelectionChanged��6�   $$ Car Type��6I   $
��auto��6Y   $��10,219,118,289q�6g   % .  6�   	  5�      -"   5        $ emailAddressFilter��5�   1   $ TextChanged��6�   $  Email Address��6M   $
��auto��6b   $	��180��6p   ! .  $��10,254,28,254q�6�   6�   	  5�      -#   5        $ phoneNumberFilter��5�   1   $ TextChanged��6�   $  Phone Number��6L   $
��auto��6`   $	��180��6n   ! .  $��10,289,28,219q�6�   6�   	  5�      -$   5        $ maxDistFilter��5�   1   $ TextChanged��6�   $  Max. Distance��6H   $
��auto��6]   ! .  $��10,324,103,184q�6�   6�   	  5�      -%   5        $ experienceFilter��5�   1   $ TextChanged��6�   $  
Experience��6K   $
��auto��6]   ! .  $��103,324,10,184q�6�   6�   	  5�      -&   5        $ weeklyTestsCountFilter��5�   1   $ TextChanged��6�   $  # Weekly Tests��6Q   $
��auto��6g   ! .  $��10,359,98,149q�6�   6�   	  5�      -'   5        $ maxWeeklyTestsFilter��5�   1   $ TextChanged��6�   $  Max. Weekly Tests��6O   $
��auto��6h   ! .  $��103,359,-15,149q�6�   6�   �� 5�      -(   5        ' ��Name$' IsGroupingEnabledCheckBox��5�      $��Enable Groups��6>   $��30��6V   $��10,394,108,114q�6b   6�   �� 5�      -)   5        ( ��Name$( ClearFiltersButton��5�      $��Clear Filters��65   $��	0,498,0,0q�6M   $
��Auto��6�   5�      5�      5�      5�      
   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  5      = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE 5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5
      ?    9DrivingTestsManagerV1._2.Main_Menu.Test_Menu.TestEditPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     5      +BEclr-namespace:BE;assembly=BE     5      Lcontrols9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  5
      -   5          N�Name$  MyTestEditPage��5       N� Title$ TestEditPage��6    � 	Resources 5         testViewSource��%   &	        �� 5   
   6   5      .��5      � $��0��6   $��Stretch=�6V   $��Stretch=�6t    � DataContext 6   ��  �� ElementName$ MyTestEditPage�� �� Path$ .� � ColumnDefinitions 5   
   �� 5      $
��800* �6   �� 5      $
��220* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ testDataGrid��5         
IsReadOnly . 	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�6;   
   EnableRowVirtualization
 .    AutoGenerateColumns .  $��Stretch=�5   �   $��Stretch=�6�   ��5      �� *TestsCollection+ �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         HeaderTemplate 5       �� 5!      .R�5"      �� .+�5#   "   �� ��6,   �� $
 Name�5$      5%         ContainerStyle 5'      �� 5(       �� 
TargetType" ��6    .�5)      ��  �� Property � �� �� Value 5*   "   �� 5+   &    �� 
TargetType" ��66   .R�5,   *   9� ��5-   .   �� 5.   2    �� Orientation$ 
Horizontal=�6=   .+�5/   6   �� $��0, 0, 10 , 0q�6[   ��6@   �� $
 Name�6[   �� 50   6   $��0,0,10,0q�6`   ��6@   �� $ 	ItemCount�6`   �� 51   6   $��Items��6@   52   3   .��54   .   �� 55   +   56   '   58      59      5;         Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      -   5        testIdColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 5>   ;      Header$ 	Test's Id��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6b   �� *TestIdStringFormat+  5?      -   5        testDateTimeColumn��$ SizeToHeader 5?   A   $ Test's Date��6V    6k   �� *TestDateStringFormat+  5@      -   5        testLocationColumn��$ SizeToCells 5@   A   $ Test's Location��6U    6n   �� *TestLocation+  5A      -   5        traineeIdColumn��$ SizeToHeader 5A   >   $ Trainee's Id��6S    6i   �� *	TraineeId+4  .System.Windows.Controls.DataGridCheckBoxColumn  5B      -   5        isPassedColumn��$ SizeToHeader 5B   A   $ 
Is Passed?��6V    6j   �� *
IsPassed+  5C      -   5        testerIdColumn��$ SizeToCells 5C   =   $ Tester's Id��6Q    6f   �� *
TesterId+6�    � ContextMenu 5G      �� 5H      .@�5I      m� -	   5         m�Name$ TesterNotesCmi��5I      $��Show Tester's Notes��67    m� Icon 5J      '  !MaterialDesignThemes.Wpf.PackIcon  5K      �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Show=�66   5M      �� 5N      m� 5O      -
   5        $ AddCmi��5O      $��Add a New Test��6/    5P        5Q      $
 Plus=�66   5S      m� 5T      -   5        $ EditCmi��5T      $��Set Test's Result��60    5U        5V      $
 Edit=�66   5X      5Y      5\      �� 5^   
   
���   �$��1q�6%   $��1��69   ._�5_      � -   5         �Name$ 
FilterGrid��5_      $��1��6'   
�������$��Stretch=�6J   $��Stretch=�6h   .+�5`      �� $��
Filter By:��6   $��14(�6-   $
��Bold"�6;   $	��140��6M   $��36,0,42,491q�6Y   $��Center=�6n   $��Center=�6�   $��37��6�   $��Bottom=�6�   =
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox
  5a      -   5         
 Name$ testIdFilter��5a   1   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ TextChanged��6�    
  Hint$ Test Id��6G     
  IsValidatorVisible  .  $��30��6q   $��
10,0,0,461q�6}   $
��Left=�6�   $	��198��6�   $��Bottom=�6�   
  5b      -   5        $ traineeIdFilter��5b   1   $ TextChanged��6�   $ 
Trainee Id��6J     .  $��30��6w   $��
10,0,0,426q�6�   $
��Left=�6�   $	��198��6�   $��Bottom=�6�   
  5c      -   5        $ testerIdFilter��5c   1   $ TextChanged��6�   $ 	Tester Id��6I     .  $��30��6u   $��
10,0,0,391q�6�   $
��Left=�6�   $	��198��6�   $��Bottom=�6�   
  5d      -   5        $ 	dayFilter��5d   1   $ TextChanged��6�   $	 Day��6D   ! 
  
MaxLengeth$! 2��6O   $��30��6^     .  $��
10,0,0,356q�6�   $
��Left=�6�   $��49��6�   $��Bottom=�6�   �� 5e      $��/��6   $��
49,0,0,356q�6$   $
��Left=�68   $��14��6S   $��28��6^   $��Bottom=�6j   
  5f      -   5        $ monthFilter��5f   1   $ TextChanged��6�   $ Month��6F   $! 2��6S   $��30��6b     .  $��
60,0,0,356q�6�   $
��Left=�6�   $��54��6�   $��Bottom=�6�   �� 5g      $��/��6   $��30��6$   $��103,0,0,356q�60   $
��Left=�6E   $��14��6`   $��Bottom=�6k   
  5h      -   5        $ 
yearFilter��5h   1   $ TextChanged��6�   $
 Year��6E   $! 4��6Q   $��30��6`     .  $��115,0,0,356q�6�   $
��Left=�6�   $��69��6�   $��Bottom=�6�   
  5i      -   5        $ 
hourFilter��5i   1   $ TextChanged��6�   $ HH��6E   $! 2��6O   $��30��6^     .  $��10,187,159,321q�6�   6�   �� 5j      $
��: 00��6   $��49,189,135,321q�6'   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5k      -   5        "  Name$" 
cityFilter��5k   2   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox#   SelectionChanged$# SelectionChanged��6�   $   DropDownOpened$$ CityFilter_DropDownOpened��6�   %   Hint$
% City��6F   $
��auto��6R   &   IsValidatorVisible& .  $��10,222,108,286q�6{   6�     5l      -   5        $" streetFilter��5l   2   $# SelectionChanged��6�   $!$ StreetFilter_DropDownOpened��6�   $% Street��6H   $
��auto��6V   & .  $��111,222,10,286q�6   6�     5m      -   5        $" carTypeFilter��5m   2   $# SelectionChanged��6�   $% Car Type��6I   $
��auto��6Y   $��10,257,118,251q�6g   & .  6�   �� 5n      -   5        ' ��Name$' isPassedFilter��5n      $��
Is Passed?��63   ( d� IsThreeState( . $��103,257,10,251q�6q   ) d� 	IsChecked) 6\   Z� 6�     5o      -   5        $" drivingSchoolCityFilter��5o   2   $# SelectionChanged��6�   $,$ &DrivingSchoolCityFilter_DropDownOpened��6�   $% School City��6S   $
��auto��6f   & .  $��10,292,108,216q�6�   6�     5p      -   5        $" drivingSchoolNameFilter��5p   2   $# SelectionChanged��6�   $,$ &DrivingSchoolNameFilter_DropDownOpened��6�   $% School Name��6S   $
��auto��6f   & .  $��108,292,10,216q�6�   6�     5q      -   5        $" 	DMVFilter��5q   2   $# SelectionChanged��6�   $% D.M.V��6E   $
��auto��6R   & .  $��10,327,108,181q�6{   6�   �� 5r      -   5        $' IsGroupingEnabledCheckBox��5r      $��Enable Groups��6>   $��30��6V   $��10,441,108,67q�6b   6�   �� 5s      -   5        * ��Name$* ClearFiltersButton��5s      $��Clear Filters��65   $��	0,498,0,0q�6M   $
��Auto��6`   6n   5t      5u      5x      5y      
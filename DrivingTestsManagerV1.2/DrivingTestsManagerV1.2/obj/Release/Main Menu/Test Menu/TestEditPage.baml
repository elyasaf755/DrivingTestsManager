   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  = 9BE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:BE;assembly=BEBE _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  ?    9DrivingTestsManagerV1._2.Main_Menu.Test_Menu.TestEditPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     +BEclr-namespace:BE;assembly=BE     Lcontrols9http://schemas.microsoft.com/netfx/2009/xaml/presentation    V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  HUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls  -     N�Name$  MyTestEditPage�� N� Title$ TestEditPage�� � 	Resources    testViewSource��%   &	        �� .��� $��0��$��Stretch=�$��Stretch=� � DataContext ��  �� ElementName$ MyTestEditPage�� �� Path$ .� � ColumnDefinitions �� $
��800* ��� $
��220* �.+�&   System.Windows.Controls.DataGrid  -     Name$ testDataGrid��   
IsReadOnly . 	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�
   EnableRowVirtualization
 .    AutoGenerateColumns .  $��Stretch=�$��Stretch=����� *TestsCollection+ �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     HeaderTemplate �� .R��� .+��� ���� $
 Name�   ContainerStyle ��  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R�9� ����  �� Orientation$ 
Horizontal=�.+��� $��0, 0, 10 , 0q����� $
 Name��� $��0,0,10,0q����� $ 	ItemCount��� $��Items��.����    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   testIdColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells    Header$ 	Test's Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *TestIdStringFormat+  -   testDateTimeColumn��$ SizeToHeader $ Test's Date�� �� *TestDateStringFormat+  -   testLocationColumn��$ SizeToCells $ Test's Location�� �� *TestLocation+  -   traineeIdColumn��$ SizeToHeader $ Trainee's Id�� �� *	TraineeId+4  .System.Windows.Controls.DataGridCheckBoxColumn  -   isPassedColumn��$ SizeToHeader $ 
Is Passed?�� �� *
IsPassed+  -   testerIdColumn��$ SizeToCells $ Tester's Id�� �� *
TesterId+ � ContextMenu �� .@�m� -	    m�Name$ TesterNotesCmi��$��Show Tester's Notes�� m� Icon '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Show=��� m� -
   $ AddCmi��$��Add a New Test��   $
 Plus=�m� -   $ EditCmi��$��Set Test's Result��   $
 Edit=��� 
���   �$��1q�$��1��._�� -    �Name$ 
FilterGrid��$��1��
�������$��Stretch=�$��Stretch=�.+��� $��
Filter By:��$��14(�$
��Bold"�$	��140��$��36,0,42,491q�$��Center=�$��Center=�$��37��$��Bottom=�=
   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox
  -    
 Name$ testIdFilter��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ TextChanged�� 
  Hint$ Test Id��  
  IsValidatorVisible  .  $��30��$��
10,0,0,461q�$
��Left=�$	��198��$��Bottom=�
  -   $ traineeIdFilter��$ TextChanged��$ 
Trainee Id��  .  $��30��$��
10,0,0,426q�$
��Left=�$	��198��$��Bottom=�
  -   $ testerIdFilter��$ TextChanged��$ 	Tester Id��  .  $��30��$��
10,0,0,391q�$
��Left=�$	��198��$��Bottom=�
  -   $ 	dayFilter��$ TextChanged��$	 Day��! 
  
MaxLengeth$! 2��$��30��  .  $��
10,0,0,356q�$
��Left=�$��49��$��Bottom=��� $��/��$��
49,0,0,356q�$
��Left=�$��14��$��28��$��Bottom=�
  -   $ monthFilter��$ TextChanged��$ Month��$! 2��$��30��  .  $��
60,0,0,356q�$
��Left=�$��54��$��Bottom=��� $��/��$��30��$��103,0,0,356q�$
��Left=�$��14��$��Bottom=�
  -   $ 
yearFilter��$ TextChanged��$
 Year��$! 4��$��30��  .  $��115,0,0,356q�$
��Left=�$��69��$��Bottom=�
  -   $ 
hourFilter��$ TextChanged��$ HH��$! 2��$��30��  .  $��10,187,159,321q��� $
��: 00��$��49,189,135,321q�>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -   "  Name$" 
cityFilter��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox#   SelectionChanged$# SelectionChanged��$   DropDownOpened$$ CityFilter_DropDownOpened��%   Hint$
% City��$
��auto��&   IsValidatorVisible& .  $��10,222,108,286q�  -   $" streetFilter��$# SelectionChanged��$!$ StreetFilter_DropDownOpened��$% Street��$
��auto��& .  $��111,222,10,286q�  -   $" carTypeFilter��$# SelectionChanged��$% Car Type��$
��auto��$��10,257,118,251q�& .  �� -   ' ��Name$' isPassedFilter��$��
Is Passed?��( d� IsThreeState( . $��103,257,10,251q�) d� 	IsChecked) Z�   -   $" drivingSchoolCityFilter��$# SelectionChanged��$,$ &DrivingSchoolCityFilter_DropDownOpened��$% School City��$
��auto��& .  $��10,292,108,216q�  -   $" drivingSchoolNameFilter��$# SelectionChanged��$,$ &DrivingSchoolNameFilter_DropDownOpened��$% School Name��$
��auto��& .  $��108,292,10,216q�  -   $" 	DMVFilter��$# SelectionChanged��$% D.M.V��$
��auto��& .  $��10,327,108,181q��� -   $' IsGroupingEnabledCheckBox��$��Enable Groups��$��30��$��10,441,108,67q��� -   * ��Name$* ClearFiltersButton��$��Clear Filters��$��	0,498,0,0q�$
��Auto��
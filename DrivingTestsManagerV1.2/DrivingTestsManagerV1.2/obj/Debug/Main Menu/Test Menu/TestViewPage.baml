   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5      ?    9DrivingTestsManagerV1._2.Main_Menu.Test_Menu.TestViewPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     5      Nuser_controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Ixcad19http://schemas.microsoft.com/netfx/2009/xaml/presentation    5
      -   5          N�Name$  MyTestAddPage��5       N� Title$ Test Add Page��6   .��5      � -   5         �Name$ TestAddPageMainGrid��5      
������� � ColumnDefinitions 5   
   �� 5      $	��40* �6   �� 5      $	��11* �6   .+�5   
   �� $��	Test Id #��6   $��30��6$   $��14(�60   $
��Bold"�6>   $��1,1,139,509q�6P   $��1��6e   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  5   
   -   5          Name$ testIdTb��5   )   {�.     IsHintVisible .  $��30��6c      IsValidatorVisible .  $��83,1,-3,509q�6�   $��1��6�     5   
   -   5        $ traineeIdTb��5   )   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ IdTb_TextChanged��6v      Hint$ 
Trainee Id��6>   $��1,36,139,474q�6P   $��1��6f   6v     5   
   -   5        $ traineeNameTb��5   )   $ Trainee's Full Name��6@   {�.   .  $��83,36,-3,474q�6�   $��1��6�     5   
   -   5        $ 
testerIdTb��5   )   $ IdTb_TextChanged��6t   $ 	Tester Id��6=   $��1,71,139,439q�6N   $��1��6d   6t     5   
   -   5        $ testerNameTb��5   )   $ Tester's Full Name��6?   {�.   .  $��83,71,-3,439q�6�   $��1��6�   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker  5   
   -   5        	  Name$	 
testDateDp��5   ,   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker
   SelectedDateChanged$$
 TestDateDp_SelectedDateChanged��6�      Hint$ 	Test Date��6@   $
��Auto��6Q   $
��Auto��6_   $��1,106,119,404q�6l   $��1��6�   6�   "  Xceed.Wpf.Toolkit.TimePicker  5   
   -	   5          Name$ 
testTimeTp��5      $
��Left=�6.   $��30��6I   $��90��6U   $��101,106,0,0q�6`   $	��Top=�6u      	StartTime$ 9:0:0h�5         EndTime$ 15:0:0h�6,   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 01/21/2019 09:00:00X�6T   $��1��6p    � ContextMenu 5      �� 5      .@�5      m� -
   5         m�Name$ timePickerCmi��5      $��Show Available Hours��66    m� Icon 5       '  !MaterialDesignThemes.Wpf.PackIcon  5!      �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Show=�66   5#      5$      5&      <
   6DrivingTestsManagerV1._2.User_Controls.CircleValidator
  5(   
   -   5         
 Name$ testTimeValidator��5(   (   $��191,106,10,404q�6C   $��1��6[   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5)   
   -   5          Name$ 	carTypeCb��5)   *   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox   SelectionChanged$  CarTypeCb_SelectionChanged��6�      Hint$ Car Type��6=   $��1,141,119,369q�6M   $��Center=�6d   $��1��6�   6�     5*   
   -   5        $ DMVCb��5*   *   $ DMVCb_SelectionChanged��6|   $ D.M.V��69   $
��auto��6F   $��101,141,10,369q�6T   $��1��6l   6|     5+   
   -   5        $ drivingSchoolsCitiesCb��5+   *   $- 'DrivingSchoolsCitiesCb_SelectionChanged��6�   $ D.School City��6J   $
��auto��6_   $��1,180,119,330q�6m   $��1��6�     5,   
   -   5        $ drivingSchoolsNamesCb��5,   *   $, &DrivingSchoolsNamesCb_SelectionChanged��6�   $ D.School Name��6I   {�.  $
��auto��6p   $��98,180,10,330q�6~   $��1��6�   �� 5-   
   $��Test Location:��6   $��30��6)   $	��140��65   $��14(�6A   $
��Bold"�6O   $��Center=�6a   $��30,215,50,295q�6�   $��1��6�     5.   
   -   5        $ 
testCityCb��5.   *   !   PreviewMouseLeftButtonDown$+ %TestCityCb_PreviewMouseLeftButtonDown��6   $! TestCityCb_SelectionChanged��6�   $
 City��6>   $
��auto��6J   $��1,250,149,260q�6X   $��1��6o   6�     5/   
   -   5        $ testStreetCb��5/   *   $- 'TestStreetCb_PreviewMouseLeftButtonDown��6�   $# TestStreetCb_SelectionChanged��6�   $ Street��6@   {�.  $
��auto��6`   $��71,250,79,260q�6n   $��1��6�   6�     50   
   -   5        $ testBuildingTb��50   )   $  TestBuildingTb_TextChanged��6y   $ Building��6A   $��140,250,10,260q�6Q   $��1��6i   6y   �� 51   
   $��Tester's Notes:��6   $
��Bold"�6*   $��Center=�6<   $��Bottom=�6`   $��0,280,0,226q�6�   $��1��6�   �� 52   
   -   5         ��Name$ testerNotesRtb��52      $��1��6.   $��
0,314,0,30q�6>   . �53      /� -   5         /�Name$ a��53      .T�54      J� -   5         J�Name$ b��54      .*�6'   .*�55      �� .F�56      �� -   5         ��Name$ rtbHint��56       $��Write notes here...��61   57      58      59      5:      �� 5;   
   -   5         ��Name$ ClearButton��5;      $��Clear��6&   $��30��66   $��90��6B   $��27,394,683,116q�6M   6e   �� 5<   
   -   5        $ 
FillButton��5<      $
��Fill��6%   $��30��64   $��90��6@   $��160,394,550,116q�6K   6d   �� 5=   
   -   5        $ 
SendButton��5=      
��� � �{�.  $	��Add��6J   $��28(�6X   $
��Auto��6f   $��0,449,626,30q�6t   $��Center=�6�   $��Center=�6�   6�   � 5>   
   -   5         �Name$ ProgressBar��5>      $��30��6�   $��	0,510,0,0q�6�   
��� � �$��2��6�     � Value  6+   �� *ValidFieldsCount+! �� ElementName$! MyTestViewPage��" �� Mode$" OneWay=�# �� UpdateSourceTrigger$# PropertyChanged=�6�   5?      5@      
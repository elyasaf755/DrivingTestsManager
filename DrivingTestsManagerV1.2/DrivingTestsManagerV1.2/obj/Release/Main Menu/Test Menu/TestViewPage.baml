   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu,DrivingTestsManagerV1._2.Main_Menu.Test_Menu  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  ?    9DrivingTestsManagerV1._2.Main_Menu.Test_Menu.TestViewPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Llocal:clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Test_Menu     Nuser_controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Ixcad19http://schemas.microsoft.com/netfx/2009/xaml/presentation    -     N�Name$  MyTestAddPage�� N� Title$ Test Add Page��.��� -    �Name$ TestAddPageMainGrid��
������� � ColumnDefinitions �� $	��40* ��� $	��11* �.+��� $��	Test Id #��$��30��$��14(�$
��Bold"�$��1,1,139,509q�$��1��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -     Name$ testIdTb��{�.     IsHintVisible .  $��30��   IsValidatorVisible .  $��83,1,-3,509q�$��1��  -   $ traineeIdTb��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ IdTb_TextChanged��   Hint$ 
Trainee Id��$��1,36,139,474q�$��1��  -   $ traineeNameTb��$ Trainee's Full Name��{�.   .  $��83,36,-3,474q�$��1��  -   $ 
testerIdTb��$ IdTb_TextChanged��$ 	Tester Id��$��1,71,139,439q�$��1��  -   $ testerNameTb��$ Tester's Full Name��{�.   .  $��83,71,-3,439q�$��1��@   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker  -   	  Name$	 
testDateDp��@   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker
   SelectedDateChanged$$
 TestDateDp_SelectedDateChanged��   Hint$ 	Test Date��$
��Auto��$
��Auto��$��1,106,119,404q�$��1��"  Xceed.Wpf.Toolkit.TimePicker  -	     Name$ 
testTimeTp��$
��Left=�$��30��$��90��$��101,106,0,0q�$	��Top=�   	StartTime$ 9:0:0h�   EndTime$ 15:0:0h�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   AllowTextInput .  �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 01/21/2019 09:00:00X�$��1�� � ContextMenu �� .@�m� -
    m�Name$ timePickerCmi��$��Show Available Hours�� m� Icon '  !MaterialDesignThemes.Wpf.PackIcon  �	  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 	  Kind$
 Show=�<
   6DrivingTestsManagerV1._2.User_Controls.CircleValidator
  -    
 Name$ testTimeValidator��$��191,106,10,404q�$��1��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -     Name$ 	carTypeCb��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox   SelectionChanged$  CarTypeCb_SelectionChanged��   Hint$ Car Type��$��1,141,119,369q�$��Center=�$��1��  -   $ DMVCb��$ DMVCb_SelectionChanged��$ D.M.V��$
��auto��$��101,141,10,369q�$��1��  -   $ drivingSchoolsCitiesCb��$- 'DrivingSchoolsCitiesCb_SelectionChanged��$ D.School City��$
��auto��$��1,180,119,330q�$��1��  -   $ drivingSchoolsNamesCb��$, &DrivingSchoolsNamesCb_SelectionChanged��$ D.School Name��{�.  $
��auto��$��98,180,10,330q�$��1���� $��Test Location:��$��30��$	��140��$��14(�$
��Bold"�$��Center=�$��30,215,50,295q�$��1��  -   $ 
testCityCb��!   PreviewMouseLeftButtonDown$+ %TestCityCb_PreviewMouseLeftButtonDown��$! TestCityCb_SelectionChanged��$
 City��$
��auto��$��1,250,149,260q�$��1��  -   $ testStreetCb��$- 'TestStreetCb_PreviewMouseLeftButtonDown��$# TestStreetCb_SelectionChanged��$ Street��{�.  $
��auto��$��71,250,79,260q�$��1��  -   $ testBuildingTb��$  TestBuildingTb_TextChanged��$ Building��$��140,250,10,260q�$��1���� $��Tester's Notes:��$
��Bold"�$��Center=�$��Bottom=�$��0,280,0,226q�$��1���� -    ��Name$ testerNotesRtb��$��1��$��
0,314,0,30q�. �/� -    /�Name$ a��.T�J� -    J�Name$ b��.*�.*��� .F��� -    ��Name$ rtbHint��$��Write notes here...���� -    ��Name$ ClearButton��$��Clear��$��30��$��90��$��27,394,683,116q��� -   $ 
FillButton��$
��Fill��$��30��$��90��$��160,394,550,116q��� -   $ 
SendButton��
��� � �{�.  $	��Add��$��28(�$
��Auto��$��0,449,626,30q�$��Center=�$��Center=�� -    �Name$ ProgressBar��$��30��$��	0,510,0,0q�
��� � �$��2��  � Value  �� *ValidFieldsCount+! �� ElementName$! MyTestViewPage��" �� Mode$" OneWay=�# �� UpdateSourceTrigger$# PropertyChanged=�
   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu/DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  D    >DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TraineeAddPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Olocal=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu     NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47wpfTool)http://schemas.xceed.com/wpf/xaml/toolkit  -     N�Name$  MyTraineeAddPage�� N� Title$ TraineeAddPage��.��� .+��� ���	#FF00AEFF$��2q�._�� -    �Name$ TraineeAddPageMainGrid��
�������.+�=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -     Name$
 IdTb��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ IdTb_TextChanged��   Hint$ Id��$
��Left=�$
��auto��$	��170��$��	60,50,0,0q�$	��Top=�  -   $ FirstNameTb��$ FirstNameTb_TextChanged��$ 
First Name��$
��Left=�$
��auto��$	��170��$��
300,50,0,0q�$	��Top=�  -   $ 
LastNameTb��$ LastNameTb_TextChanged��$ 	Last Name��$
��Left=�$
��auto��$	��170��$��
540,50,0,0q�$	��Top=�@   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker  -     Name$ BirthDateDp��@   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker   SelectedDateChanged$% BirthDateDp_SelectedDateChanged��   Hint$ Date Of Birth��$
��Left=�$
��auto��$��
780,50,0,0q�$	��Top=�$	��170��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  -   	  Name$	 GenderCb��>   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox
   SelectionChanged$
 GenderCb_SelectionChanged��   Hint$ Gender��$
��Left=�$
��auto��$	��170��$��
60,135,0,0q�$	��Top=�  -   $	 CityCb��$
 CityCb_SelectionChanged��!   PreviewMouseLeftButtonDown$' !CityCb_PreviewMouseLeftButtonDown��$
 City��$
��auto��$	��170��$��300,135,546,371q�%  Xceed.Wpf.Toolkit.BusyIndicator  -	     Name$ CityBusyIndicator��$
��auto��$	��180��$��284,179,552,327q�  -
   $	 StreetCb��$
 StreetCb_SelectionChanged��$) #StreetCb_PreviewMouseLeftButtonDown��$ Street��$
��auto��$	��170��$��540,135,306,371q�{�.    -   $ StreetBusyIndicator��$
��auto��$	��180��$��530,179,306,327q�  -   $ 
BuildingTb��$ BuildingTb_TextChanged��$ Building��$
��auto��$	��170��$��780,135,66,371q�  -   $ PhoneNumberTb��$ PhoneNumberTb_TextChanged��$ Phone Number��$
��Left=�$
��auto��$	��170��$��
60,216,0,0q�$	��Top=�  -   $ EmailTb��$ EmailTb_TextChanged��$ Email��$
��Left=�$
��auto��$	��170��$��300,216,0,0q�$	��Top=�  -   $	 	CarTypeCb��$ 
 CarTypeCb_SelectionChanged��$ Car Type��$
��auto��$	��170��$��540,216,306,290q�  -   $	 
GearTypeCb��$!
 GearTypeCb_SelectionChanged��$ 	Gear Type��$
��auto��$	��170��$��780,216,66,290q�  -   $	 DrivingSchoolsCitiesCb��$-
 'DrivingSchoolsCitiesCb_SelectionChanged��$ Driving School City��$
��auto��$	��170��$��60,293,786,213q�  -   $	 DrivingSchoolsNamesCb��$,
 &DrivingSchoolsNamesCb_SelectionChanged��$ Driving School Name��{�.  $
��auto��$	��170��$��300,293,546,213q�  -   $ DrivingTeacherTb��$" DrivingTeacherTb_TextChanged��$ Driving Teacher Name��$
��Left=�$
��auto��$	��170��$��540,293,0,0q�$	��Top=�%  Xceed.Wpf.Toolkit.IntegerUpDown  -     Name$ DrivingLessonsCountNUD��$��60,364,816,142q��	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Minimum$ 0X� 	  Maximum$	 100X�$��Center=�,
  &Xceed.Wpf.Toolkit.Primitives.InputBase 
  	Watermark$ # of Driving Lessons���  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=�<   6DrivingTestsManagerV1._2.User_Controls.CircleValidator  -     Name$ LessonsValidator��$
��Left=�$��30��$��200,364,0,0q�$	��Top=�$��30�� J� RenderTransformOrigin$ 8.578,0.644&��� -    ��Name$ 
SendButton��
��� � �{�.  $	��Add��$��28(�$
��Auto��$��780,273,66,206q�$��Center=�$��Center=��� -   $ 
FillButton��$
��Auto��{�.  $y�Hidden=�$
��Fill��$��876,359,40,137q��� -   $ ClearButton��
���  ��$
��Auto��$��Clear��$��770,426,146,74q��� -   $ RefillButton��$y�Visible=�$��40��$��Refill��$��770,358,145,136q�$	��100��� -    �Name$ ProgressBar��$��30��$��	0,506,0,0q�
��� � � � Value ��  �� ElementName$ MyTraineeAddPage�� �� Path$ ValidFieldsCount� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�
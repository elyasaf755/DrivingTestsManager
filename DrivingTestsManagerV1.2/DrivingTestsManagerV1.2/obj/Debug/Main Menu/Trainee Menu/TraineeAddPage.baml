   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu/DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu  5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5      D    >DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu.TraineeAddPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Trainee_Menu     5      NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47wpfTool)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          N�Name$  MyTraineeAddPage��5   3    N� Title$ TraineeAddPage��6   .��5      � .+�5   
   �� ���	#FF00AEFF$��2q�6)   ._�5      � -   5         �Name$ TraineeAddPageMainGrid��5      
�������.+�5      =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -   5          Name$
 IdTb��5   4   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ IdTb_TextChanged��6�      Hint$ Id��6I   $
��Left=�6[   $
��auto��6v   $	��170��6�   $��	60,50,0,0q�6�   $	��Top=�6�   6�     5      -   5        $ FirstNameTb��5   4   $ FirstNameTb_TextChanged��6�   $ 
First Name��6I   $
��Left=�6[   $
��auto��6v   $	��170��6�   $��
300,50,0,0q�6�   $	��Top=�6�   6�     5      -   5        $ 
LastNameTb��5   4   $ LastNameTb_TextChanged��6�   $ 	Last Name��6I   $
��Left=�6[   $
��auto��6v   $	��170��6�   $��
540,50,0,0q�6�   $	��Top=�6�   6�   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker  5      -   5          Name$ BirthDateDp��5   4   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker   SelectedDateChanged$% BirthDateDp_SelectedDateChanged��6�      Hint$ Date Of Birth��6I   $
��Left=�6^   $
��auto��6y   $��
780,50,0,0q�6�   $	��Top=�6�   $	��170��6�   6�   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5      -   5        	  Name$	 GenderCb��5   4   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox
   SelectionChanged$
 GenderCb_SelectionChanged��6�      Hint$ Gender��6F   $
��Left=�6T   $
��auto��6o   $	��170��6}   $��
60,135,0,0q�6�   $	��Top=�6�   6�     5      -   5        $	 CityCb��5   4   $
 CityCb_SelectionChanged��6�   !   PreviewMouseLeftButtonDown$' !CityCb_PreviewMouseLeftButtonDown��6�   $
 City��6D   $
��auto��6P   $	��170��6^   $��300,135,546,371q�6j   6�   %  Xceed.Wpf.Toolkit.BusyIndicator  5      -	   5          Name$ CityBusyIndicator��5   (   $
��auto��6C   $	��180��6Q   $��284,179,552,327q�6]     5      -
   5        $	 StreetCb��5   2   $
 StreetCb_SelectionChanged��6�   $) #StreetCb_PreviewMouseLeftButtonDown��6�   $ Street��6D   $
��auto��6S   $	��170��6a   $��540,135,306,371q�6m   {�.  6�     5      -   5        $ StreetBusyIndicator��5   (   $
��auto��6E   $	��180��6S   $��530,179,306,327q�6_     5      -   5        $ 
BuildingTb��5   1   $ BuildingTb_TextChanged��6�   $ Building��6E   $
��auto��6V   $	��170��6d   $��780,135,66,371q�6p   6�     5      -   5        $ PhoneNumberTb��5   1   $ PhoneNumberTb_TextChanged��6�   $ Phone Number��6H   $
��Left=�6]   $
��auto��6x   $	��170��6�   $��
60,216,0,0q�6�   $	��Top=�6�   6�     5      -   5        $ EmailTb��5   1   $ EmailTb_TextChanged��6�   $ Email��6B   $
��Left=�6P   $
��auto��6k   $	��170��6y   $��300,216,0,0q�6�   $	��Top=�6�   6�     5      -   5        $	 	CarTypeCb��5   2   $ 
 CarTypeCb_SelectionChanged��6�   $ Car Type��6E   $
��auto��6U   $	��170��6c   $��540,216,306,290q�6o   6�     5      -   5        $	 
GearTypeCb��5   2   $!
 GearTypeCb_SelectionChanged��6�   $ 	Gear Type��6F   $
��auto��6W   $	��170��6e   $��780,216,66,290q�6q   6�     5      -   5        $	 DrivingSchoolsCitiesCb��5   2   $-
 'DrivingSchoolsCitiesCb_SelectionChanged��6�   $ Driving School City��6R   $
��auto��6m   $	��170��6{   $��60,293,786,213q�6�   6�     5      -   5        $	 DrivingSchoolsNamesCb��5   2   $,
 &DrivingSchoolsNamesCb_SelectionChanged��6�   $ Driving School Name��6Q   {�.  $
��auto��6~   $	��170��6�   $��300,293,546,213q�6�   6�     5       -   5        $ DrivingTeacherTb��5    2   $" DrivingTeacherTb_TextChanged��6�   $ Driving Teacher Name��6L   $
��Left=�6h   $
��auto��6�   $	��170��6�   $��540,293,0,0q�6�   $	��Top=�6�   6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5!      -   5          Name$ DrivingLessonsCountNUD��5!   (   $��60,364,816,142q�6H   �	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Minimum$ 0X�6`    	  Maximum$	 100X�6l   $��Center=�6z   ,
  &Xceed.Wpf.Toolkit.Primitives.InputBase 
  	Watermark$ # of Driving Lessons��6�   �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=�6�   6�   <   6DrivingTestsManagerV1._2.User_Controls.CircleValidator  5"      -   5          Name$ LessonsValidator��5"   0   $
��Left=�6J   $��30��6e   $��200,364,0,0q�6q   $	��Top=�6�   $��30��6�    J� RenderTransformOrigin$ 8.578,0.644&�6�   �� 5#      -   5         ��Name$ 
SendButton��5#      
��� � �{�.  $	��Add��6R   $��28(�6`   $
��Auto��6n   $��780,273,66,206q�6|   $��Center=�6�   $��Center=�6�   6�   �� 5$      -   5        $ 
FillButton��5$      $
��Auto��6-   {�.  $y�Visible=�6M   $
��Fill��6b   $��876,359,40,137q�6q   6�   �� 5%      -   5        $ ClearButton��5%      
���  ��$
��Auto��6?   $��Clear��6M   $��770,426,146,74q�6]   6u   �� 5&      -   5        $ RefillButton��5&      $y�Visible=�6/   $��40��6D   $��Refill��6P   $��770,358,145,136q�6a   $	��100��6�   � 5'      -   5         �Name$ ProgressBar��5'      $��30��6�   $��	0,506,0,0q�6�   
��� � � � Value 63   ��  �� ElementName$ MyTraineeAddPage�� �� Path$ ValidFieldsCount� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5(      5)      5*      5+      
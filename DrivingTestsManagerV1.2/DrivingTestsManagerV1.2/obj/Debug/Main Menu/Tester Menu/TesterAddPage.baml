   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullo<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu.DrivingTestsManagerV1._2.Main_Menu.Tester_Menu  5      _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5	      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      B    <DrivingTestsManagerV1._2.Main_Menu.Tester_Menu.TesterAddPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Nlocal<clr-namespace:DrivingTestsManagerV1._2.Main_Menu.Tester_Menu     5      NUser_Controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      HwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit  5	      4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
      3System&clr-namespace:System;assembly=mscorlib  5      -   5          N�Name$  MyTesterAddPage��5   2    N� Title$ TesterAddPage��6   .��5      �� ���	#FF00AEFF$��2q�6%   ._�5   
   � -   5         �Name$ TesterAddPageMainGrid��5      
�������.+�5      =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -   5          Name$
 IdTb��5   0   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ IdTb_TextChanged��6�      Hint$ Id��6E   $
��Left=�6W   $
��auto��6r   $	��170��6�   $��	60,50,0,0q�6�   $	��Top=�6�   6�     5      -   5        $ FirstNameTb��5   0   $ FirstNameTb_TextChanged��6�   $ 
First Name��6E   $
��Left=�6W   $
��auto��6r   $	��170��6�   $��
300,50,0,0q�6�   $	��Top=�6�   6�     5      -   5        $ 
LastNameTb��5   0   $ LastNameTb_TextChanged��6�   $ 	Last Name��6E   $
��Left=�6W   $
��auto��6r   $	��170��6�   $��
540,50,0,0q�6�   $	��Top=�6�   6�   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker  5      -   5          Name$ BirthDateDp��5   0   @   :DrivingTestsManagerV1._2.User_Controls.HinttableDatePicker   SelectedDateChanged$% BirthDateDp_SelectedDateChanged��6�      Hint$ Date Of Birth��6E   $
��Left=�6Z   $
��auto��6u   $��
780,50,0,0q�6�   $	��Top=�6�   $	��170��6�   6�   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox  5      -   5        	  Name$	 GenderCb��5   0   >   8DrivingTestsManagerV1._2.User_Controls.HinttableComboBox
   SelectionChanged$
 GenderCb_SelectionChanged��6�      Hint$ Gender��6B   $
��Left=�6P   $
��auto��6k   $	��170��6y   $��
60,135,0,0q�6�   $	��Top=�6�   6�     5      -   5        $	 CityCb��5   0   $
 CityCb_SelectionChanged��6   !   PreviewMouseLeftButtonDown$' !CityCb_PreviewMouseLeftButtonDown��6�   $
 City��6@   $
��auto��6L   $	��170��6Z   $��300,135,546,371q�6f   6�   %  Xceed.Wpf.Toolkit.BusyIndicator  5      -	   5          Name$ CityBusyIndicator��5   !   $
��auto��6<   $	��180��6J   $��284,179,552,327q�6V     5      -
   5        $	 StreetCb��5   .   $
 StreetCb_SelectionChanged��6�   $) #StreetCb_PreviewMouseLeftButtonDown��6�   $ Street��6@   $
��auto��6O   $	��170��6]   $��540,135,306,371q�6i   {�.  6�     5      -   5        $ StreetBusyIndicator��5   !   $
��auto��6>   $	��180��6L   $��530,179,306,327q�6X     5      -   5        $ 
BuildingTb��5   -   $ BuildingTb_TextChanged��6�   $ Building��6A   $
��auto��6R   $	��170��6`   $��780,135,66,371q�6l   6�   9� 5      -   5         9�Name$ WorkTimeExpander��5      $��23,228,740,58q�61   
�������
�������$��Choose working hours��6m   .��5      <   6DrivingTestsManagerV1._2.User_Controls.WorkTimeControl  -   5          Name$ 
MyWorkTime��5   0   <	   6DrivingTestsManagerV1._2.User_Controls.WorkTimeControl 	  SelectionChanged$! MyWorkTime_SelectionChanged��6�   $
��Left=�6D   $	��190��6_   $	��Top=�6l   $	��250��6�   6�   5      <
   6DrivingTestsManagerV1._2.User_Controls.CircleValidator
  5      -   5         
 Name$ WorkHoursValidator��5   ,   $
��Left=�6H   $
��auto��6c   $��200,236,0,0q�6q   $	��Top=�6�   $��30��6�     5       -   5        $ PhoneNumberTb��5    -   $ PhoneNumberTb_TextChanged��6�   $ Phone Number��6D   $
��Left=�6Y   $
��auto��6t   $	��170��6�   $��300,236,0,0q�6�   $	��Top=�6�   6�     5!      -   5        $ EmailTb��5!   -   $ EmailTb_TextChanged��6�   $ Email��6>   $
��Left=�6L   $
��auto��6g   $	��170��6u   $��540,236,0,0q�6�   $	��Top=�6�   6�     5"      -   5        $	 	CarTypeCb��5"   .   $ 
 CarTypeCb_SelectionChanged��6�   $ Car Type��6A   $
��auto��6Q   $	��170��6_   $��300,311,546,195q�6k   6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5#      -   5          Name$ MaximalDistance��5#   $   $
��auto��6=   $��540,311,336,195q�6K   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6d   $��Center=�6p   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ Maximal Distance��6�   �  �Xceed.Wpf.Toolkit.CommonNumericUpDown`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   ParsingNumberStyle$ Integer=�6�   6�   
  5$      -   5        $ MaxDistanceValidator��5$   ,   $
��Left=�6J   $��30��6e   $��680,311,0,0q�6q   $	��Top=�6�   $��30��6�     5%      -   5        $ 
Experience��5%   $   $��300,383,576,123q�68   $ 0X�6Q      Maximum$	 100X�6]   $��Center=�6k   $ Years of Experience��6�   $ Integer=�6�   6�   
  5&      -   5        $ ExperienceValidator��5&   ,   $
��Left=�6I   $��30��6d   $��440,383,0,0q�6p   $	��Top=�6�   $��30��6�    J� RenderTransformOrigin$ 8.578,0.644&�6�     5'      -   5        $ MaxWeeklyTests��5'   $   $��540,383,336,123q�6<   $ 0X�6U   $	 100X�6a   $��Center=�6o   $ Max Weekly Tests��6�   $ Integer=�6�   6�   
  5(      -   5        $ MaxWeeklyTestsValidator��5(   ,   $
��Left=�6M   $��30��6h   $��680,383,0,0q�6t   $	��Top=�6�   $��30��6�   $ 8.578,0.644&�6�   �� 5)      -   5         ��Name$ 
SendButton��5)      
��� � �{�.  $	��Add��6N   $��28(�6\   $
��Auto��6j   $��780,273,66,206q�6x   $��Center=�6�   $��Center=�6�   6�   �� 5*      -   5        $ 
FillButton��5*      $
��Auto��6)   {�.  $y�Visible=�6I   $
��Fill��6^   $��876,359,40,137q�6m   6�   �� 5+      -   5        $ ClearButton��5+      
���  ��$
��Auto��6;   $��Clear��6I   $��770,426,146,74q�6Y   6q   �� 5,      -   5        $ RefillButton��5,      $y�Visible=�6+   $��40��6@   $��Refill��6L   $��770,358,145,136q�6]   $	��100��6�   � 5-      -   5         �Name$ ProgressBar��5-      $��30��6�   $��	0,506,0,0q�6�   
��� � � � Value 6/   ��  �� ElementName$ MyTesterAddPage�� �� Path$ ValidFieldsCount� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5.      5/      51      
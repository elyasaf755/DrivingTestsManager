   M S B A M L   `   `   `  ���� R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DrivingTestsManagerV1._2DrivingTestsManagerV1._2  _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  *    $DrivingTestsManagerV1._2.SettingsWin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:DrivingTestsManagerV1._2     Nuser_controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     -     �Name$  settingsWin�� � Title$ SettingsWin��$	��450��$	��267�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=�.��� -    �Name$ configurationsGrid��$
��Left=�$��Bottom=�$	��257��$	��419��.+��� $��Trainees' Configurations��$��16(�$
��Bold"�$��	0,0,0,389q�$��30��$��Bottom=�$
��Left=�$	��257���� $"��Minimum lessons before test:��$��SemiBold"�$��	0,0,0,330q�$��29��$��Bottom=�$
��Left=�$	��175��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  -     Name$ minLessonsTb��=   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ MinLessonsTb_TextChanged��   Hint$  ��$��170,54,0,335q�$
��Left=�$��37���� $��Minimal trainee's age:��$��	0,0,0,300q�$��SemiBold"�$��30��$��Bottom=�$
��Left=�$	��130��  -   $ minTraineeAgeTb��$! MinTraineeAgeTb_TextChanged��$  ��$��133,83,0,306q�$
��Left=�$��37���� $��Maximal trainee's age:��$��SemiBold"�$��	0,0,0,270q�$��30��$��Bottom=�$
��Left=�$	��130��  -   $ maxTraineeAgeTb��$! MaxTraineeAgeTb_TextChanged��$  ��$��133,0,0,276q�$
��Left=�$��37��$��30��$��Bottom=��� $!��Minimum days metween tests:��$��SemiBold"�$��	0,0,0,240q�$
��Left=�$	��175��$��30��$��Bottom=�  -   $ minDaysBetweenTestsTb��$' !MinDaysBetweenTestsTb_TextChanged��$  ��$��175,0,0,249q�$
��Left=�$��37��$��30��$��Bottom=��� $��Testers' Configurations��$��30��$��16(�$
��Bold"�$��	0,0,0,147q�$
��Left=�$	��257��$��Bottom=��� $��Minimal tester's age:��$��SemiBold"�$��	0,0,0,112q�$��30��$��Bottom=�$
��Left=�$	��120��  -   $ minTesterAgeTb��$  MinTesterAgeTb_TextChanged��$  ��$��120,0,0,120q�$
��Left=�$��37��$��30��$��Bottom=��� $��Maximal tester's age:��$��SemiBold"�$��0,0,0,82q�$��30��$��Bottom=�$
��Left=�$	��125��  -   $ maxTesterAge��$ MaxTesterAge_TextChanged��$  ��$��
120,0,0,90q�$
��Left=�$��37��$��30��$��Bottom=��� -	    ��Name$ 
SendButton��
��� � �{�.  $
��Send��$��30��$��
0,354,0,35q��� -
   $ RestoreButton��{�. $��Restore Default��$��30��$��	0,389,0,0q�
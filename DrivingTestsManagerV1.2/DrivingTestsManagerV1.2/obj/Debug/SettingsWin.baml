   M S B A M L   `   `   `  ����R  NDrivingTestsManagerV1.2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DrivingTestsManagerV1._2DrivingTestsManagerV1._2  5   	   _4clr-namespace:DrivingTestsManagerV1._2.User_Controls&DrivingTestsManagerV1._2.User_Controls  5   	   *    $DrivingTestsManagerV1._2.SettingsWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:DrivingTestsManagerV1._2     5   	   Nuser_controls4clr-namespace:DrivingTestsManagerV1._2.User_Controls     5   	   -   5          �Name$  settingsWin��5	       � Title$ SettingsWin��6	   $	��450��5
   	   $	��267��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5      � -   5         �Name$ configurationsGrid��5      $
��Left=�6'   $��Bottom=�6B   $	��257��6]   $	��419��6i   .+�5   
   �� $��Trainees' Configurations��6   $��16(�63   $
��Bold"�6A   $��	0,0,0,389q�6S   $��30��6f   $��Bottom=�6r   $
��Left=�6�   $	��257��6�   �� 5   
   $"��Minimum lessons before test:��6   $��SemiBold"�67   $��	0,0,0,330q�6M   $��29��6`   $��Bottom=�6l   $
��Left=�6�   $	��175��6�   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox  5   
   -   5          Name$ minLessonsTb��5   )   =   7DrivingTestsManagerV1._2.User_Controls.HinttableTextBox   TextChanged$ MinLessonsTb_TextChanged��6]      Hint$  ��6?   $��170,54,0,335q�6G   $
��Left=�6�   $��37��6�   �� 5   
   $��Minimal trainee's age:��6   $��	0,0,0,300q�61   $��SemiBold"�6D   $��30��6Z   $��Bottom=�6f   $
��Left=�6�   $	��130��6�     5   
   -   5        $ minTraineeAgeTb��5   )   $! MinTraineeAgeTb_TextChanged��6`   $  ��6B   $��133,83,0,306q�6J   $
��Left=�6�   $��37��6�   �� 5   
   $��Maximal trainee's age:��6   $��SemiBold"�61   $��	0,0,0,270q�6G   $��30��6Z   $��Bottom=�6f   $
��Left=�6�   $	��130��6�     5   
   -   5        $ maxTraineeAgeTb��5   )   $! MaxTraineeAgeTb_TextChanged��6_   $  ��6B   $��133,0,0,276q�6J   $
��Left=�6�   $��37��6�   $��30��6�   $��Bottom=�6�   �� 5   
   $!��Minimum days metween tests:��6   $��SemiBold"�66   $��	0,0,0,240q�6L   $
��Left=�6_   $	��175��6z   $��30��6�   $��Bottom=�6�     5   
   -   5        $ minDaysBetweenTestsTb��5   )   $' !MinDaysBetweenTestsTb_TextChanged��6e   $  ��6H   $��175,0,0,249q�6P   $
��Left=�6�   $��37��6�   $��30��6�   $��Bottom=�6�   �� 5   
   $��Testers' Configurations��6   $��30��62   $��16(�6>   $
��Bold"�6L   $��	0,0,0,147q�6^   $
��Left=�6q   $	��257��6�   $��Bottom=�6�   �� 5   
   $��Minimal tester's age:��6   $��SemiBold"�60   $��	0,0,0,112q�6F   $��30��6Y   $��Bottom=�6e   $
��Left=�6�   $	��120��6�     5   
   -   5        $ minTesterAgeTb��5   )   $  MinTesterAgeTb_TextChanged��6^   $  ��6A   $��120,0,0,120q�6I   $
��Left=�6�   $��37��6�   $��30��6�   $��Bottom=�6�   �� 5   
   $��Maximal tester's age:��6   $��SemiBold"�60   $��0,0,0,82q�6F   $��30��6X   $��Bottom=�6d   $
��Left=�6   $	��125��6�     5   
   -   5        $ maxTesterAge��5   )   $ MaxTesterAge_TextChanged��6[   $  ��6?   $��
120,0,0,90q�6G   $
��Left=�6�   $��37��6�   $��30��6�   $��Bottom=�6�   �� 5   
   -	   5         ��Name$ 
SendButton��5      
��� � �{�.  $
��Send��6J   $��30��6Y   $��
0,354,0,35q�6e   6y   �� 5   
   -
   5        $ RestoreButton��5      {�. $��Restore Default��69   $��30��6S   $��	0,389,0,0q�6_   6r   5      5      
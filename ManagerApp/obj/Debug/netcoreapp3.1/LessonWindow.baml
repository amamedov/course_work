   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	       ManagerApp.LessonWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  
Add lesson��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $��Center=�61   $��16(�6L   $��10 15q�6Z   Choose teacher:6z   �� 5   
   -   5         ��Name$ ComboBoxTeacher��5      $��1��6,   $��Stretch=�6<   $��16(�6Z   $��Center=�6h   $��10 15q�6�   6�   �� 5   
   $��1��6   $��Center=�6!   $��Center=�6>   $��16(�6Y   $��10 15q�6g   Choose room:6�   �� 5   
   -   5        $ ComboBoxRoom��5      $��1��6)   $��1��66   $��Stretch=�6F   $��16(�6d   $��Center=�6r   $��10 15q�6�   6�   �� 5   
   $��2��6   $��Center=�6"   $��Center=�6?   $��16(�6Z   $��10 15q�6h   Choose date:6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
DatePicker��5      $��2��6)   $��1��66   $��Center=�6F   $��Center=�6c   $��16(�6~   $��10 15q�6�   6�   �� 5   
   $��3��6   $��Center=�6!   $��Center=�6>   $��16(�6Y   $��10 15q�6g   Choose time:6�   �� 5   
   $��Center=�6   $��Center=�62   $��3��6M   $��1��6Z    �� Orientation$ 
Horizontal=�6j   .+�5      �� -   5        $ ComboBoxStartHour��5      $��16(�63   $��Center=�6A   6^   �� 5      $��Center=�6   $��Center=�65   $��16(�6P   $��10 15q�6^   :6p   �� 5      -   5        $ ComboBoxStartMinute��5      $��16(�64   $��Center=�6B   6_   �� 5       $��Center=�6   $��Center=�65   $��16(�6P   $��10 15q�6^   -6r   �� 5!      -   5        $ ComboBoxEndHour��5!      $��16(�62   $��Center=�6@   6]   �� 5"      $��Center=�6   $��Center=�65   $��16(�6P   $��10 15q�6^   :6p   �� 5#      -   5        $ ComboBoxEndMinute��5#      $��16(�63   $��Center=�6A   6^   5$      �� 5%   
   -   5         ��Name$ ButtonClose��5%   t   $��4��6   $��Center=�6   $��Center=�69   $��16(�6V   $��10 15q�6d   .��6�   Cancel6�   �� 5&   
   -	   5        $ 	ButtonAdd��5&   �   $��1��6   $��4��6!   $��Center=�6.   $��Center=�6I   $��16(�6f   $��20 15q�6t   .��6�   Save6�   5'      5(      
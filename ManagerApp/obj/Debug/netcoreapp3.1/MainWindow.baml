   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:cOURSEwoRK
cOURSEwoRK  5   	   "    cOURSEwoRK.ManagerMainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:cOURSEwoRK     5   	     � Title$  
Management��5   	    � WindowStyle$ ThreeDBorderWindow=�6    � WindowStartupLocation$ CenterScreen=�6=   $	��600��6c   $
��1200��6p    � 
ResizeMode$ NoResize=�6~   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��1��6   .@�5      �� $��Courses��6   $��14(�6'   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $��4* �6+   .+�5      � $��1��6    5      �� 5      $
��auto �6,   �� 5      �� 5      $��75 �6,   .+�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��Center=�6(   $��10 15q�6C   $��16(�6R   $
��Bold"�6`   
Search for6~   �� 5      $��Center=�6(   $��10 15q�6C   $��16(�6R   
Subject:6j   �� 5      -   5         ��Name$ ComboBoxSubjectFilter��5   �   $��Center=�6'    �� SelectedItem$	 Any��6|   $��16(�6�   $��10 15q�6�   6�   �� 5      -   5        	 ��Name$	 ClearButton��5   %   $��16(�6:   $��100 15 10 15q�6H   $
��10 8q�6^   .��6�   Clear6�   5       &   System.Windows.Controls.DataGrid  5!      -   5        
  Name$
 ListBoxCourses��5!     $��1��6#      AutoGenerateColumns$ False��6�   $��1q�6$  $��16(�68  $��3��6F  ��60   ��  �� Path$ repository.Courses� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#   "   ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��65      Header$
 Name��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6U   �� $
 Name�$ OneWay=�6�     5$   "   $
 True��65   $ 
Start date��6G    6[   �� $ 
ShortStart�$ OneWay=�6�     5%   "   $
 True��65   $ End date��6H    6Z   �� $ ShortEnd�$ OneWay=�6�     5&   "   $
 True��65   $ Price��6H    6W   �� $ Price�$ OneWay=�6�   4  .System.Windows.Controls.DataGridCheckBoxColumn  5'   "   $
 True��6:   $
 Exam��6L    6Z   �� $ FollowedByExam�$ OneWay=�5)      5*      �� 5+      $ Vertical=�6!   $��1��68   $��Center=�6L   .+�5,      �� -   5        $	 ButtonAddCourse��5,   !   $��16(�6:   $
��auto��6H   $��
15 0 15 10q�6V   $��15 10q�6j   .��6�   
Add course6�   �� 5-      -   5        $	 ButtonAddSubject��5-   !   $��16(�6;   $
��auto��6I   $��15  10q�6W   $��15 10q�6g   .��6�   Add subject6�   �� 5.      -   5        $	 ButtonTimetable��5.   !   $��16(�6X   $
��auto��6f   $��15 10q�6t   $��15 10q�6�   .��6�   Manage timetable6�   5/      �� 50      -   5        $	 
ButtonExit��50      $��16(�6K   $
��auto��6Y   $��
25,0,25,15q�6g   $��15 10q�6{   $��Bottom=�6�   $��1��6�   .��6�   Exit6�   51      52      �� 53      $��	Contracts��6   $��14(�6)   $��23��67   $��Center=�6C   $
��Left=�6^   $��71��6y   .��54      �  55      �� 56      �� 57      $��4* �6+   .+�59      � $��1��6    5:      �� 5;      $
��auto �6,   �� 5<      �� 5=      $��20 �6,   .+�5?      �� $ 
Horizontal=�6%   .+�5@      �� $��Center=�6(   $��10 15q�6C   $��16(�6R   $
��Bold"�6`   
Search for6~   �� 5A      $��Center=�6(   $��10 15q�6C   $��16(�6R   
Student:6j   �� 5B      -   5        $ ComboBoxStudentFilter��5B   �   $��Center=�6'    �� DisplayMemberPath$ FullName��6|   $	 Any��6�   $��16(�6�   $��10 15q�6�   6�   �� 5C      $��Center=�6(   $��10 15q�6C   $��16(�6R   Course6h   �� 5D      -	   5        $ ComboBoxCourseFilter��5D   �   $��Center=�6(   $	 Any��6|   $��16(�6�   $��10 15q�6�   6�   �� 5E      -
   5        $	 ClearButton_1��5E   %   $��16(�6<   $��100 15 10 15q�6J   $
��10 8q�6`   .��6�   Clear6�   5F        5G      -   5        $
 ListBoxContracts��5G   �   $��1��6#   $��1q�6p   $ False��6�   $��16(�6�   ��60   �� $ repository.Contracts�$ TwoWay=� 5H        5I   "   $
 True��65   $ Student��6H    6Y   �� $ Student.FullName�  5J   "   $
 True��65   $ Course��6H    6X   �� $ Course.GridView�  5K   "   $
 True��65   $
 Made��6H    6V   �� $ 	ShortDate�  5L   "      CanUserSort$ False��69   $
 True��6M   $
 Paid��6`    6n   �� $ IsPaid�$ TwoWay=�5N      5O      �� 5P      $ Vertical=�6!   $��Center=�68   .+�5Q      �� -   5        $	 ButtonAddContract��5Q   !   $��16(�6\   $
��auto��6j   $��15 10 15 10q�6x   $��15 10q�6�   .��6�   Add contract6�   �� 5R      -   5        $	 ButtonMarkAsPaid��5R   !   $��16(�6;   $
��auto��6I   $��15 10q�6W   $��15 10q�6f   .��6�   	Payment6�   5S      �� 5T      -   5        $	 ButtonExit1��5T      $��16(�6L   $
��auto��6Z   $��25 15q�6h   $��15 10q�6w   $��Bottom=�6�   .��6�   Exit6�   5U      5V      �� 5W      $��Students��6   $��14(�6(   $	��Top=�66   .��5X      �  5Y      �� 5Z      $��* �6+   �� 5[      $��4* �6+   .+�5]      �� $��Center=�6!   .+�5^      �� -   5        $	 ButtonAddStudent��5^   !   $��Center=�6Z   $��	10 0 10 0q�6w   $��16(�6�   $��10 15q�6�   .��6�   Add student6�   5_      �� 5`      -   5        $��16(�5`   6   $
��auto��6D   $��25 15q�6R   $��15 10q�6a   $��Bottom=�6q   .��6�   Exit6�   � 5a      $��1��6    5b      �� 5c      $
��auto �6,   �� 5d      �� 5e      $��15 �6,   .+�5g        -   5        $
 ListBoxStudents��5g   �   $��5q�6�   $ False��6�   $��16(�6�   $��1q�6�   $��1��6�   $��1��6	  ��6X   �� $ repository.Students�$ TwoWay=� 5h        5i   "   $
 True��65   $
 Name��6G    6U   �� $
 Name�  5j   "   $
 True��66   $ Surname��6H    6Y   �� $ Surname�  5k   "   $
 True��66   $ Date of birth��6H    6_   �� $ ShortDoB�  5l   "   $
 True��66   $ Gender��6H    6X   �� $ Gender�5n      5p      5q      5r      5s      5t      5u      
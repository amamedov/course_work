   M S B A M L   `   `   `  ����E  AStudentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StudentApp
StudentApp  5   	       StudentApp.CoursesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:StudentApp     5   	     � Title$  Search new courses��5   	   $	��450��6$    � WindowStartupLocation$ CenterScreen=�61   $	��900��6V   $	��450��6b   $	��900��6r   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��5* �6   �� 5      $	��90* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $	��15* �6   �� 5      $��4* �6   �� 5      $	��60* �6   �� 5      $��5* �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $��2* �6    �� 5      $	��10* �6    �� 5      $��1* �6    �� 5      $	��15* �6    �� 5      $��2* �6     5      �� 5      $��3* �6#   �� 5       $��9* �6#   �� 5!      $��2* �6#   �� 5"      $��9* �6#   �� 5#      $��2* �6#   �� 5$      $��6* �6#   �� 5%      $��3* �6#   .+�5'      �� $��1��6   $��1��6%   $��16(�65   $��Center=�6C   $��Center=�6`   	Subject6�   �� 5(      -   5         ��Name$ ComboBoxSubject��5(   K   $��3��6d   $��1��6q   $��16(�6�   $��30��6�   $��Center=�6�   6�   �� 5)      $��1��6   $��3��6%   $��16(�65   $��Center=�6C   $��Center=�6`   Type6�   �� 5*      -   5        $ ComboBoxType��5*   H   $��3��6^   $��3��6k   $��16(�6{   $��30��6�   $��Center=�6�   6�   �� 5+      -   5         ��Name$ ButtonClear��5+   Q   $��5��6   $��1��6%   $��3��62   $��16(�6C   .��6�   Clear6�   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ ListBoxCourses��5-   M   $��3��6      AutoGenerateColumns$ False��6    $��1��6<   $��16(�6e   $��10q�6s      Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   
   
IsReadOnly$

 True��6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   ��  �� Path$
 Name�6Q     50      $	 
Start date��6%   $

 True��6]    69   �� $ 
ShortStart�6]     51      $

 True��6%   $	 End date��67    6I   �� $ ShortEnd�  52      $

 True��6%   $	 Price��67    6F   �� $ Price�4  .System.Windows.Controls.DataGridCheckBoxColumn  53      $

 True��6)   $
	 Exam��6;    6I   �� $ FollowedByExam�55      56      57      
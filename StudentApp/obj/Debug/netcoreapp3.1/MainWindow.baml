   M S B A M L   `   `   `  ����E  AStudentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:StudentApp
StudentApp  5   	       StudentApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:StudentApp     5   	     � Title$  
MainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��500��6A   $	��900��6N   $	��400��6Z   $	��700��6j   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $	��20* �6   �� 5      $��4* �6   �� 5      $	��60* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6   �� 5      $��3* �6   �� 5      $	��10* �6   �� 5      $��1* �6   �� 5      $	��10* �6   �� 5      $��5* �6   �� 5      $	��10* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   $��1��6!   $��1q�6.   
���   �6X   �� 5   
   -   5         ��Name$ textBlockWelcome��5      $��16(�6.   $��Center=�6<   $��Center=�6W   $��1��6t   $��1��6�   6�   �� 5   
   $��3��6   $��1��6$   $��Bottom=�61   $��Center=�6L   $��16(�6i   $
��Bold"�6w   Your courses6�   �� 5   
   -   5         ��Name$ CheckBoxPastCourses��5   �   $��3��6   $��1��6     d� 	IsChecked$ FalseY�60   $��10 15q�6�   $��16(�6�   $��Center=�6�   .��6�   Include past courses6  �� 5    
   -   5         ��Name$ ButtonSearchCourse��5    .   $��1��6   $��5��6!   $��16(�6J   $��10 15q�6X   $
��10 5q�6g   .��6�   Search for new course6�   �� 5!   
   -   5        $ ButtonClose��5!   .   $��1��6   $��7��6!   $��Bottom=�6]   $��Center=�6x   $��16(�6�   $��10 15q�6�   $
��10 5q�6�   .��6�   Close6�   �� 5"   
   -   5         ��Name$ ListBoxCourses��5"   �   $��3��6   $��3��6   $��5��6/   $��16(�6@   $��8q�6N   6�   5#      5$      
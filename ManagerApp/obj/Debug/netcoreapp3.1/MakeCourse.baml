   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	       ManagerApp.MakeCourse   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Create course��5   	   $	��500��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$
 head��5   (   $��2��6   $��20(�66   $��Center=�6D   $��Center=�6a   $��15 20q�6|   Enter course info6�   �� 5   
   $��1��6   $��10 15q�6!   $��Center=�60   $��16(�6M   $��Center=�6[   Course name:6�   �� 5   
   -   5         ��Name$ TextBoxName��5      $��1��6   $��10 15 20 15q�64   $��1��6I   $��Stretch=�6Y   $��16(�6w   $��Center=�6�   6�   �� 5   
   $��2��6   $��10 15q�6!   $��Center=�60   $��16(�6M   $��Center=�6[   
Subject:6�   �� 5   
   -   5         ��Name$ ComboBoxSubject��5       $��2��6   $��10 15 20 15q�69   $��1��6N   $��Stretch=�6^   $��16(�6|   $��Center=�6�   6�   �� 5   
   $��3��6   $��10 15q�6!   $��Center=�60   $��16(�6M   $��Center=�6[   Price:6~   �� 5   
   -   5        $ TextBoxPrice��5      $��3��6   $��10 15 20 15q�65   $��1��6J   $��Stretch=�6Z   $��16(�6x   $��Center=�6�   6�   �� 5   
   $��4��6   $��10 15q�6!   $��Center=�60   $��16(�6M   $��Center=�6[   Type:6}   �� 5    
   -   5        $ ComboBoxTypeOfCourse��5        $��4��6   $��10 15 20 15q�6>   $��1��6S   $��Stretch=�6c   $��16(�6�   $��Center=�6�   6�   �� 5!   
   $��5��6   $��10 15q�6!   $��Center=�60   $��Center=�6M   $��16(�6h   Pick dates:6�   �� 5"   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5#      �� $��16(�6   $��Center=�6&   $��60 15 20 15q�6A   Start:6_   (  "System.Windows.Controls.DatePicker  5$      -   5        	  Name$	 StartDatePicker��5$      $��10 15q�62   
   Text$
 Start��6A   $��16(�6N   6^   �� 5%      $��16(�6   $��Center=�6&   $��60 15 20 15q�6A   End:6\     5&      -   5        $	 EndDatePicker��5&      $��10 15q�60   $	
 End��6?   $��16(�6J   6Z   5'      �� 5(   
   $��6��6   $��10 15q�6!   $��Center=�60   $��Center=�6M   $��16(�6h   
Options:6�   �� 5)   
   $��6��6   $��1��6"   $��Center=�62   $ 
Horizontal=�6M   .+�5*      �� -   5         ��Name$ CheckBoxExam��5*      $��16(�6-   $��40 15q�6;   .��6J   Followed by exam6\   �� 5+      -	   5        $ CheckBoxRequirements��5+      $��16(�65   $��40 15q�6C   .��6R   Has requiements6c   5,      �� 5-   
   -
   5         ��Name$ ButtonCancel��5-      $��7��6'   $��16(�64   $��Center=�6B   $��Center=�6_   $��10 15q�6z   $
��10 5q�6�   .��6�   Cancel6�   �� 5.   
   -   5        $ ButtonSubmit��5.      $��7��6'   $��1��64   $��Center=�6D   $��Center=�6a   $��16(�6|   $
��10 5q�6�   $��10 15q�6�   .��6�   Submit6�   5/      50      
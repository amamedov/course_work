   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	       ManagerApp.AddStudent   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Add student��5   	   $	��450��6   $	��600��6*    � WindowStartupLocation$ CenterScreen=�66    � 
ResizeMode$ NoResize=�6[   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��4* �6   .+�5   
   �� $��16(�6   $��Center=�6"   $��Center=�6@   $��2��6[   Enter student information6�   �� 5   
   $��16(�6   $��Center=�6"   $��Center=�6?   $��10 15q�6Z   $��1��6i   Name:6}   �� 5   
   -   5         ��Name$ TextBoxName��5      $��1��6'   $��1��64   $��16(�6D   $��Stretch=�6R   $��Center=�6p   $��10 15q�6�   6�   �� 5   
   $��16(�6   $��Center=�6"   $��Center=�6?   $��10 15q�6Z   $��2��6i   
Surname:6�   �� 5   
   -   5        $ TextBoxSurname��5      $��2��6*   $��1��67   $��16(�6G   $��Stretch=�6U   $��Center=�6s   $��10 15q�6�   6�   �� 5   
   $��16(�6   $��Center=�6"   $��Center=�6?   $��10 15q�6Z   $��3��6i   Date of birth :6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatePickerDOB��5      $��3��6,   $��1��69   $��16(�6I   $��Stretch=�6W   $��Center=�6u   $��10 15q�6�   6�   �� 5   
   $��16(�6   $��Center=�6"   $��Center=�6?   $��10 15q�6Z   $��4��6i   	Gender:6   �� 5   
   -   5         ��Name$ ComboBoxGender��5      $��4��6+   $��1��68   $��16(�6H   $��Stretch=�6V   $��Center=�6t   $��10 15q�6�   6�   �� 5   
   -   5         ��Name$ ButtonCancel��5      $��16(�6B   $��Center=�6P   $��Center=�6m   $��10 15q�6�   $��10 15q�6�   $��5��6�   .��6�   Cancel6�   �� 5    
   -   5        $ ButtonSubmit��5       $��16(�6'   $��Center=�65   $��Center=�6R   $��10 15q�6m   $��10 15q�6|   $��5��6�   $��1��6�   .��6�   Submit6�   5!      5"      
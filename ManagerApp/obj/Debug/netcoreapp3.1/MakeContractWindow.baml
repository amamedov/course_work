   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	   #    ManagerApp.MakeContractWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	     � Title$  Create contract��5   	   $	��309��6!   $	��470��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��10 15q�6   $��2��6#   $��Center=�67   $��16(�6T   $��Center=�6b   &$Enter information about the contract6�   �� 5   
   $��1��6   $��16(�6!   $��Right=�6/   $��Center=�6K   $��15q�6f   
Student:6|   �� 5   
   -   5         ��Name$ ComboBoxStudent��5   0    �� DisplayMemberPath$ FullName��6   $��1��6I   $��Center=�6Y   $��16(�6t   $��Stretch=�6�   $��10 15 20 15q�6�   $��1��6�   6�   �� 5   
   $��3��6   $��16(�6!   $��Right=�6/   $��Center=�6K   $��15q�6f   	Course:6{   �� 5   
   -   5        $ ComboBoxCourse��5      $��1��6+   $��Center=�6;   $��16(�6V   $��Stretch=�6d   $��10 15 20 15q�6�   $��3��6�   6�   �� 5   
   -   5         ��Name$ ButtonCancel��5      $��4��6'   $��16(�64   $��Center=�6B   $��Center=�6_   $
��15 5q�6z   $��0��6�   .��6�   Cancel6�   �� 5   
   -   5        $ 
ButtonMake��5      $��4��6%   $��16(�62   $��Center=�6@   $��Center=�6]   $
��15 5q�6x   $��1��6�   .��6�   Make contract6�   5      5      
   M S B A M L   `   `   `  ����E  ATeacherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:TeacherApp
TeacherApp  5   	       TeacherApp.PathWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:TeacherApp     5   	     � Title$  
PathWindow��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��200��6A   $	��700��6N    � 
ResizeMode$ NoResize=�6Z   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $	��11* �6   .+�5   
   �� -   5         ��Name$ ButtonSubmit��5      $��2��6'   $��1��6;   $��Center=�6H   $��Center=�6c   $��16(�6�   $
��10 5q�6�   .��6�   Submit6�   �� 5   
   $��16(�6   $��Center=�6"   $��Center=�6=   Output path:6h   �� 5   
   -   5         ��Name$ PathBox��5   %    �� 
IsReadOnly$
 True��6   $��16(�66   $��1��6D   $��Center=�6T   $��Stretch=�6o   $��0 0 10 0q�6�   .��6�   Choose folder6�   �� 5   
   -   5        $��2��5      $��Center=�69   $��Center=�6V   $��16(�6q   $
��10 5q�6   .��6�   Browse6�   5      5      
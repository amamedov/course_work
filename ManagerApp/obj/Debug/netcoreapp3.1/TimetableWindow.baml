   M S B A M L   `   `   `  ����E  AManagerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ManagerApp
ManagerApp  5   	        ManagerApp.TimetableWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ManagerApp     5   	   $	��450��5   +   $	��930��68     � 
ResizeMode$  NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6[    � Title 6	   ��  �� Path$ 
WindowName�.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ 	ButtonAdd��5      $��16(�6<   $��Center=�6J   $��25 15q�6g   $��Center=�6w   .��6�   Add6�   �� 5   
   -   5        $ ButtonClose��5      $��1��6&   $��16(�63   $��Center=�6A   $��25 15q�6^   $��Center=�6n   .��6�   Close6�   �� 5   
   $��2��6   $��1��6&   .+�5      ��  �� Orientation$ 
Horizontal=�6   $
��10 1q�62   .+�5      �� $��80��6    �� TextAlignment$ Center=�6'   $
��Date��6>   $��16(�6K   $��10 15q�6Y   $��Center=�6h   6�   �� 5      $��50��6   $ Center=�6'   $��16(�6>   $
��Time��6L   $��Center=�6X   $��10 15q�6s   6�   �� 5      $��70��6   $ Center=�6(   $��16(�6?   $��Duration��6M   $��Center=�6]   $��10 15q�6x   6�   �� 5      $��60��6   $ Center=�6'   $��16(�6>   $
��Room��6L   $��Center=�6X   $��10 15q�6s   6�   �� 5      $	��120��6   $ Center=�6(   $��16(�6?   $��Teacher��6M   $��Center=�6\   $��10 15q�6w   6�   �� 5      $	��250��6   $ Center=�6(   $��16(�6?   $��Address��6M   $��Center=�6\   $��10 15q�6w   6�   5      �� 5      -   5        	 ��Name$	 ListBoxLessons��5   ~   $��Hidden=�6J   $��1��6�   $��2��6�   $��1q�6�   $��Stretch=�6�   $
��10 1q�6�   ��5      �� 5      .R�5       �� $ 
Horizontal=�6%   .+�5!      �� $��80��6(   $ Center=�63   $
��10 5q�6J   $��16(�6X   ��6f   �� $
 Date�6�   �� 5"      $��50��6(   $ Center=�63   $
��10 5q�6J   $��16(�6X   ��6f   �� $ 	StartTime�6�   �� 5#      $��70��6(   $ Center=�63   $
��10 5q�6J   $��16(�6X   ��6f   �� $ Duration�6�   �� 5$      $��60��6(   $ Center=�63   $
��10 5q�6J   $��16(�6X   ��6f   �� $ 	Room.Name�6�   �� 5%      $	��120��6(   $ Center=�64   $
��10 5q�6K   $��16(�6Y   ��6g   �� $ Teacher.Fullname�6�   �� 5&      $	��250��6(   $ Center=�64   $
��10 5q�6K   $��16(�6Y   ��6g   �� $ Room.Building.Address�6�   5'      5(      5*      5+      5,      5-      
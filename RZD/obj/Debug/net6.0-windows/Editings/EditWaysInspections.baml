   M S B A M L   `   `   `  ����>  :RZD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RZDRZD  5   	       RZD.EditWaysInspections   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RZD     5   	     � Title$:  4Редактирование осмотра пути��5   	   $	��530��6-   $	��800��6:    � Icon$ /Images/rzd.png��5	   	    � WindowState$ 	Maximized=�6     � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 12��6!   #��z��63   
���   �$	��0.9q�6q   ._�5      �� #��z��6/   #��z��6r   5      5      5      5      5      ��5      �� 5   
   	 �� ImageSource$	 /Images/fonss112.png��6   .��5      � .+�5   
   (� 
 (� Stretch$
 Uniform=�6   .��5      �� .+�5      �� $-��'Выберите дату и время��6   $��Century Gothic)�69    J� Opacity$	 0.8Q�6U   $
��Bold"�6c   $��16(�6u   $��0 0 0 10q�6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DateTime��5      $	 0.9Q�6/   $
��Left=�6j   $
��auto��6�   $
��auto��6�   $��0 0 0 15q�6�      SelectedDate 6=   ��  �� Path$ InspectionDate�6�   �� 5       $��Номер пути��6   $��Century Gothic)�6.   $	 0.8Q�6J   $
��Bold"�6X   $��16(�6j   $��0 0 0 5q�6x   �� 5!      -   5         ��Name$ 
WaysNumber��5!      $	 0.8Q�6O   $
��Left=�6]   $	��150��6x   $��25��6�   $��0 0 0 10q�6�   ��6.   �� $ 
WaysNumber�6�   �� 5#      $��
Место��6   $��Century Gothic)�6)   $	 0.8Q�6E   $
��Bold"�6S   $��16(�6e   $��0 0 0 5q�6s   �� 5$      -   5        $��WaysComboBox��5$       �� DisplayMemberPath$ WaysName��6U   ��6/   �� $ WaysList�5%      �� 5'      $%��Запись нарушений��6   $��Century Gothic)�64   $	 0.8Q�6P   $
��Bold"�6^   $��20(�6p   $��0 0 0 10q�6~   �� 5)      -   5        $ Description��5)      $	 0.8Q�6Q   $	��340��6_   $	��140��6k    �� AcceptsReturn$
 True��6x    �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0 0 0 10q�6�   ��6/   �� $ Description�.��6�    5*      ��%^   '��       �� 5+      " ��6    .�5,      ��  �@��CornerRadius$ 6��6=   5-      5.      .��6)   5/      �� 51      -   5         ��Name$ SubmitButton��51      $	 0.8Q�6/   $)��#Записать нарушение��6=   $	��200��6Z   $��30��6f   $��Center=�6r   $��5q�6�   
�������6�   �� 52      -   5        $ 	Violation��52      $>��8Нет выявленных несоответствий��6-   $	 0.8Q�6U   $	��200��6c   $��30��6o   $��5q�6{   
�������6�   54      55      57      58      
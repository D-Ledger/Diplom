   M S B A M L   `   `   `  ����>  :RZD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RZDRZD  5   	       RZD.WaysInspections   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RZD     5   	     � Title$  Осмотр пути��5   	   $	��560��6   $	��820��6*    � Icon$ /Images/rzd.png��5	   	    � WindowStartupLocation$ CenterScreen=�6     � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 12��6!   #��z��63   
���   �$	��0.9q�6q   ._�5      �� #��z��6/   #��z��6r   5      5      5      5      5      ��5      �� 5   
   	 �� ImageSource$	 /Images/fonw.jpg��6   .��5      � .+�5   
   (� 
 (� Stretch$
 Uniform=�6   .��5      �� .+�5      �� $��Выберите дату��6   $��Century Gothic)�61    J� Opacity$	 0.8Q�6M   $
��Bold"�6[   $��16(�6m   $��0 0 0 10q�6{   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ DateTime��5      $	 0.9Q�6/   $
��Left=�6j   $
��auto��6�   $
��auto��6�   $��0 0 0 15q�6�      SelectedDate 6=   ��  �� Path$ InspectionDate�6�   �� 5       $��Номер пути��6   $��Century Gothic)�6.   $	 0.8Q�6J   $
��Bold"�6X   $��16(�6j   $��0 0 0 5q�6x   �� 5!      -   5         ��Name$ 
WaysNumber��5!      $	 0.8Q�6O   $
��Left=�6]   $	��150��6x   $��25��6�   $��16(�6�   $��0 0 0 10q�6�   
���   ���6.   �� $ 
WaysNumber�.��6�    5"      ��%_   '��       �� 5#      " ��6    .�5$      ��  �@��CornerRadius$ 10��6=   5%      5&      .��6)   5'      �� 5)      $��
Место��6   $��Century Gothic)�6)   $	 0.8Q�6E   $
��Bold"�6S   $��16(�6e   $��0 0 0 5q�6s   �� 5*      -   5        $��WaysComboBox��5*       �� DisplayMemberPath$ WaysName��6r   ��6/   �� $ WaysList� �� SelectedItem 6U   �� *Way+5+      �� 5-      $��Запись��6   $��Century Gothic)�6*   $	 0.8Q�6F   $
��Bold"�6T   $��20(�6f   $��0 10 0 5q�6t   �� 5/      -   5        $ Description��5/      $	��340��6Q   $	��140��6]    �� AcceptsReturn$
 True��6j    �� TextWrapping$
 Wrap=�6   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0 0 0 10q�6�   
���   ���6/   �� $ Description�.��6�    50      ��%^   '��       �� 51      " ��6    .�52      ��  �@��CornerRadius$ 6��6=   53      54      .��6)   55      �� 57      -   5         ��Name$ SubmitButton��57      $=��7Сообщить дежурному по станции��6/   $	��200��6W   $��30��6c   $��Center=�6o   $��5q�6�   
�������6�   �� 58      -   5        $ 	Violation��58      $>��8Нет выявленных несоответствий��6,   $	��200��6U   $��30��6a   $��5q�6m   
�������6�   5:      5;      �� 5<   
   -   5        $��
Выход��5<      $��80��6!   $��34��6,   $
��Left=�68   $	��Top=�6S   $��	24,10,0,0q�6k   
�������6�   5=      5>      
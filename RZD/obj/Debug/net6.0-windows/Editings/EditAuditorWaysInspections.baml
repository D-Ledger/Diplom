   M S B A M L   `   `   `  ����>  :RZD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RZDRZD  5   	   $    RZD.EditAuditorWaysInspections   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RZD     5   	     � Title$<  6Редактирование осмотра путей��5   	    � Icon$ /Images/rzd.png��6.   $	��400��5	   	   $	��700��6    � WindowStartupLocation$ CenterScreen=�6"    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 12��6!   #��z��63   
���   �$	��1.5q�6q   ._�5      �� #��z��6/   #��z��6r   5      5      5      5      5      ��5      �� 5   
   	 �� ImageSource$	 /Images/logo1.jpg��6   .��5      � .+�5   
   �� $��14(�6   $(��"Информация о путях��6!   $��Century Gothic)�6=   
���   �$��0 0 0 10q�6m   .��5      �� .+�5      �� $��16(�6   $��Дата��6+   $��Century Gothic)�67   $��5q�6S   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 DepartureDate��5      $��5q�6X      SelectedDate 65   ��  �� Path$
 Date�6X   �� 5       $��16(�6   $��
Место��6+   $��Century Gothic)�68   $��5q�6T   �� 5!      -   5        $��WaysComboBox��5!       �� DisplayMemberPath$ WaysName��6U   ��6/   �� $ WaysList�5"      �� 5$      $��16(�6   $��Нарушение��6+   $��Century Gothic)�6<   $��5q�6X   �� 5%      -   5         ��Name$ Description��5%      $��16(�6/   $��5q�6=    �� TextWrapping$
 Wrap=�6H   �� 5'      -   5         ��Name$ 
sendButton��5'      $)��#Отправить путейцам��6-   $��Center=�6J   $��6q�6g   $	��Top=�6r   $	��150��6�   $��26��6�   6�   �� 5(      -   5        $ closeButton��5(      $%��Закрыть движение��6.   $��Center=�6I   $��6q�6f   $	��Top=�6q   $	��150��6�   $��26��6�   6�   �� 5*      -   5         ��Name$ recordInfoTextBlock��5*      $��Center=�69   $��16(�6V   
���  ��$	��120��6u   $
��Wrap=�6�   5+      5,      5-      5.      
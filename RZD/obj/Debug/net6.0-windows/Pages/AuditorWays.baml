   M S B A M L   `   `   `  ����>  :RZD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RZDRZD  5   	       RZD.AuditorWays   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:RZD     5   	     � Title$  Осмотр путей��5   	    � Icon$ /Images/rzd.png��6   $	��410��5	   	   $	��720��6    � WindowStartupLocation$ CenterScreen=�6"    � 	Resources 5
       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 12��6!   #��z��63   
���   �$	��1.5q�6q   ._�5      �� #��z��6/   #��z��6r   5      5      5      5      5      ��5      �� 5   
   	 �� ImageSource$	 /Images/logo.jpg��6   .��5      � .+�5   
   �� $��14(�6   $(��"Информация о путях��6!   $��Century Gothic)�6=   
���   �$��0 0 0 10q�6m   .��5      �� .+�5      �� $��16(�6   $��Дата��6+   $��Century Gothic)�67   $��5q�6S   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 DepartureDate��5      $��5q�6X      SelectedDate 65   ��  �� Path$
 Date�6X   �� 5!      $��16(�6   $��Название пути��6+   $��Century Gothic)�6@   $��5q�6\   �� 5"      -   5        $��WaysComboBox��5"      $��5 0 5 0q�6/    �� DisplayMemberPath$ WaysName��6�   ��6@   �� $ WaysList� �� SelectedItem 6f   �� *Way+6�   �� 5$      $��16(�6   $��Нарушение��6+   $��Century Gothic)�6<   $��5q�6X   �� 5%      -   5         ��Name$ Description��5%      $��16(�6/   $��5q�6=    �� TextWrapping$
 Wrap=�6H   .��6\    5&      ��%^   '��       �� 5'      " ��6    .�5(      ��  �@��CornerRadius$ 8��6=   5)      5*      .��6)   5+      �� 5-      -   5         ��Name$ 
sendButton��5-      $)��#Отправить путейцам��6-   $��Center=�6J   
�������$��6q�6z   $	��Top=�6�   $	��150��6�   $��26��6�   6�   �� 5.      -   5        $ closeButton��5.      $%��Закрыть движение��6.   $��Center=�6I   
�������$��6q�6y   $	��Top=�6�   $	��150��6�   $��26��6�   6�   �� 50      -   5         ��Name$ recordInfoTextBlock��50      $��Center=�69   $��16(�6V   
���  ��$	��120��6u   $
��Wrap=�6�   51      52      53      54      
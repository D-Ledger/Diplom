   M S B A M L   `   `   `  ����>  :RZD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:RZDRZD  5   	        RZD.AuditorTrainInspection   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42dt)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   localclr-namespace:RZD  5   	     � Title$  Осмотр поезда��5	   	   $	��515��6   $	��900��6,    � Icon$ /Images/rzd.png��68    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�   '��       �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 12��6!   #��z��63   
���   �$	��1.5q�6q   ._�5      �� #��z��6/   #��z��6r   5      5      5      5      5      ��5      �� 5   
   	 �� ImageSource$	 /Images/logo.jpg��6   .��5      � .+�5   
   �� $��10q�6   .+�5      �� $N��HОформление записи на готовность поезда��6   $��Century Gothic)�6F   $��Center=�6b   $��20(�6   $
��Bold"�6�   $��0 0 0 10q�6�   �� 5       $��14(�6   $?��9Информация о готовности поезда��6%   $��Century Gothic)�6M   
���   �$��0 0 0 10q�6}   .��5!      �� .+�5"      �� $��16(�6    $��Номер поезда��6.   $��Century Gothic)�6B   $��5q�6^   �� 5#      -   5        
 ��Name$
 TrainNumber��5#      $��16(�63    �� 	IsEnabled$
 True��6B    � Language$ ru-ru�6^   $��5q�6o    �� TextWrapping$
 Wrap=�6z   .��6�    5$      ��%^   '��       �� 5%      " ��6$   .�5&   "   ��  �@��CornerRadius$ 8��6A   5'      5(      .��6-   5)      �� 5+      $��16(�6    $D��>Наименование станции отправления��6.   $��Century Gothic)�6V   $��5q�6r   �� 5,      -   5        $
 DepartureStation��5,      $��16(�68   $
 True��6G   $ ru-ru�6c   $��5q�6t   $
 Wrap=�6    �� 	MaxLength$ 50��6�   .��6�    5-      ��%^   '��       �� 5.      " ��6$   .�5/   "   ��  �@��CornerRadius$ 8��6A   50      51      .��6-   52      �� 54      $��16(�6    $>��8Наименование станции прибытия��6.   $��Century Gothic)�6S   $��5q�6o   �� 55      -   5        $
 ArrivalStation��55      $��16(�66   $
 True��6D   $ ru-ru�6`   $��5q�6q   $
 Wrap=�6|   $ 50��6�   .��6�    56      ��%^   '��       �� 57      " ��6$   .�58   "   ��  �@��CornerRadius$ 8��6A   59      5:      .��6-   5;      �� 5=      $��16(�6    $��Дата и время��6/   $��Century Gothic)�6C   $��5q�6_   (  "System.Windows.Controls.DatePicker  5>      -   5          Name$ DepartureDate��5>   !   $��5q�6e      SelectedDate 68   ��  �� Path$ InspectionDate�6e   5@      5A      �� 5D      -   5        $#��Оформить запись��5D      $	��150��61   $��Center=�6=   $��16(�6Z   
�������$��30��6{   $��10q�6�   6�   �� 5G      -   5         ��Name$ 	readiness��5G   3   $+��%Отменить готовность��6   $	��166��6F   $��Center=�6R   $��16(�6o   
�������$��28��6�   $��10q�6�   6�   �� 5J      -   5         ��Name$ recordInfoTextBlock��5J      $��Center=�65   $��20(�6R   
���  ��$
��Wrap=�6q   5K      5L      5M      
   M S B A M L   `   `   `  ����D  @Ambulance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ambulance	Ambulance  5   	   $    Ambulance.CarsInfrmationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ambulance     5   	     � Title$,  &Информация о бригаде��5   	   $	��600��6&   $	��800��63   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	gridCalls��5      $��1��6&   $��10,10,10,10q�63   $��SemiBold"�6H   $��1��6^      
IsReadOnly$
 True��6n   "   VerticalScrollBarVisibility$
 Auto=�6�      SelectionMode$ Single=�6�      CanUserResizeColumns$ False��6�      CanUserResizeRows$ False��6�      CanUserReorderColumns$ False��6�   	   AutoGenerateColumns$	 False��6  
   CanUserSortColumns$
 False��6+     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
CallNumber+6`     5      $ 
Улица��6%   $ 2* 6W    64   �� *Patient.Street+6d     5      $ Дом��6%   $
 0.5* 6Z    62   �� *Patient.HouseNumber+6i     5      $ Фамилия��6%   $ 2* 6V    66   �� *Patient.FIO+6c     5      $ Воз.��6%   $
 0.5* 6S    63   �� *Patient.Age+6b     5      $ 
Повод��6%   $ 2* 6R    64   �� *	Diagnosis+6_     5      $ Экстренность��6%   $ 1* 6T    6;   �� *Type+6a   5      �� 5   
   $��1q�6   
���   �$��10,10,10,389q�69   $��2��6O   ._�5      � .+�5      �� $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Врач��6O   $
��Left=�6^   $��	10,37,0,0q�6y   $	��Top=�6�   �� 5      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Фельдшер 1��6O   $
��Left=�6d   $��	10,67,0,0q�6   $	��Top=�6�   �� 5      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Фельдшер 2��6O   $
��Left=�6d   $��	10,97,0,0q�6   $	��Top=�6�   �� 5      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Санитар��6O   $
��Left=�6a   $��
10,127,0,0q�6|   $	��Top=�6�   �� 5      -   5         ��Name$ lableDoktor��5      $��13(�6-   $��Arial)�6;   $��SemiBold"�6N   $��Label��6d   $
��Left=�6t   $��
110,37,0,0q�6�   $	��Top=�6�   �� 5       -   5        $ lableMedAssistant1��5       $��13(�64   $��Arial)�6B   $��SemiBold"�6U   $��Label��6k   $
��Left=�6{   $��
110,67,0,0q�6�   $	��Top=�6�   �� 5!      -   5        $ lableMedAssistant2��5!      $��13(�64   $��Arial)�6B   $��SemiBold"�6U   $��Label��6k   $
��Left=�6{   $��
110,97,0,0q�6�   $	��Top=�6�   �� 5"      -   5        $ lableOrderly��5"      $��13(�6.   $��Arial)�6<   $��SemiBold"�6O   $��Label��6e   $
��Left=�6u   $��110,127,0,0q�6�   $	��Top=�6�   �� 5#      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Водитель��6O   $��Center=�6b   $��0,37,0,0q�6   $	��Top=�6�   �� 5$      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Подстанция��6O   $
��Left=�6d   $��
352,67,0,0q�6   $	��Top=�6�   �� 5%      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Тип��6O   $
��Left=�6]   $��
352,97,0,0q�6x   $	��Top=�6�   �� 5&      $��13(�6   $��Arial)�6&   $��SemiBold"�69   $��Кол. вызовов��6O   $
��Left=�6f   $��352,127,0,0q�6�   $	��Top=�6�   �� 5'      -   5        $ lableDriver��5'      $��13(�6-   $��Arial)�6;   $��SemiBold"�6N   $��Label��6d   $
��Left=�6t   $��
455,37,0,0q�6�   $	��Top=�6�   �� 5(      -   5        $ lableStationName��5(      $��13(�62   $��Arial)�6@   $��SemiBold"�6S   $��Label��6i   $
��Left=�6y   $��
455,67,0,0q�6�   $	��Top=�6�   �� 5)      -   5        $ 	lableType��5)      $��13(�6+   $��Arial)�69   $��SemiBold"�6L   $��Label��6b   $
��Left=�6r   $��
455,97,0,0q�6�   $	��Top=�6�   �� 5*      -	   5        $ lableNumberOfCalls��5*      $��13(�64   $��Arial)�6B   $��SemiBold"�6U   $��Label��6k   $
��Left=�6{   $��455,127,0,0q�6�   $	��Top=�6�   �� 5+      $��15(�6   $��SemiBold"�6&   $��Arial)�6<   $��12��6O   
����  �$��Center=�6n   $��0,10,0,0q�6�   $	��Top=�6�   �� 5,      $��№ бригады��6   $��15(�6,   $��SemiBold"�6:   $��Arial)�6P   $
��Left=�6c   $��
280,10,0,0q�6~   $	��Top=�6�   5-      5.      5/      50      
   M S B A M L   `   `   `  ����D  @Ambulance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ambulance	Ambulance  5   	       Ambulance.WorkerWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ambulance     5   	   -   5          � Title$  Сотрудники��5   	    � WindowState$ 	Maximized=�6   $	��700��64   $
��1100��6D   .��5	      �  � ShowGridLines$
 True��6    � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��3* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6   
��� � �$��2q�62    �� CornerRadius$ 10��6F   $��	10,0,10,0q�6X   ._�5      � .+�5      �� -   5         ��Name$ textFIO��5      $��Center=�6+    �� CharacterCasing$ Upper=�6M   $��10,42,195,0q�6e   $��20(�6z   $��Arial)�6�   $	��Top=�6�   $��30��6�   �� 5      -   5        $��
Поиск��5      $��19(�6)   $��	0,37,23,0q�67   $	��Top=�6J   $��40��6b   $��Right=�6n   $	��140��6�   6�   �� 5      $#��Ф.И.О сотрудника��6   $��19(�63   $��SemiBold"�6A   
����  �$
��Left=�6i   $��10,7,0,0q�6�   $	��Top=�6�   �� 5      $��Должность��6   $��19(�6,   $��SemiBold"�6:   
����  �$
��Left=�6b   $��10,0,0,0q�6}   $��Center=�6�   �� 5      -   5         ��Name$ comboPosition��5      $��14(�62   $��Convers)�6@   $��SemiBold"�6U   $��Center=�6k   $
��Left=�6�   $��
10,118,0,0q�6�   $	��Top=�6�   $	��224��6�   $��30��6�   .@�5      �� $��Врач��6#   �� 5      $��Диспетчер��6#   �� 5      $��Фельдшер��6#   �� 5      $��Санитар��6#   �� 5      $��Водитель��6#   �� 5      $��Статистик��6#   5      �� 5      -   5         ��Name$ checkAllWorkers��5      $!��Все сотрудники��64   $��18(�6M   $��Arial)�6[   
����  �$��SemiBold"�6�   $��
0,123,23,0q�6�   $	��Top=�6�   $��Right=�6�   $	��161��6�   5       5!      �� 5"   
   $��2q�6   
��� � �$ 10��69   $��2��6K   $��
10,10,10,0q�6X   ._�5#      � .+�5$      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 gridWorkers��5$      
   AutoGenerateColumns$
 False��6V   $��18(�6r   $
��Left=�6�      CanUserAddRows$ False��6�      CanUserDeleteRows$ False��6�      CanUserResizeColumns$ False��6�   $��
10,10,10,0q�6�   ��60   �� *listOfWorkers+   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *FIO+  5'      $ Должность��6-    6@   �� *GetPosition+5)      5*      5+      �� 5,   
   $1��+Справочник сотрудников��6   $
��Aral)�61   
����  �$
��Bold"�6U   $��25(�6g   $��Center=�6u   $��0,31,0,0q�6�   $	��Top=�6�   �� 5-   
   -   5        $!��Удалить запись��5-      $��19(�6*   $
��Left=�68   $��	106,0,0,0q�6S   $��3��6f   $��Center=�6s   $��40��6�   $	��160��6�   6�   �� 5.   
   -   5        $��Добавить��5.      $��19(�6$   $��Center=�62   $��3��6O   $��Center=�6\   $��40��6w   $	��160��6�   6�   �� 5/   
   -	   5        $��Закрыть��5/      $��19(�6#   $��0,0,96,0q�61   $��3��6C   $��Center=�6P   $��40��6k   $��Right=�6�   $	��160��6�   50      51      
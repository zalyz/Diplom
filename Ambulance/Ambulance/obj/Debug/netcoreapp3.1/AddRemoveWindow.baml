   M S B A M L   `   `   `  ����D  @Ambulance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ambulance	Ambulance  5   	       Ambulance.AddDiagnosis   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ambulance     5   	     � Title$/  )Редактирование данных��5   	   $	��450��6'   $	��600��64   .��5	      �  � RowDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ ListDiagnoses��5      $��15(�6)   $��10,10,10,10q�67   $��1��6L   �� 5   
   -   5         ��Name$ text1��5      $��15(�6!   $��Arial)�6/   $��Center=�6B    �� CharacterCasing$ Upper=�6d   $
��Left=�6|   $��DemiBold"�6�   $��
10,104,0,0q�6�   $	��Top=�6�   $	��445��6�   $��25��6�   �� 5   
   -   5         ��Name$ Lable��5      $<��6Добавление/Удаление диагноза��6   $��17(�6F   $��Arial)�6T   $��SemiBold"�6g   
����  �$��Center=�6�   $��0,29,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $��Добавить��5      $��14(�6$   $��Arial)�62   $��460,104,10,0q�6E   $	��Top=�6[   $��25��6s   6   �� 5   
   -   5        $��Удалить��5      $��14(�6#   $��Arial)�61   $
��Left=�6D   $��37,0,0,0q�6_   $��2��6q   $��Center=�6~   $��30��6�   $	��130��6�   6�   �� 5   
   -   5        $��Закрыть��5      $��14(�6#   $��Arial)�61   $
��Left=�6D   $��	444,0,0,0q�6_   $��2��6r   $��Center=�6   $��30��6�   $	��130��6�   6�   5      5      
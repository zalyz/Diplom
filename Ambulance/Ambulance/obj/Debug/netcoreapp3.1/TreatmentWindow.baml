   M S B A M L   `   `   `  ����D  @Ambulance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ambulance	Ambulance  5   	       Ambulance.TreatmentWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ambulance     5   	     � Title$  Действия��5   	   $	��500��6   $	��500��6'   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��1* �6   .+�5   
   �� $%��Оказанная помощь��6   $��20(�6+   $��Arial)�69   
����  �$��SemiBold"�6^   $��Center=�6t   $��Center=�6�   �� 5   
   -   5         ��Name$ comboTreatment��5      $��22(�6+   $��Convers)�69   $��SemiBold"�6N   $��Center=�6d    K� Capitals$ AllPetiteCaps=�6�   $��Center=�6�   $��1��6�   $	��Top=�6�    �� 
IsEditable$
 True��6�   
�������$	��450��6  $��37��6!  $��0,23,0,0q�6-  �� 5   
   $��2��6   $��10,10,10,10q�6   
��� � �$��1q�6G    �� CornerRadius$ 10��6[   ._�5      �� -   5         ��Name$ textTreatment��5      $��SemiBold"�6-   $��Center=�6D   $��2q�6a    �� 
IsReadOnly$
 True��6u   $��20(�6�   $��Arial)�6�    �� AcceptsReturn$
 True��6�   
�������$��2��6�   $��TextBox��6�   	 �� TextWrapping$
	 Wrap=�6�   $��Center=�6  $	��450��6  $	��203��6+  5      �� 5   
   -   5        $��Очистить��5      $��20(�6$   $��Arial)�62   $��SemiBold"�6E   $��Center=�6[   $��3��6x   $��Center=�6�   $��40��6�   $	��250��6�   6�   �� 5   
   -   5        $��Добавить��5      $��20(�6$   $��Arial)�62   $��SemiBold"�6E   $��Center=�6[   $��0,0,0,10q�6x   $��1��6�   $��Bottom=�6�   $��40��6�   $	��250��6�   6�   5      5      
   M S B A M L   `   `   `  ����D  @Ambulance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Ambulance	Ambulance  5   	   ,    &Ambulance.DispatcherRegistrationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Ambulance     5   	     � Title$#  Ввод диспетчера��5   	   $	��410��6!   $	��285��6-    � 
ResizeMode$ NoResize=�6:    � WindowStyle$ ThreeDBorderWindow=�6P    � WindowStartupLocation$ CenterScreen=�6q   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ textDispatcherNumber��5      $��15(�60   $��30��6>   
���   �$��
205,0,10,0q�6^   $��Center=�6r   $��1��6�   6�   �� 5   
   -   5        $ textDispatcherFIO��5      $��15(�6-   $��Arial)�6;   $��Center=�6N    �� CharacterCasing$ Upper=�6p   $��
205,0,10,0q�6�   $��2��6�   
���   �$��Center=�6�   $��30��6�   �� 5   
   $0��*Ввод нового диспетчера��6   $��15(�61   $��Arial)�6?   $��Center=�6R   $��Center=�6o   $��0��6�   $��
82,10,82,4q�6�   �� 5   
   $%��Номер диспетчера��6   $��15(�6+   $��Arial)�69   $
��Left=�6L   $��28,0,0,0q�6g   $��Center=�6y   $��29��6�   $��1��6�   �� 5   
   $��Фамилия��6   $��15(�6"   $��Arial)�60   $
��Left=�6C   $��67,0,0,0q�6^   $��Center=�6p    J� RenderTransformOrigin$ -0.097,0.04&�6�   $��30��6�   $��2��6�   �� 5   
   -   5        $��Принять��5      $��30��6#   $��65,20,225,0q�6/   $��3��6D   $	��Top=�6Q   6i   �� 5   
   $��Отмена��6   $��30��6"   $��225,20,65,0q�6.    �� IsCancel$
 True��6C   $��3��6S   $	��Top=�6`   5      5      
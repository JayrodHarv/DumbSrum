   M S B A M L   `   `   `  ����D  @DumbScrum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DumbScrum.ViewsDumbScrum.Views  5          DumbScrum.Views.HomeView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:DumbScrum.Views     5      -   5        .��5	      �   � RowDefinitions  5
   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      .+�5   
   �� -   5        $��
lblWelcome��5   -   $��0��6   $��0��6   $��Welcome User��6?   $��16(�5      $��Center=�6   $��	20,0,20,0q�69   �� 5   
   $��1��6   $��0��6"   $��Center=�62   $
��Left=�6M    �� Orientation$ 
Horizontal=�6h   $
��20,0q�6�   .+�5      �� ���	#FF34BFEC$��60��6,   $��40��67    �� CornerRadius$ 5,0,0,5��6C   ._�5      �� $��My Tasks��6   
�������$��Center=�6?   $��Center=�6\   5      �� 5      $	��120��6   $��40��6!   $	��0.5q�6-   
�������._�5      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5      �� $��In Progress��6    
��� ���$��5q�6G   �� 5      -   5         ��Name$ tbInProgress��5       $��0��66   $��5q�6?   5      5      �� 5      $	��120��6   $��40��6!   $	��0.5q�6-   
�������._�5      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5      �� $��Needs Reviewed��6    
��� ���$��5q�6J   �� 5      -   5        $ tbNeedsReviewed��5       $��0��69   $��5q�6B   5      5       �� 5!      $	��120��6   $��40��6!   $	��0.5q�6-   
�������$ 0,5,5,0��6V   ._�5"      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�5#      �� $��Complete��6    
��� � �$��5q�6C   �� 5$      -   5        $ 
tbComplete��5$       $��0��64   $��5q�6=   5%      5&      5'      �� 5;   
   $��2��6   
�������$	��0.5q�61   $��15q�6G   ._�5<      �� $
��Auto=�6   .��5=      �� $ Vertical=�6   $��Stretch=�64   $	��Top=�6R   .+�5>      �� $��My Tasks��6   
�������$��	0,0,0,0.5q�6B   �� 5?      -   5         ��Name$ icUserTasks��5?   #   5@      5A      5B      5C      5D      